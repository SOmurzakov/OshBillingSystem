using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Data
{
    public class Permission
    {

        public static Permission SettingsChange = new Permission("Settings.Change", UserType.Administrator);
        public static Permission SettingsGiveVisa = new Permission("Settings.GiveVisa", UserType.Director);
        public static Permission UsersCreate = new Permission("Users.Create", UserType.Administrator);
        public static Permission UsersChangeDetails = new Permission("Users.ChangeDetails", UserType.Administrator);
        public static Permission UsersSetRole = new Permission("Users.SetRole", UserType.Director);
        public static Permission UsersChangePassword = new Permission("Users.ChangePassword", UserType.Administrator);
        public static Permission UsersBlock = new Permission("Users.Block", UserType.Administrator, UserType.Director);
        public static Permission TariffsChangePrice = new Permission("Tariffs.ChangePrice", UserType.Director);
        public static Permission AreasCreate = new Permission("Areas.Create", UserType.Administrator, UserType.Director);
        public static Permission ContractsGiveVisa = new Permission("Contracts.GiveVisa", UserType.Director);
        public static Permission SubscribersChangeInfo = new Permission("Subscribers.ChangeInfo", UserType.Controller, UserType.CustomerCare);
        public static Permission ContractsChange = new Permission("Contracts.Change", UserType.Controller, UserType.CustomerCare);
        public static Permission SubagentsChange = new Permission("Subagents.Change", UserType.Administrator);
        public static Permission SubagentsPopup = new Permission("Subagents.Popup", UserType.Accountant);
        public static Permission ClosePeriod = new Permission("ClosingPeriods.Close", UserType.Director);
        public static Permission MetersSetValues = new Permission("Meters.SetValues", UserType.Controller, UserType.Cashier, UserType.CustomerCare);
        public static Permission ClosePeriodForSubscriber = new Permission("ClosingPeriods.CloseForSubscriber", UserType.Accountant, UserType.Controller, UserType.CustomerCare);

        public static Permission SpecialTransactions = new Permission("Contracts.SpecialTransactions", UserType.Controller, UserType.Accountant, UserType.CustomerCare);
        public static Permission TransactionsGiveVisa = new Permission("Transactions.GiveVisa", UserType.Director);

        public string Action { get; private set; }
        public string[] Users { get; private set; }

        public Permission(string action, params UserType[] users)
        {
            Action = action;
            Users = users.Select(u => u.SemanticId).ToArray();
        }



    }
}
