using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OshChannel.Models
{
    public class CreateUserAjaxModel
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public string Passport { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class UserChangeDetailsAjaxModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Passport { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    public class UserSetRoleAjaxModel
    {
        public int UserId { get; set; }
        public string Role { get; set; }
    }

    public class UserChangePasswordAjaxModel
    {
        public int UserId { get; set; }
        public string Password { get; set; }
    }

    public class UserDisableAjaxModel
    {
        public int UserId { get; set; }
        public string Remarks { get; set; }
    }

    public class UserEnableAjaxModel
    {
        public int UserId { get; set; }
    }
}