using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OshBusinessModel.Da;
using OshBusinessLogic.Providers;
using OshBusinessModel.Data;

namespace OshChannel.Helpers
{
    public static class Auth
    {

        public static bool Authenticated 
        { 
            get { return User != null; }
        }

        public static string Login 
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }

        public static UserDa User
        {
            get
            {
                if (string.IsNullOrEmpty(Login))
                {
                    return null;
                }
                else
                {
                    var items = HttpContext.Current.Items;

                    if (!items.Contains("User"))
                    {
                        items.Add("User", new UsersProvider().GetUserByLogin(Login));
                    }

                    return (UserDa) items["User"];
                }
            }
        }

        public static bool IsAdmin
        {
            get { return Authenticated && User != null && User.Role == UserType.Administrator.SemanticId; }
        }

        public static bool HasPermission(Permission p)
        {
            return
                Authenticated
                &&
                User != null
                &&
                p.Users.Contains(User.Role);
        }
    }
}