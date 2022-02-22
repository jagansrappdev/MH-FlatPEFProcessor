using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.Models
{
    public class PEFileLayoutModel
    {

        [MaxLength(10)]
        [Display(Order = 1)]
        public string ProvNPI { get; set; }

        [MaxLength(8)]
        [Display(Order = 2)]
        public string ProvIdofNCTracks { get; set; }

        [MaxLength(1)]
        [Display(Order = 3)]
        public string ProvEnrollmentType { get; set; }

        [MaxLength(9)]
        [Display(Order = 4)]
        public string ProvSSN { get; set; }

        [MaxLength(9)]
        [Display(Order = 5)]
        public string ProvTaxId { get; set; }

        [MaxLength(35)]
        [Display(Order = 6)]
        public string ProvLastname { get; set; }

        [MaxLength(20)]
        [Display(Order = 7)]
        public string ProvFirstname { get; set; }

        [MaxLength(20)]
        [Display(Order = 8)]
        public string ProvMiddleName { get; set; }

        [MaxLength(1)]
        [Display(Order = 9)]
        public string ProvGender { get; set; }
        //--
        [MaxLength(10)]
        [Display(Order = 10)]
        public string ProvDOB { get; set; }

        //Refer to excel : "Doing Business As Name" -> HSP crosswalk:Vendor - Vendor Name 
        [MaxLength(50)]
        [Display(Order = 11)]
        public string VendorName { get; set; }

        //Refer : "Ordering, Prescribing, Referring LITE Effective Date"
        [MaxLength(10)]
        [Display(Order = 12)]
        //   [ArgusDataType(ArgusDataType.Date, FieldBlankDefaultValueFieldDependency = "IcdCodeStartDate", BlankDefaultValue = "99991231")]
        public string EffectiveDate { get; set; }

        [MaxLength(10)]
        [Display(Order = 13)]
        //   [ArgusDataType(ArgusDataType.Date)]
        public string EndDate { get; set; }

        [MaxLength(40)]
        [Display(Order = 14)]
        public string MailingAddress1 { get; set; }

        [MaxLength(40)]
        [Display(Order = 15)]
        public string MailingAddress2 { get; set; }

        [MaxLength(25)]
        [Display(Order = 16)]
        public string MailingCity { get; set; }

        [MaxLength(2)]
        [Display(Order = 17)]
        public string MailingState { get; set; }

        [MaxLength(15)]
        [Display(Order = 18)]
        public string MailingZip { get; set; }

        //
        //Medicaid Health Plan Action Reason Code Current
        [MaxLength(1)]
        [Display(Order = 19)]
        public string ContractClass { get; set; }

        [MaxLength(10)]
        [Display(Order = 20)]
      //  [ArgusDataType(ArgusDataType.Date)]
        public string ContractEffectiveDate { get; set; }

        [MaxLength(10)]
        [Display(Order = 21)]
      //  [ArgusDataType(ArgusDataType.Date, FieldBlankDefaultValueFieldDependency = "LowIncomeSubsidyCodeStartDate", BlankDefaultValue = "99991231")]
        public string ContractEndDate { get; set; }

        [MaxLength(1)]
        [Display(Order = 22)]
        public string ContractClassPrev01 { get; set; }

        [MaxLength(10)]
        [Display(Order = 23)]

        public string ContractEffectiveDatePrev01 { get; set; }


        [MaxLength(10)]
        [Display(Order = 24)]
        public string ContractEndDatePrev01 { get; set; }

        [MaxLength(1)]
        [Display(Order = 25)]
        public string ContractClassPrev02 { get; set; }

        [MaxLength(10)]
        [Display(Order = 26)]
        public string ContractEffectiveDatePrev02 { get; set; }

        [MaxLength(10)]
        [Display(Order = 27)]
        public string ContractEndDatePrev02 { get; set; }

        // Refer: Retrodate Trigger for Medicaid Health Plan
        [MaxLength(10)]
        [Display(Order = 28)]
        public string CustAttRetrodateTrigger { get; set; }


        [MaxLength(1)]
        [Display(Order = 29)]
        public string HCContractClass { get; set; }

        [MaxLength(10)]
        [Display(Order = 30)]
        public string HCContractEffectiveDate { get; set; }

        [MaxLength(10)]
        [Display(Order = 31)]
        public string HCContractEndDate { get; set; }
        //
        [MaxLength(1)]
        [Display(Order = 32)]
        public string HCContractClassPrev01 { get; set; }

        [MaxLength(10)]
        [Display(Order = 33)]

        public string HCContractEffectiveDatePrev01 { get; set; }


        [MaxLength(10)]
        [Display(Order = 34)]
        public string HCContractEndDatePrev01 { get; set; }

        [MaxLength(1)]
        [Display(Order = 35)]
        public string HCContractClassPrev02 { get; set; }

        [MaxLength(10)]
        [Display(Order = 36)]
        public string HCContractEffectiveDatePrev02 { get; set; }

        [MaxLength(10)]
        [Display(Order = 37)]
        public string HCContractEndDatePrev02 { get; set; }

        // Refer: Retrodate Trigger for Health Choice Health Plan
        [MaxLength(10)]
        [Display(Order = 38)]
        public string HcCustAttRetrodateTrigger { get; set; }

        [MaxLength(654)]
        [Display(Order = 39)]
        public string Filler654 { get; set; }

        // ---

        [MaxLength(35)]
        [Display(Order = 40)]
        public string OfcAdminLastname { get; set; }

        [MaxLength(20)]
        [Display(Order = 41)]
        public string OfcAdminFirstname { get; set; }

        [MaxLength(20)]
        [Display(Order = 42)]
        public string OfcAdminMiddlename { get; set; }

        [MaxLength(75)]
        [Display(Order = 43)]
        public string OfcAdminEmail { get; set; }

        [MaxLength(10)]
        [Display(Order = 44)]
        public string OfcAdminPhone { get; set; }

        [MaxLength(3)]
        [Display(Order = 45)]
        public string ProvSvcLocCode { get; set; }

        [MaxLength(10)]
        [Display(Order = 46)]
        public string ProvSvcLocBeginDt{ get; set; }

        [MaxLength(10)]
        [Display(Order = 47)]
        public string ProvSvcLocEndDt { get; set; }

        [MaxLength(35)]
        [Display(Order = 48)]
        public string ProvSvcLocName { get; set; }

        [MaxLength(40)]
        [Display(Order = 49)]
        public string ProvSvcLocAddress1 { get; set; }

        [MaxLength(40)]
        [Display(Order = 50)]
        public string ProvSvcLocAddress2 { get; set; }

        [MaxLength(25)]
        [Display(Order = 51)]
        public string ProvSvcLocCity { get; set; }

        [MaxLength(2)]
        [Display(Order = 52)]
        public string ProvSvcLocState { get; set; }

        [MaxLength(15)]
        [Display(Order = 53)]
        public string ProvSvcLocZip { get; set; }

        [MaxLength(3)]
        [Display(Order = 54)]
        public string ProvSvcLocCountryCode { get; set; }

        [MaxLength(10)]
        [Display(Order = 55)]
        public string ProvSvcLocPhone { get; set; }

        [MaxLength(1)]
        [Display(Order = 56)]
        public string ProvSvcLocSiteVisitInd { get; set; }

    }
}
