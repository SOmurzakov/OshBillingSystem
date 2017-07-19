using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da;
using OshBusinessModel.Da.Subagents;
using OshBusinessModel.Da.SubagentsBillingPeriods;

namespace OshBusinessLogic.Providers
{
    public class SubagentsProvider
    {
        public SubagentsDictionaryDa[] GetSubagentsDictionary()
        {
            var subagents = NativeSql.Exec("subagents_getDictionary").Rows<SubagentsDictionaryDa>();
            return subagents;
        }

        public TransactionDa[] GetLastTransactions()
        {
            return NativeSql.Exec("subagents_getLastTransactions").Rows<TransactionDa>();
        }

        public bool RegisterTransaction(int subagentId, double amount, int contractId, int userId)
        {
            try
            {
                NativeSql.Exec("subagents_registerTransaction", new {subagentId, amount, contractId, userId,});
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Create(string name, string remarks, bool hasBalance, double currentBalance)
        {
            NativeSql.Exec("subagents_create", new {name, remarks, hasBalance, currentBalance,});
        }

        public void RegisterPopup(int userId, int subagentId, double amount, string remarks)
        {
            NativeSql.Exec("subagents_registerPopup", new {userId, subagentId, amount, remarks});
        }

        public SubagentTransactionsModel GetTransactions(int subagentId)
        {
            var tables = NativeSql.ExecMultiple("subagents_getTransactions", new {subagentId,});
            var model = tables[0].OneRow<SubagentTransactionsModel>();
            model.Transactions = tables[1].Rows<SubagentTransactionDa>();
            return model;
        }

        public SubagentsBillingPeriodsModel GetBillingPeriodsModel(int periodId)
        {
            var tables = NativeSql.ExecMultiple("accountant_getSubagentsStatisticsByBillingPeriods", new {periodId,});

            var model = tables[0].OneRow<SubagentsBillingPeriodsModel>();

            if (model != null)
            {
                model.Periods = tables[1].Rows<BillingPeriodDa>();
                model.Subagents = tables[2].Rows<SubagentDa>();
            }

            return model;
        }

        public void ChangeInfo(int id, string name)
        {
            NativeSql.Exec("subagents_changeInfo", new {id, name,});
        }
    }
}
