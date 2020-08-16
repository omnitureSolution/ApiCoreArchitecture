using System;
using iSocietyCare.Db.Abstractions.Enums;

namespace iSocietyCare.Core.Model.Insurance
{
    public partial class PaymentViewModel : ViewModel
    {

        public int PaymentId { get; set; }
        public int EnquiryId { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal? PaymentAmount { get; set; }
        public decimal? FirstPayment { get; set; }
        public decimal? PaymentExcludingCharge { get; set; }
        public int? NumberOfPayment { get; set; }
        public int PaymentTypeId { get; set; }
        public int PaymentStatusId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string CcNumber { get; set; }
        public string CcExpiryDate { get; set; }
        public string CcName { get; set; }
        public int? SwitchIssueNumber { get; set; }
        public string DdSortCode { get; set; }
        public string DdAccountNumber { get; set; }
        public string DdAccountName { get; set; }
        public string DdBankName { get; set; }
        public string DdBankAddress1 { get; set; }
        public string DdBankAddress2 { get; set; }
        public string DdBankAddressPostode { get; set; }
        public string ClientForename { get; set; }
        public DateTime? ClientDob { get; set; }
        public string CcContactNumber { get; set; }
        public string DdContactNumber { get; set; }
        public string ChequeNumber { get; set; }
        public DateTime? PaidDate { get; set; }
        public string CcStartDate { get; set; }
        public bool? CcSolo { get; set; }
        public string CrossReference { get; set; }
        public string Cv2number { get; set; }
        public short? CreditCardType { get; set; }
        public bool? IsDdValuesAvailable { get; set; }
        public DateTime? CommissionDueDate { get; set; }
        public string DdTown { get; set; }

        public virtual EnquiryViewModel Enquiry { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }
    }
}
