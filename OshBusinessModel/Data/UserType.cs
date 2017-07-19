using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Data
{
    public class UserType
    {
        public static UserType Administrator = new UserType("admin", "Администратор", "Администраторы", "Admin");
        public static UserType Cashier = new UserType("cashier", "Кассир", "Кассиры", "Cashier");
        public static UserType Accountant = new UserType("accountant", "Бухгалтер", "Бухгалтера", "Accountant");
        public static UserType Controller = new UserType("controller", "Контроллер", "Контроллеры", "Controller");
        public static UserType CustomerCare = new UserType("custcare", "Абон отдел", "Абон отдел", "CustomerCare");
        public static UserType AreaHead = new UserType("areahead", "Начальник участка", "Начальники участков", "Areahead");
        public static UserType Director = new UserType("director", "Руководство", "Руководство", "Director");
        public static UserType Unknown = new UserType("unknown", "Неизвестно", "Неизвестно", "");

        public static readonly UserType[] UserTypes = new[] {Administrator, Cashier, Controller, CustomerCare, Director, Accountant};

        public static UserType GetUserTypeById(string semanticId)
        {
            var userType = UserTypes.FirstOrDefault(t => t.SemanticId == semanticId);
            return userType ?? Unknown;
        }

        public string SemanticId { get; private set; }
        public string Name { get; private set; }
        public string Plural { get; private set; }
        public string AspController { get; private set; }

        private UserType(string semanticId, string name, string plural, string aspController)
        {
            SemanticId = semanticId;
            Name = name;
            Plural = plural;
            AspController = aspController;
        }
    }
}
