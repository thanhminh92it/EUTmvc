using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
namespace EUTmvc.Models.Admin
{
    public class AdminPersonModel
    {
        static EUTContext db = new EUTContext();
        public static List<AdminPersonIndexAction> IndexPerson()
        {
            var listPerson = db.tblPersons;
            List<AdminPersonIndexAction> e = new List<AdminPersonIndexAction>();
            foreach (var item in listPerson)
            {   
                //
                string sex = null;
                if (item.Sex != null)
                {
                    if ((bool)item.Sex)
                        sex = "Nam";
                    else sex = "Nữ";
                }
                else
                    sex = "Chưa xác định";
                string dateOfBirth = null;
                if (item.DateOfBirth != null)
                {
                    dateOfBirth = String.Format("{0:dd/MM/yyy}", item.DateOfBirth);
                }
                var q = new AdminPersonIndexAction();
                q.Id = item.Id;
                q.NamePerson = item.LastName + " " + item.Name;
                q.Sex = sex;
                q.DateOfBirth = dateOfBirth;
                q.Address = item.Address;
                q.PhoneNumber = item.PhoneNumber;
                q.Email = item.Email;
                e.Add(q);
            }
            return e;
        }
        public static AdminPersonEditAction ViewEdit(int id)
        {
            var dataPerson = db.tblPersons.Find(id);
            AdminPersonEditAction e = null;
            string dateOfBirth = null;
            if (dataPerson.DateOfBirth != null)
            {
                dateOfBirth = String.Format("{0:yyyy-MM-dd}", dataPerson.DateOfBirth);
            }
            else
            {
               dateOfBirth = "1990-01-01";
            }
            if (dataPerson.Sex != null)
            {
                e = new AdminPersonEditAction
                {

                    Id = dataPerson.Id,
                    NamePerson = dataPerson.Name,
                    LastNamePerson = dataPerson.LastName,
                    Sex = (bool)dataPerson.Sex,
                    DateOfBirth = dateOfBirth,
                    Address = dataPerson.Address,
                    PhoneNumber = dataPerson.PhoneNumber
                };
            }
            else
            {
                e = new AdminPersonEditAction
                {

                    Id = dataPerson.Id,
                    NamePerson = dataPerson.Name,
                    LastNamePerson = dataPerson.LastName,
                    DateOfBirth = dateOfBirth,
                    Address = dataPerson.Address,
                    PhoneNumber = dataPerson.PhoneNumber
                };
            }
            return e;
        }

        public static void SaveEdit(AdminPersonEditAction model)
        {
            tblPerson dataPerson = db.tblPersons.Find(model.Id);
            dataPerson.Name = model.NamePerson;
            dataPerson.LastName = model.LastNamePerson;
            if (model.Sex != null)
                dataPerson.Sex = model.Sex;
            DateTime dt = DateTime.ParseExact(model.DateOfBirth, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            dataPerson.DateOfBirth = dt;
            dataPerson.PhoneNumber = model.PhoneNumber;
            dataPerson.Address = model.Address;
            db.SaveChanges();
        }

        public static AdminPersonDeleteAction ViewDelete(int id)
        {
            tblPerson dataPerson = db.tblPersons.Find(id);
            //if (dataPerson != null)
            //{
            //    tblAccount dataAccount = db.tblAccounts.FirstOrDefault(a => a.PersonId == dataPerson.Id);
            //    if()
            //}
            string sex = null;
            if (dataPerson.Sex != null)
            {
                if ((bool)dataPerson.Sex)
                    sex = "Nam";
                else sex = "Nữ";
            }
            else
                sex = "Chưa xác định";
            string dateOfBirth = null;
            if (dataPerson.DateOfBirth != null)
            {
                dateOfBirth = String.Format("{0:dd/MM/yyy}", dataPerson.DateOfBirth);
            }
            var q = new AdminPersonDeleteAction();
            q.Id = dataPerson.Id;
            q.NamePerson = dataPerson.LastName + " " + dataPerson.Name;
            q.Sex = sex;
            q.DateOfBirth = dateOfBirth;
            q.Address = dataPerson.Address;
            q.PhoneNumber = dataPerson.PhoneNumber;
            q.Email = dataPerson.Email;
            return q;
        }

        public static void SubmitDelete(AdminPersonDeleteAction model)
        {
            tblPerson dataPerson = db.tblPersons.Find(model.Id);
            if (dataPerson != null)
            {
                tblAccount dataAccount = db.tblAccounts.FirstOrDefault(a => a.PersonId == dataPerson.Id);
                if (dataAccount != null)
                {
                    db.tblAccounts.Remove(dataAccount);
                    db.tblPersons.Remove(dataPerson);
                    db.SaveChanges();
                }
            }
        }
    }
    public class AdminPersonIndexAction
    {
        public int Id { get; set; }

        [Display(Name="Người dùng")]
        public string NamePerson { get; set; }

        [Display(Name = "Giới tính")]
        public string Sex { get; set; }

        [Display(Name = "Ngày sinh")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
    public class AdminPersonEditAction
    {
        public int Id { get; set; }

        [Display(Name = "Tên Người dùng")]
        [Required(ErrorMessage = "Bạn chưa nhập tên!", AllowEmptyStrings = false)]
        public string NamePerson { get; set; }

        [Display(Name = "Họ Người dùng")]
        [Required(ErrorMessage = "Bạn chưa nhập họ!", AllowEmptyStrings = false)]
        public string LastNamePerson { get; set; }

        [Display(Name = "Giới tính")]
        public bool Sex { get; set; }

        [Display(Name = "Ngày sinh")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
    }

    public class AdminPersonDeleteAction
    {
        public int Id { get; set; }

        [Display(Name = "Người dùng")]
        public string NamePerson { get; set; }

        [Display(Name = "Giới tính")]
        public string Sex { get; set; }

        [Display(Name = "Ngày sinh")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}