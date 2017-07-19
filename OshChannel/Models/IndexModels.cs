using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OshChannel.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }

    public class SearchContractModel
    {
        public string Key { get; set; }
        public string Street { get; set;  }
        public string Building { get; set; }
        public string Appartment { get; set; }
        public string AreaName { get; set; }
        public string ContractName { get; set; }
        public string ControllerName { get; set; }
        public string Bill { get; set; }
    }

    public class GiveVisaModel
    {
        public int ChangeId { get; set; }
        public string Subcategory { get; set; }
    }
}