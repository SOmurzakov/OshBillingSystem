using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OshChannel.Helpers
{
    public static class GeneralHelper
    {
        public static void FillViewBag(HttpContextBase context, dynamic viewBag)
        {
            viewBag.Login = context.User.Identity.Name;
            viewBag.Authorized = !string.IsNullOrWhiteSpace(viewBag.Login) ? (object)true : null;
        }
    }
}