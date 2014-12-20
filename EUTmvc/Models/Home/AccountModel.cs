using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EUTmvc.Utils;
using SRVTextToImage;

namespace EUTmvc.Models
{
    public class AccountModel
    {
        static EUTContext db = new EUTContext();
        static CaptchaRandomImage CI = new CaptchaRandomImage();
        public static tblAccount Login(LoginModel model)
        {
            string pass = Md5.GetMd5Hash(model.PassWord);
            var v = db.tblAccounts.FirstOrDefault(a => a.Account.Equals(model.Account) && a.PassWord.Equals(pass));
            if (v != null)
            {
                v.EndTime = v.NewTime;
                v.NewTime = DateTime.Now;
                db.SaveChanges();
            }
            return v;
        }

        public static bool Register(RegisterModel model)
        {
            if (!CheckUserName(model.Account))
            {
                if (!CheckEmail(model.Email))
                {
                    string pass = Md5.GetMd5Hash(model.PassWord);
                    string emailCode = CI.GetRandomString(16);
                    var person = new tblPerson
                    {
                        Code = model.Account,
                        Email = model.Email,
                        CreatedDate = DateTime.Now,
                        CreatedBy = model.Account
                    };
                    var user = new tblAccount
                    {
                        Account = model.Account,
                        PassWord = pass,
                        EmailCode = emailCode,
                        StatusAccountId = 2,
                        Status = false,
                        GroupAcountId = 2,
                        CreatedDate = DateTime.Now,
                        CreatedBy = model.Account,
                        tblPerson = person
                    };
                    db.tblAccounts.Add(user);
                    db.SaveChanges();
                    var emailTo = new EmailTo
                    {
                        mailto = user.tblPerson.Email,
                        subject = "Yêu cầu kích hoạt tài khoản",
                        contents = "Mã kích hoạt tài khoản của bạn là : <h2>" + emailCode + "</h2>"
                    };
                    //string s= SendEmail.send_Mail(new EmailFrom(), emailTo);
                    return true;
                }
            }
            return false;
        }

        public static string ForgotPassword(ForgotPasswordModel model)
        {
            try
            {
                if (CheckEmail(model.Email))
                {
                    string _pass = CI.GetRandomString(10);
                    string pass = Md5.GetMd5Hash(_pass);

                    //var emailTo = new EmailTo
                    //{
                    //    mailto = model.Email,
                    //    subject = "Tài khoản",
                    //    contents = "Mật khẩu mới tài khoản của bạn là : <h2>" + _pass + "</h2>"
                    //};
                    //string s= SendEmail.send_Mail(new EmailFrom(), emailTo);

                    var m = db.tblAccounts.FirstOrDefault(a => a.tblPerson.Email.Equals(model.Email));
                    m.PassWord = pass;
                    m.StatusAccountId = 4;
                    db.SaveChanges();
                    return "Hệ thống đã gửi một Email tới :<h5 class='center'>" + model.Email + "</h5>Bạn vui lòng kiểm tra Email<br />";
                }
                return "Email không chính xác";
            }
            catch (Exception)
            {
                return "Có lỗi xảy ra, vui lòng thử lại sau";
            }
        }

        public static string ChangePassWord(ChangePasswordModel model)
        {
            try
            {
                string pass = Md5.GetMd5Hash(model.OldPassword);
                var m = db.tblAccounts.FirstOrDefault(a => a.Account.Equals(model.Account) && a.PassWord.Equals(pass));
                if (m != null)
                {
                    m.PassWord = Md5.GetMd5Hash(model.NewPassword);
                    if (m.StatusAccountId == 4)
                    {
                        m.StatusAccountId = 1;
                    }
                    m.ModifiedBy = model.Account;
                    m.ModifiedDate = DateTime.Now;
                    db.SaveChanges();
                    return "Đổi mật khẩu thành công!";
                }
                return "Mật khẩu cũ không chính xác";
            }
            catch (Exception)
            {
                return "Có lỗi xảy ra, vui lòng thử lại sau";
            }
        }
        public static bool CheckUserName(string account)
        {
            var m = db.tblAccounts.FirstOrDefault(a => a.Account.Equals(account));
            if (m != null) return true;
            return false;
        }

        public static bool CheckEmail(string email)
        {
            var m = db.tblPersons.FirstOrDefault(a => a.Email.Equals(email));
            if (m != null) return true;
            return false;
        }

        public static bool ConfirmEmail(ConfirmEmailModel model)
        {
            var m =
                db.tblAccounts.FirstOrDefault(
                    a => a.Account.Equals(model.Account) && a.EmailCode.Equals(model.EmailCode));
            if (m != null)
            {
                m.StatusAccountId = 3;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static AccountInfoModel AccountInfo(string account)
        {
            var m = Account(account);
            if (m != null)
            {
                return new AccountInfoModel
                {
                    Account = m.Account,
                    Image = (m.Image != null) ? "/Uploads/images/Avatar/" + m.Image : "/Images/Avatar/no_avatar.png",
                    LastName = m.tblPerson.LastName,
                    Name = m.tblPerson.Name,
                    DateOfBirth = m.tblPerson.DateOfBirth == null ? null : String.Format("{0:MM/dd/yyyy}", m.tblPerson.DateOfBirth),
                    Sex = m.tblPerson.Sex,
                    Address = m.tblPerson.Address,
                    PhoneNumber = m.tblPerson.PhoneNumber,
                    AccumulatedPoints = m.AccumulatedPoints ?? 0
                };
            }
            return null;
        }

        public static string EditAccountInfo(AccountInfoModel model)
        {
            try
            {
                var m = Account(model.Account);
                if (m != null)
                {
                    if (Uploader.HasFile(model.File))
                    {
                        m.Image = Uploader.SaveImg(model.File, "~/Uploads/images/Avatar/", model.Account);
                        m.ModifiedDate = DateTime.Now;
                        m.ModifiedBy = model.Account;
                    }
                    m.tblPerson.LastName = model.LastName;
                    m.tblPerson.Name = model.Name;
                    m.tblPerson.DateOfBirth = DateTime.Parse(model.DateOfBirth);
                    m.tblPerson.Sex = model.Sex;
                    m.tblPerson.Address = model.Address;
                    m.tblPerson.PhoneNumber = model.PhoneNumber;
                    m.tblPerson.ModifiedDate = DateTime.Now;
                    m.tblPerson.ModifiedBy = model.Account;
                    db.SaveChanges();
                    return "Cập nhật thành công!";
                }
                return "Có lỗi xảy ra, vui lòng thử lại sau!";
            }
            catch (Exception)
            {
                return "Có lỗi xảy ra, vui lòng thử lại sau!";
            }
        }
        public static int CheckStatusAccount(string account)
        {
            if (account != null)
            {
                var model = Account(account);
                if (model != null)
                {
                    return model.StatusAccountId;
                }
            }
            return 0;
        }

        public static tblAccount Account(string account)
        {
            var model = db.tblAccounts.FirstOrDefault(a => a.Account.Equals(account));
            return model;
        }

        public static int AccountId(string account)
        {
            var a = Account(account);
            if (a != null)
            {
                return a.Id;
            }
            return 0;
        }
    }

    public class LoginModel
    {
        [Display(Name = "Tài Khoản")]
        [Required(ErrorMessage = "Bạn chưa nhập tên tài khoản!", AllowEmptyStrings = false)]
        [RegularExpression(@"[A-Za-z0-9]{5,20}", ErrorMessage = "Tài khoản chỉ gồm 5-20 chữ cái hoặc số!")]
        public string Account { get; set; }

        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu!", AllowEmptyStrings = false)]
        [RegularExpression(@"[A-Za-z0-9]{5,20}", ErrorMessage = "Mật khẩu chỉ gồm 5-20 chữ cái hoặc số!")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
    }
    public class RegisterModel
    {
        [Display(Name = "Tài Khoản")]
        [Required(ErrorMessage = "Bạn chưa nhập tên tài khoản!", AllowEmptyStrings = false)]
        [RegularExpression(@"[A-Za-z0-9]{5,20}", ErrorMessage = "Tài khoản chỉ gồm 5-20 chữ cái hoặc số!")]
        [Remote("CheckUserName", "Account", ErrorMessage = "Tên đăng nhập đã tồn tại")]
        public string Account { get; set; }

        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu!", AllowEmptyStrings = false)]
        [RegularExpression(@"[A-Za-z0-9]{5,20}", ErrorMessage = "Mật khẩu chỉ gồm 5-20 chữ cái hoặc số!")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [Display(Name = "Nhập Lại Mật Khẩu")]
        [System.ComponentModel.DataAnnotations.Compare("PassWord", ErrorMessage = "Mật khẩu nhập lại không đúng")]
        [RegularExpression(@"[A-Za-z0-9]{5,20}", ErrorMessage = "Mật khẩu chỉ gồm 5-20 chữ cái hoặc số!")]
        [DataType(DataType.Password)]
        public string ConfirmPassWord { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Email!", AllowEmptyStrings = false)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Vui lòng điền một địa chỉ Email!")]
        [Remote("CheckEmail", "Account", ErrorMessage = "Email đã được sử dụng!")]
        public string Email { get; set; }

        [Display(Name = "Mã Kiểm Tra")]
        [Required(ErrorMessage = "Bạn chưa nhập mã CaptCha!", AllowEmptyStrings = false)]
        [RegularExpression(@"[A-Za-z0-9]{5}", ErrorMessage = "Vui lòng nhập mã CaptCha!")]
        public string CaptchaText { get; set; }
    }

    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "Bạn chưa nhập Email", AllowEmptyStrings = false)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Vui lòng điền một địa chỉ Email!")]
        public string Email { get; set; }

        [Display(Name = "Mã Kiểm Tra")]
        [Required(ErrorMessage = "Bạn chưa nhập mã CaptCha!", AllowEmptyStrings = false)]
        [RegularExpression(@"[A-Za-z0-9]{5}", ErrorMessage = "Vui lòng nhập mã CaptCha!")]
        public string CaptchaText { get; set; }
    }

    public class ChangePasswordModel
    {
        public string Account { get; set; }

        [Display(Name = "Mật Khẩu Cũ")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu!", AllowEmptyStrings = false)]
        [RegularExpression(@"[A-Za-z0-9]{5,20}", ErrorMessage = "Mật khẩu chỉ gồm 5-20 chữ cái hoặc số!")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "Mật Khẩu Mới")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu!", AllowEmptyStrings = false)]
        [RegularExpression(@"[A-Za-z0-9]{5,20}", ErrorMessage = "Mật khẩu chỉ gồm 5-20 chữ cái hoặc số!")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Nhập Lại Mật Khẩu")]
        [RegularExpression(@"[A-Za-z0-9]{5,20}", ErrorMessage = "Mật khẩu chỉ gồm 5-20 chữ cái hoặc số!")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "Mật khẩu nhập lại không đúng")]
        public string ConfirmPassword { get; set; }
    }

    public class ConfirmEmailModel
    {
        public string Account { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập mã xác nhận tài khoản!", AllowEmptyStrings = false)]
        [RegularExpression(@"[A-Za-z0-9]{16}", ErrorMessage = "Mã xác nhận gồm 16 kí tự chữ cái hoặc số!")]
        public string EmailCode { get; set; }
    }

    public class AccountInfoModel
    {
        public string Account { get; set; }

        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Vui lòng điền vào trường này!")]
        public string LastName { get; set; }
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Vui lòng điền vào trường này!")]
        public string Name { get; set; }
        [Display(Name = "Ngày Sinh")]
        [Required(ErrorMessage = "Vui lòng điền vào trường này!")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string DateOfBirth { get; set; }
        [Display(Name = "Giới Tính")]
        public Nullable<bool> Sex { get; set; }
        [Display(Name = "Địa Chỉ")]
        [Required(ErrorMessage = "Vui lòng điền vào trường này!")]
        public string Address { get; set; }
        [Display(Name = "Số Điện Thoại")]
        [Required(ErrorMessage = "Vui lòng điền vào trường này!")]
        [RegularExpression(@"[0-9]{10,11}", ErrorMessage = "Vui lòng điền đúng số điện thoại!")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Avatar")]
        public string Image { get; set; }

        [Display(Name = "Avatar")]
        public HttpPostedFileBase File { get; set; }

        [Display(Name = "Điểm Tích Lũy")]
        public int? AccumulatedPoints { get; set; }
    }
}