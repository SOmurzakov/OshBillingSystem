using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da;

namespace OshBusinessLogic.Providers
{
    public class OrdersProvider
    {
        public LastOrderDa GetLastOrder()
        {
            return NativeSql.Exec("orders_getLastOrder").OneRow<LastOrderDa>();
        }

        public bool CloseMonth(int userId)
        {
            try
            {
                NativeSql.Exec("orders_closeMonth", new {userId,});
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateOrder(int userId)
        {
            try
            {
                NativeSql.Exec("orders_create", new {userId,});
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
    }
}
