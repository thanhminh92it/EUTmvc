using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using EUTmvc.Utils;

namespace EUTmvc.Models.Admin
{
    public class AdminAccountModel
    {
        static EUTContext db = new EUTContext();
        public static List<AdminAccountIndexAction> Index()
        {
            var a = db.tblAccounts;
            List<AdminAccountIndexAction> e = new List<AdminAccountIndexAction>();
            foreach (var item in a)
            {
                var q = new AdminAccountIndexAction();
                q.Account = item.Account;
                q.NamePerson = item.tblPerson.LastName + " " + item.tblPerson.Name;
                q.NameGroupAccount = item.tblGroupAcount.Name;
                q.Description = item.Description;
                e.Add(q);
            }
            return e;
        }

        public static void New(AdminAccountNewAction model)
        {
            var person = new tblPerson
            {
                Name = model.NamePerson,
                LastName = model.LastNamePerson,
                Code = model.Account,
                Email = model.Email
            };
            var user = new tblAccount
            {
                Account = model.Account,
                PassWord = Md5.GetMd5Hash(model.PassWord),
                StatusAccountId = 4,
                Status = true,
                GroupAcountId = model.GroupAcountId,
                PersonId = 1,
                Description = model.Description,
                CreatedDate = DateTime.Now,
                tblPerson = person
            };
            db.tblAccounts.Add(user);
            db.SaveChanges();
        }

        public static AdminAccountEditAction ViewEdit(string account)
        {
            var dataAccount = db.tblAccounts.FirstOrDefault(n => n.Account.Equals(account));
            var e = new AdminAccountEditAction
            {
                Account = dataAccount.Account,
                GroupAcountId = dataAccount.GroupAcountId,
                Description = dataAccount.Description
            };
            return e;
        }

        public static void SaveEdit(AdminAccountEditAction editModel)
        {
            tblAccount tblaccount = db.tblAccounts.Single(a => a.Account.Equals(editModel.Account));
            tblaccount.Description = editModel.Description;
            tblaccount.GroupAcountId = editModel.GroupAcountId;
            db.SaveChanges();
        }

        ///////////////////////////////////////////
        //SetPass
        public static AdminAccountSetPasswordAction ViewSetPassword(string account)
        {
            var dataAccount = db.tblAccounts.FirstOrDefault(n => n.Account.Equals(account));
            string DateOfBirth = null;
            if (dataAccount.tblPerson.DateOfBirth != null)
                DateOfBirth = String.Format("{0:dd/mm/yyy}", dataAccount.tblPerson.DateOfBirth);
            var e = new AdminAccountSetPasswordAction
            {
                Account = dataAccount.Account,
                NamePerson = dataAccount.tblPerson.LastName + " " + dataAccount.tblPerson.Name,
                NameGroupAccount = dataAccount.tblGroupAcount.Name,
                DataOfBirth = DateOfBirth,
            };
            return e;
        }
        public static void SubmitSetPassword(AdminAccountSetPasswordAction model)
        {
            var UpdatePassWord = db.tblAccounts.FirstOrDefault(a => a.Account.Equals(model.Account));
            UpdatePassWord.PassWord = Md5.GetMd5Hash("123456");
            UpdatePassWord.StatusAccountId = 4;
            db.SaveChanges();
        }

        ///////////////////////////////////////////
        //Delete
        public static AdminAccountDeleteAction ViewDelete(string account)
        {
            var dataAccount = db.tblAccounts.FirstOrDefault(n => n.Account.Equals(account));
            string sex = null;
            if (dataAccount.tblPerson.Sex != null)
            {
                if ((bool)dataAccount.tblPerson.Sex)
                    sex = "Nam";
                else sex = "Nữ";
            }
            else
                sex = "Chưa xác định";
            string DateOfBirth = null;
            if (dataAccount.tblPerson.DateOfBirth != null)
                DateOfBirth = String.Format("{0:dd/mm/yyy}", dataAccount.tblPerson.DateOfBirth);
            string CreateDate = null;
            if (dataAccount.CreatedDate != null)
                CreateDate = Convert.ToString(dataAccount.CreatedDate);
            var e = new AdminAccountDeleteAction
            {
                Account = dataAccount.Account,
                NamePerson = dataAccount.tblPerson.LastName + " " + dataAccount.tblPerson.Name,
                NameGroupAccount = dataAccount.tblGroupAcount.Name,
                DataOfBirth = DateOfBirth,
                CreateDate = CreateDate,
                Sex = sex,
                Email = dataAccount.tblPerson.Email
            };
            return e;
        }

        public static void SubmitDelete(AdminAccountDeleteAction model)
        {
            var deleteAccount = db.tblAccounts.FirstOrDefault(a => a.Account.Equals(model.Account));
            db.tblAccounts.Remove(deleteAccount);
            db.SaveChanges();
        }

        //Login

        public static bool SubmitLogin(AdminAccountLogin model)
        {
            string pas = Md5.GetMd5Hash(model.Password);
            var dataAccount = db.tblAccounts.FirstOrDefault(a => a.Account.Equals(model.Account) && a.GroupAcountId == 1 && a.PassWord.Equals(pas));
            if (dataAccount != null)
                return true;
            else
                return false;
        }
    }
    public class AdminAccountIndexAction
    {
        [Display(Name = "Tài Khoản")]
        public string Account { get; set; }

        [Display(Name = "Người dùng")]
        public string NamePerson { get; set; }

        [Display(Name = "Nhóm tài khoản")]
        public string NameGroupAccount { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }

    public class AdminAccountEditAction
    {
        [Display(Name = "Tài Khoản")]
        public string Account { get; set; }

        [Display(Name = "Nhóm tài khoản")]
        [Required(ErrorMessage = "Bạn chưa chọn nhóm tài khoản!", AllowEmptyStrings = false)]
        public int GroupAcountId { get; set; }
        public List<tblGroupAcount> ListGroupAccount
        {
            get
            {
                EUTContext db = new EUTContext();
                return db.tblGroupAcounts.ToList();
            }
        }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }

    public class AdminAccountNewAction
    {
        [Display(Name = "Tài Khoản")]
        [Required(ErrorMessage = "Bạn chưa nhập tên tài khoản!", AllowEmptyStrings = false)]
        [RegularExpression(@"[A-Za-z0-9]{5,10}", ErrorMessage = "Tài khoản chỉ gồm 5-10 chữ cái hoặc số!")]
        [Remote("CheckUserName", "Account", ErrorMessage = "Tên đăng nhập đã tồn tại")]
        public string Account { get; set; }

        [Display(Name = "Tên Người Dùng")]
        [Required(ErrorMessage = "Bạn chưa nhập tên", AllowEmptyStrings = false)]
        public string NamePerson { get; set; }

        [Display(Name = "Họ Người Dùng")]
        [Required(ErrorMessage = "Bạn chưa nhập họ", AllowEmptyStrings = false)]
        public string LastNamePerson { get; set; }

        [Display(Name = "Nhóm tài khoản")]
        [Required(ErrorMessage = "Bạn chưa chọn nhóm tài khoản!", AllowEmptyStrings = false)]
        public int GroupAcountId { get; set; }
        public List<tblGroupAcount> ListGroupAccount
        {
            get
            {
                EUTContext db = new EUTContext();
                return db.tblGroupAcounts.ToList();
            }
        }

        [Required(ErrorMessage = "Bạn chưa nhập Email!", AllowEmptyStrings = false)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Vui lòng điền một địa chỉ Email!")]
        [Remote("CheckEmail", "Account", ErrorMessage = "Email đã được sử dụng!")]
        public string Email { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        public string PassWord
        {
            get
            {
                return "123456";
            }
        }
    }
    public class AdminAccountDeleteAction
    {
        [Display(Name = "Tài Khoản")]
        public string Account { get; set; }

        [Display(Name = "Người dùng")]
        public string NamePerson { get; set; }

        [Display(Name = "Ngày Sinh")]
        public string DataOfBirth { get; set; }

        [Display(Name = "Nhóm tài khoản")]
        public string NameGroupAccount { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Ngày tạo")]
        public string CreateDate { get; set; }

        [Display(Name = "Giới tính")]
        public string Sex { get; set; }
    }
    public class AdminAccountSetPasswordAction
    {
        [Display(Name = "Tài Khoản")]
        public string Account { get; set; }

        [Display(Name = "Người dùng")]
        public string NamePerson { get; set; }

        [Display(Name = "Ngày Sinh")]
        public string DataOfBirth { get; set; }

        [Display(Name = "Nhóm tài khoản")]
        public string NameGroupAccount { get; set; }
    }
    public class AdminAccountLogin
    {
        [Display(Name = "Tài Khoản")]
        [Required(ErrorMessage = "Bạn chưa nhập tên tài khoản!", AllowEmptyStrings = false)]
        [RegularExpression(@"[A-Za-z0-9]{5,10}", ErrorMessage = "Tài khoản chỉ gồm 5-10 chữ cái hoặc số!")]
        public string Account { get; set; }

        [Display(Name = "Tài Khoản")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu!", AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}