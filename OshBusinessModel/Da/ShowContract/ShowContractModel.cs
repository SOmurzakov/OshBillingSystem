using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da.Subscribers;
using OshBusinessModel.Da.Areas;
using OshBusinessModel.Da.Bills;

namespace OshBusinessModel.Da.ShowContract
{
    public class ShowContractModel
    {
        public SubscriberDetailsDa Subscriber { get; set; }
        public ContractDetailsDa Details { get; set; }
        public ContractOptionsDa[] Options { get; set; }
        public ContractMeterDa[] Meters { get; set; }
        public AreasDictionaryDa[] Areas { get; set; }

        public ContractChangeDetailsDa[] ChangeDetails { get; set; }
        public ContractParametersDa[] ChangeParameters { get; set; }

        public AddContractOptionDa[] PossibleOptions { get; set; }

        public ContractChangeMeterActionDa[] MetersActions { get; set; }
        public ContractChangeTariffOptionActionDa[] TariffOptionsActions { get; set; }
        public ContractChangeTariffOptionValueDa[] TariffValues { get; set; }
        public ContractChangeActionDa[] ChangeActions { get; set; }
        public ContractChangeMeterDetailsDa[] MetersDetails { get; set; }

        public ContractBillAmountDa[] Bills { get; set; }

        public Bill Bill { get; set; }

        public ContractSubagentDa[] Subagents { get; set; }

        public ContractTransactionDa[] Transactions { get; set; }

        public ContractChangeItemDa[] Changings
        {
            get
            {
                List<ContractChangeItemDa> changings = new List<ContractChangeItemDa>();

                changings.AddRange(ChangeDetails);
                changings.AddRange(ChangeParameters);
                changings.AddRange(MetersActions);
                changings.AddRange(TariffOptionsActions);
                changings.AddRange(TariffValues);
                changings.AddRange(ChangeActions);
                changings.AddRange(MetersDetails);

                changings.Sort((cA, cB) => cA.Compare(cB));

                return changings.ToArray();
            }
        }

        public IDateable[] Finances
        {
            get
            {
                List<IDateable> finances = new List<IDateable>();
                finances.AddRange(Bills);
                finances.AddRange(Transactions);
                finances.Sort((fA, fB) => fA.CompareTo(fB));

                return finances.ToArray();
            }
        }

        public MakePaymentUserDa[] MakePaymentUsers { get; set; }

        public ContractMeterValueDa[] MeterValues { get; set; }

        public ShowContractTariffDa[] Tariffs { get; set; }
    }
}
