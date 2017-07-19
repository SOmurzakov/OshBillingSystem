using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da;
using OshBusinessModel.Da.Subscribers;

namespace OshBusinessLogic.Providers
{
    public class SubscribersProvider
    {

        public SubscriberDetailsModel GetSubscriberDetails(int subscriberId)
        {
            var tables = NativeSql.ExecMultiple("subscribers_getDetails", new {subscriberId,});

            var subscriber = tables[0].OneRow<SubscriberDetailsDa>();

            if (subscriber == null)
            {
                return null;
            }

            var changes = tables[1].Rows<SubscriberChangeDa>();
            var contracts = tables[2].Rows<SubscriberContractDa>();
            var bills = new BillsProvider().ComposeBills(tables, 3);

/*
            foreach (var bill in bills)
            {
                bill.Meters = billsMeters.Where(m => m.BillId == bill.BillId).ToArray();
            }

            foreach (var contract in contracts)
            {
                contract.Meters = meters.Where(m => m.ContractId == contract.ContractId).ToArray();
                contract.Bill = bills.FirstOrDefault(b => b.ContractId == contract.ContractId);
            }

            if (subscriber != null)
            {
                subscriber.Contracts = contracts;
            }
*/

            return subscriber == null
                       ? null
                       : new SubscriberDetailsModel() {Details = subscriber, Changes = changes, Contracts = contracts, Bills = bills};
        }

        public SubscriberDictionaryDa GetSubscribersDictionary(string type, int itemsPerPage, int pageNumber, string firstLetter)
        {
            var tables = NativeSql.ExecMultiple("subscribers_getDictionary", new {type, itemsPerPage, pageNumber, firstLetter, });

            var da = tables[0].OneRow<SubscriberDictionaryDa>();
            da.Subscribers = tables[1].Rows<SubscribersDictionaryItemDa>();
            da.Streets = new StreetsProvider().GetAllStreets();

            return da;
        }

        public void ChangeInfo(int userId, int subscriberId, string name, string passportNumber, string passportWhere, DateTime? passportDate, string addressStreet, string addressBuilding, string addressFlat, string phone, string inn, string ugkns, string mfo, bool invoice, string changeRemarks
            , string ugknsName, string bankCode, string bankName, string bankAccount)
        {
            NativeSql.Exec("subscribers_changeInfo",
                           new
                               {
                                   userId, subscriberId, 
                                   name, passportNumber, passportWhere, passportDate,
                                   addressStreet, addressBuilding, addressFlat, phone,
                                   inn, ugkns, mfo, invoice,
                                   changeRemarks, 
                                   ugknsName, bankCode, bankName, bankAccount
                               });
        }

        public void VisaApprove(int changeId, int userId)
        {
            NativeSql.Exec("subscribers_visaApprove", new { changeId, userId, });
        }

        public void VisaDecline(int changeId, int userId)
        {
            NativeSql.Exec("subscribers_visaDecline", new { changeId, userId, });
        }

        public void ClosePeriod(int userId, int subscriberId)
        {
            NativeSql.Exec("billing_closePeriodForSubscriber", new { userId, subscriberId });
        }
        public void CancelClosePeriod(int userId, int subscriberId)
        {
            NativeSql.Exec("billing_cancelClosePeriodForSubscriber", new { userId, subscriberId });
        }
    }
}
