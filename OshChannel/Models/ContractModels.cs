using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OshBusinessModel.Da;
using OshBusinessModel.J2MeDb.Dto;
using OshBusinessModel.Da.Meters;

namespace OshChannel.Models
{
    public class MakePaymentModel
    {
        public int ContractId { get; set; }
        public string Amount { get; set; }
        public int SubagentId { get; set; }
        public string ReceiptNo { get; set; }
    }

    public class GetMetersValuesModel
    {
        public int ContractId { get; set; }
    }

    public class SetMetersValuesModel
    {
        public string Date { get; set; }
        public SetMetersValuesDto[] Meters { get; set; }
        public string MeterValueType { get; set; }
    }

    public class ChangeContractInfoAjaxModel
    {
        public int ContractId { get; set; }
        public string ContractName { get; set; }
        public int AreaId { get; set; }
        public string AddressStreet { get; set; }
        public string AddressBuilding { get; set; }
        public string AddressFlat { get; set; }
        public string Phone { get; set; }
        public string ChangeRemarks { get; set; }
        public int ArchiveId { get; set; }
        public string BudgetType { get; set; }
    }

    public class ChangeContractParametersAjaxModel
    {
        public int ContractId { get; set; }
        public int PeopleRegistered { get; set; }
        public string FixedConsumption { get; set; }
        public string FixedConsumptionSewage { get; set; }
        public string ChangeRemarks { get; set; }
        public string HasSewage { get; set; }
        public string Allowance { get; set; }
        public string AllowanceReason { get; set; }
    }

    public class AddMeterAjaxModel
    {
        public int ContractId { get; set; }
        public string SerialNumber { get; set; }
        public string Value { get; set; }
        public string ChangeRemarks { get; set; }
    }

    public class AddTariffOptionAjaxModel
    {
        public int ContractId { get; set; }
        public string SemanticId { get; set; }
        public string Value { get; set; }
        public string ChangeRemarks { get; set; }
        public bool Sewage { get; set; }
    }

    public class ChangeTariffOptionValueAjaxModel
    {
        public int TariffOptionId { get; set; }
        public string Value { get; set; }
        public string ChangeRemarks { get; set; }
        public bool Sewage { get; set; }
    }

    public class RegisterTariffOptionActionAjaxModel
    {
        public int TariffOptionId { get; set; }
        public string Action { get; set; }
        public string ChangeRemarks { get; set; }
    }

    public class RegiserConractActionAjaxModel
    {
        public int ContractId { get; set; }
        public string Action { get; set; }
        public string ChangeRemarks { get; set; }
    }

    public class SpecialTransactionAjaxModel
    {
        public int ContractId { get; set; }
        public int SubagentId { get; set; }
        public string IncreaseDebt { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
    }

    public class MeterChangeAjaxModel
    {
        public int MeterId { get; set; }
        public string SerialNumber { get; set; }
        public string ChangeRemarks { get; set; }
    }

    public class MeterActionAjaxModel
    {
        public int MeterId { get; set; }
        public int Enabled { get; set; }
        public string ChangeRemarks { get; set; }
    }

    public class ChangeRegistrationDebtAjaxModel
    {
        public int ContractId { get; set; }
        public string Debt { get; set; }
    }

    public class ChangeTariffAjaxModel
    {
        public int ContractId { get; set; }
        public string Tariff { get; set; }
        public string Remarks { get; set; }
    }

    public class DeleteTransactionAjaxModel
    {
        public int TransactionId { get; set; }
        public int ContractId { get; set; }
    }
}