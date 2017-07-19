using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da;
using OshBusinessModel.Da.Areas;
using OshBusinessModel.Da.BulkPayments;
using OshBusinessModel.Da.ContractStatement;
using OshBusinessModel.Da.Debtors;
using OshBusinessModel.Da.Meters;
using OshBusinessModel.J2MeDb.Dto;
using OshBusinessModel.Da.CreateContract;
using OshBusinessModel.Da.Subscribers;
using OshBusinessModel.Da.ShowContract;
using OshBusinessModel.Da.Mobiles;
using OshBusinessModel.Da.SubagentsBillingPeriods;

namespace OshBusinessLogic.Providers
{
    public class ContractsProvider
    {
        public ContractsSearchResult Search(string key, string street, string building, string appartment, string areaName, string contractName, string controllerName, string bill)
        {
            key = key.Trim();
            street = street.Trim();
            building = building.Trim();
            appartment = appartment.Trim();
            areaName = areaName.Trim();
            contractName = contractName.Trim();
            controllerName = controllerName.Trim();
            bill = bill.Trim();
            
            var tables = NativeSql.ExecMultiple("contracts_search", new {key, street, building, appartment, areaName, contractName, controllerName, receiptNo = bill});

            var result = new ContractsSearchResult
            {
                Key = key,
                Street = street,
                Streets = new StreetsProvider().GetAllStreets(),
                Building = building,
                Appartment = appartment,
                Area = areaName,
                ContractName = contractName,
                ControllerName = controllerName,
                Bill = bill,
                Contracts = tables.Length > 0 ? tables[0].Rows<ContractSearchResultDa>() : new ContractSearchResultDa[] {},
                Subscribers = tables.Length > 1 ? tables[1].Rows<SubscriberSearchResultDa>() : new SubscriberSearchResultDa[] {},
            };

            return result;
            
        }

        public ShowContractModel GetContract(int contractId)
        {
            var tables = NativeSql.ExecMultiple("contracts_getDetails", new {contractId,});

            var subscriber = tables[0].OneRow<SubscriberDetailsDa>();

            return subscriber != null
                       ? new ShowContractModel()
                             {
                                 Subscriber = subscriber,
                                 Details = tables[1].OneRow<ContractDetailsDa>(),
                                 Options = tables[2].Rows<ContractOptionsDa>(),
                                 Meters = tables[3].Rows<OshBusinessModel.Da.ShowContract.ContractMeterDa>(),
                                 Areas = tables[4].Rows<AreasDictionaryDa>(),
                                 ChangeDetails = tables[5].Rows<ContractChangeDetailsDa>(),
                                 ChangeParameters = tables[6].Rows<ContractParametersDa>(),
                                 PossibleOptions = tables[7].Rows<AddContractOptionDa>(),
                                 MetersActions = tables[8].Rows<ContractChangeMeterActionDa>(),
                                 TariffOptionsActions = tables[9].Rows<ContractChangeTariffOptionActionDa>(),
                                 TariffValues = tables[10].Rows<ContractChangeTariffOptionValueDa>(),
                                 ChangeActions = tables[11].Rows<ContractChangeActionDa>(),
                                 Bill = new BillsProvider().ComposeBill(tables, 12),
                                 Subagents = tables[17].Rows<ContractSubagentDa>(),
                                 Transactions = tables[18].Rows<ContractTransactionDa>(),
                                 Bills = tables[19].Rows<ContractBillAmountDa>(),
                                 MetersDetails = tables[20].Rows<ContractChangeMeterDetailsDa>(),
                                 MakePaymentUsers = tables[21].Rows<MakePaymentUserDa>(),
                                 MeterValues = tables[22].Rows<ContractMeterValueDa>(),
                                 Tariffs = tables[23].Rows<ShowContractTariffDa>(),
                             }
                       : null;
        }

        public void MakePayment(int contractId, double amount, int userId, int subagentId, int registeredUserId, string receiptNo)
        {
            NativeSql.Exec("billing_makePayment",
                           new {contractId, amount, userId, subagentId, registeredUserId, receiptNo,});
        }

        public JsonMeterDa[] GetMetersValues(int contractId)
        {
            return NativeSql.Exec("contracts_getMetersValues", new {contractId,}).Rows<JsonMeterDa>();
        }

        public ResultDa SetMetersValues(int userId, DateTime dateAsOf, SetMetersValuesDa[] meters, string meterValueType)
        {
            return NativeSql.Exec("contracts_setMetersValues", new { userId, dateAsOf, meters, meterValueType}).OneRow<ResultDa>();
        }

        public DebtorsModel GetDebtors(int threshold, int startPeriodId, int endPeriodId)
        {
            var tables =
                NativeSql.ExecMultiple("contracts_getDebtors", new {startPeriodId, endPeriodId, threshold,});

            var model = tables[0].OneRow<DebtorsModel>();

            model.BillingPeriods = tables[1].Rows<BillingPeriodDa>();

            if (model.BillingPeriods.Length == 0)
            {
                return null;
            }

            model.Debtors = tables[2].Rows<DebtorDa>();

            return model;
        }

        public CreateContractModel GetDataForCreateContract(int subscriberId)
        {
            var tables = NativeSql.ExecMultiple("contracts_getDataForCreating", new {subscriberId,});
            var model =
                new CreateContractModel()
                    {
                        Areas = tables[0].Rows<AreasDictionaryDa>(),
                        Subscriber = tables[1].OneRow<CreateContractSubscriberDa>(),
                        Tariffs = tables[2].Rows<CreateContractTariffDa>(),
                        Options = tables[3].Rows<CreateContractTariffOptionDa>(),
                        Streets = tables[4].Rows<StreetWrapper>().Select(sw => sw.Street).ToArray(),
                    };

            return model;
        }

        public CreateContractDa CreateWithSubscriber(
                string type,
                int userId,
                string subscriberName, string subscriberPassportNumber, string subscriberPassportWhere, DateTime? subscriberPassportDate,
                string subscriberAddressStreet, string subscriberAddressBuilding, string subscriberAddressFlat, string subscriberPhone,
                string subscriberInn, string subscriberUgkns, string subscriberMfo, bool subscriberInvoice,

                string contractName,
                int contractAreaId, string contractAddressStreet, string contractAddressBuilding, string contractAddressFlat, string contractPhone,
                string tariffId, int peopleRegistered,
                double fixedConsumption,

                CreateContractMeterInfoDa[] meters,
                CPCAM_TariffOptionDa[] options,
                double registrationDebt,

                int archiveId, string budgetType, bool hasSewage, double allowance, string allowanceReason,
                double fixedConsumptionSewage,

                string subscriberUgknsName, string subscriberBankCode, string subscriberBankName, string subscriberBankAccount,
                DateTime registrationDate
            )
        {
            var res = NativeSql.Exec
                (
                    "contracts_createWithSubscriber",
                    new
                        {
                            userId,
                            type,
                            subscriberName, subscriberPassportNumber, subscriberPassportWhere, subscriberPassportDate,
                            subscriberAddressStreet, subscriberAddressBuilding, subscriberAddressFlat, subscriberPhone,
                            subscriberInn, subscriberUgkns, subscriberMfo, subscriberInvoice,

                            contractName,
                            contractAreaId, contractAddressStreet, contractAddressBuilding, contractAddressFlat, contractPhone,
                            tariffId, peopleRegistered, fixedConsumption,
                            meters,
                            options,
                            registrationDebt,

                            archiveId, budgetType, hasSewage, allowance, allowanceReason,
                            fixedConsumptionSewage, 

                            subscriberUgknsName, subscriberBankCode, subscriberBankName, subscriberBankAccount,

                            registrationDate
                        }
                )
                .OneRow<CreateContractDa>();

            return res;
        }

        public void ChangeDetails(int userId, int contractId, string contractName, int areaId, string addressStreet, string addressBuilding, string addressFlat, string phone, string changeRemarks, int archiveId, string budgetType)
        {
            NativeSql.Exec("contracts_changeDetails",
                           new
                               {
                                   userId, contractId, contractName, areaId, addressStreet, addressBuilding, addressFlat, phone, changeRemarks, archiveId, budgetType
                               });
        }

        public void VisaApprove(int changeId, int userId, string subcategory)
        {
            NativeSql.Exec("contracts_visaApprove", new {changeId, userId, subcategory,});
        }

        public void VisaDecline(int changeId, int userId, string subcategory)
        {
            NativeSql.Exec("contracts_visaDecline", new { changeId, userId, subcategory, });
        }

        public void ChangeParameters(int userId, int contractId, int peopleRegistered, double fixedConsumption, string changeRemarks, bool hasSewage, double allowance, string allowanceReason, double fixedConsumptionSewage)
        {
            NativeSql.Exec("contracts_changeParameters",
                           new {userId, contractId, peopleRegistered, fixedConsumption, changeRemarks, hasSewage, allowance, allowanceReason, fixedConsumptionSewage});
        }

        public AddMeterResultDa AddMeter(int userId, int contractId, string serialNumber, double value, string changeRemarks)
        {
            return NativeSql.Exec("contracts_addMeter", new {userId, contractId, serialNumber, value, changeRemarks,}).OneRow<AddMeterResultDa>();
        }

        public AddTariffOptionResultDa AddTariffOption(int userId, int contractId, string semanticId, double value, string changeRemarks, bool sewage)
        {
            return
                NativeSql.Exec("contracts_addTariffOption", new {userId, contractId, semanticId, value, changeRemarks, sewage})
                    .OneRow<AddTariffOptionResultDa>();
        }

        public void ChangeTariffOptionValue(int userId, int tariffOptionId, double value, string changeRemarks, bool sewage)
        {
            NativeSql.Exec("contracts_changeTariffOptionValue", new {userId, tariffOptionId, value, changeRemarks, sewage});
        }

        public void RegisterTariffOptionAction(int userId, int tariffOptionId, bool enable, string changeRemarks)
        {
            NativeSql.Exec("contracts_registerTariffOptionAction", new {userId, tariffOptionId, enable, changeRemarks,});
        }

        public void RegisterContractAction(int userId, int contractId, bool enable, string changeRemarks)
        {
            NativeSql.Exec("contracts_registerAction", new {userId, contractId, enable, changeRemarks});
        }

        public CreateContractDa AddContractToSubscriber(
                int userId, int subscriberId, string contractName, 
                int contractAreaId, string contractAddressStreet, string contractAddressBuilding, 
                string contractAddressFlat, string contractPhone, string tariffId, int peopleRegistered, 
                double fixedConsumption, CreateContractMeterInfoDa[] meters, CPCAM_TariffOptionDa[] options, string registrationDebt,
                int archiveId, string budgetType, bool hasSewage, double allowance, string allowanceReason,
                double fixedConsumptionSewage,
                DateTime registrationDate
            )
        {
            var res = NativeSql.Exec
                (
                    "contracts_addToSubscriber",
                    new
                    {
                        userId,
                        subscriberId,
                        contractName,
                        contractAreaId,
                        contractAddressStreet,
                        contractAddressBuilding,
                        contractAddressFlat,
                        contractPhone,
                        tariffId,
                        peopleRegistered,
                        fixedConsumption,
                        meters,
                        options,
                        registrationDebt,

                        archiveId, budgetType, hasSewage, allowance, allowanceReason,
                        fixedConsumptionSewage,
                        registrationDate
                    }
                )
                .OneRow<CreateContractDa>();

            return res;
        }

        public void SpecialTransaction(int userId, int contractId, int subagentId, bool increaseDebt, double amount, string remarks)
        {
            NativeSql.Exec("contracts_specialTransaction",
                           new {userId, contractId, subagentId, amount = increaseDebt ? -amount : amount, remarks,});
        }

        public MobileContractModel ShowContractsMobile(int contractId)
        {
            var tables = NativeSql.ExecMultiple("mobiles_getContract", new {contractId,});
            var model = tables[0].OneRow<MobileContractModel>();

            model.Options = tables[1].Rows<OshBusinessModel.Da.ShowContract.ContractOptionsDa>();
            model.Meters = tables[2].Rows<OshBusinessModel.Da.ShowContract.ContractMeterDa>();

            return model;
        }

        public void MeterChange(int userId, int meterId, string serialNumber, string changeRemarks)
        {
            NativeSql.Exec("contract_changeMeterDetails", new {userId, meterId, serialNumber, changeRemarks,});
        }

        public void MeterAction(int userId, int meterId, bool enabled, string changeRemarks)
        {
            NativeSql.Exec("contracts_saveMeterAction", new {userId, meterId, enabled, changeRemarks,});
        }

        public void ChangeRegistrationDebt(int contractId, double debt)
        {
            NativeSql.Exec("contracts_changeRegistrationDebt", new {contractId, debt,});
        }

        public ContractStatementModel GetStatement(int contractId, int startPeriodId, int endPeriodId)
        {
            var tables = NativeSql.ExecMultiple("contracts_statement", new {contractId, startPeriodId, endPeriodId,});

            var model = tables[0].OneRow<ContractStatementModel>();

            if (model != null)
            {
                model.Found = true;
            }
            else
            {
                model = new ContractStatementModel()
                            {
                                Found = false,
                                ContractId = contractId,
                                StartPeriodId = startPeriodId,
                                EndPeriodId = endPeriodId
                            };
            }

            model.BillingPeriods = tables[1].Rows<BillingPeriodDa>();
            model.Statements = tables[2].Rows<ContractStatementDa>();

            return model;
        }

        public void ChangeTariff(int userId, int contractId, string tariff, string remarks)
        {
            NativeSql.Exec("contracts_changeTariff", new {userId, contractId, tariff, remarks,});
        }

        public void DeleteTransaction(int contractId, int transactionId, int userId)
        {
            NativeSql.Exec("contracts_deleteTransaction", new { contractId, transactionId, userId });
        }
    }
}
