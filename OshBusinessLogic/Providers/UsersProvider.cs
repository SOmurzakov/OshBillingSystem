using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da;
using OshBusinessModel.Da.Users;

namespace OshBusinessLogic.Providers
{
    public class UsersProvider
    {
        public string UserExistsAndReturnRole(string login, string password)
        {
            var exists = NativeSql.Exec("users_ifExists", new {Login = login, Password = password,}).OneRow<UserExistsDa>();
            return exists != null ? exists.Role ?? "" : "";
        }

        public UserDa GetUserByLogin(string login)
        {
            return NativeSql.Exec("users_getByLogin", new {Login = login,}).OneRow<UserDa>();
        }

        public UserDictionaryDa[] GetUsersDictionary()
        {
            return NativeSql.Exec("users_getDictionary").Rows<UserDictionaryDa>();
        }

        public UserDetailsModel GetUserDetails(int userId)
        {
            var tables = NativeSql.ExecMultiple("users_getDetails", new {userId,});
            var details = tables[0].OneRow<UserDetailsDa>();

            return details == null
                       ? null
                       : new UserDetailsModel()
                             {
                                 Details = details,
                                 Actions = tables[1].Rows<UserActionDa>(), 
                                 DetailsChanges = tables[2].Rows<UserDetailsChangeDa>(),
                                 Roles = tables[3].Rows<UserRoleChangeDa>(),
                                 PasswordChanges = tables[4].Rows<UserChangePasswordDa>(),
                             };
        }

        public CreateUserResultDa CreateUser(int userId, string login, string password, string role, string name, string passport, string address, string phone)
        {
            return
                NativeSql.Exec("users_create",
                               new
                                   {
                                       userId,
                                       login,
                                       password,
                                       role,
                                       name,
                                       passport,
                                       address,
                                       phone,
                                   }).OneRow<CreateUserResultDa>();
        }

        public void ChangeUserDetails(int changedUserId, int  userId, string name, string passport, string address, string phone)
        {
            NativeSql.Exec("users_changeDetails", new {userId, name, passport, address, phone, changedUserId,});
        }

        public void SetRole(int changedUserId, int userId, string role)
        {
            NativeSql.Exec("users_setRole", new {userId, role, changedUserId,});
        }

        public void ChangePassword(int changedUserId, int userId, string password)
        {
            NativeSql.Exec("users_changePassword", new {userId, password, changedUserId,});
        }

        public void Enable(int changedUserId, int userId)
        {
            NativeSql.Exec("users_enable", new {userId, changedUserId,});
        }

        public void Disable(int changedUserId, int userId, string remarks)
        {
            NativeSql.Exec("users_disable", new {userId, remarks, changedUserId,});
        }
    }
}
