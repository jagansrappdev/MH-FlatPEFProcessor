using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.Models
{
    [Schema("Schema")]
    public class Test02
    {
        [AutoIncrement]
        public int Id { get; set; }

        public int ProvNPI { get; set; }
        public string ProvIdofNCTracks { get; set; }
        public string ProvEnrollmentType { get; set; }

        public string ProvSSN { get; set; }
        public string ProvTaxId { get; set; }

        public string ProvLastname { get; set; }
        public string ProvFirstname { get; set; }

        public string ProvMiddleName { get; set; }

        public string ProvGender { get; set; }

        public string ProvDOB { get; set; }

        //Refer to excel : "Doing Business As Name" -> HSP crosswalk:Vendor - Vendor Name 
        public string VendorName { get; set; }

        //Refer : "Ordering, Prescribing, Referring LITE Effective Date"
        public string EffectiveDate { get; set; }
        public string EndDate { get; set; }
        public string MailingAddress1 { get; set; }
        public string MailingAddress2 { get; set; }
        public string MailingCity { get; set; }
        public string MailingState { get; set; }
        public string MailingZip { get; set; }
        public string ContractClass { get; set; }
        public string ContractEffectiveDate { get; set; }
        public string ContractEndDate { get; set; }
        public string ContractClassPrev01 { get; set; }
        public string ContractEffDatePrev01 { get; set; }
        public string ContractEndDatePrev01 { get; set; }
        public string ContractClassPrev02 { get; set; }
        public string ContractEffDatePrev02 { get; set; }
        public string ContractEndDatePrev02 { get; set; }
        // Refer: Retrodate Trigger for Medicaid Health Plan
        public string CustAttRetrodateTrigger { get; set; }
        public string HCContractClass { get; set; }
        public string HCContractEffDate { get; set; }
        public string HCContractEndDate { get; set; }
        public string HCContractClassPrev01 { get; set; }
        public string HCContractEffDatePrev01 { get; set; }

        public string HCContractEndDatePrev01 { get; set; }
        public string HCContractClassPrev02 { get; set; }
        public string HCContractEffDatePrev02 { get; set; }

        public string HCContractEndDatePrev02 { get; set; }
        // Refer: Retrodate Trigger for Health Choice Health Plan
        public string HCCustAttRetrodateTrigger { get; set; }
        // public string Filler654 { get; set; }
        public string OfcAdminLastname { get; set; }

        public string OfcAdminFirstname { get; set; }

        public string OfcAdminMiddlename { get; set; }
        public string OfcAdminEmail { get; set; }
        public string OfcAdminPhone { get; set; }
        public string ProvSvcLocCode { get; set; }
        public string ProvSvcLocBeginDt { get; set; }
        public string ProvSvcLocEndDt { get; set; }
        public string ProvSvcLocName { get; set; }
        public string ProvSvcLocAddress1 { get; set; }
        public string ProvSvcLocAddress2 { get; set; }
        public string ProvSvcLocCity { get; set; }
        public string ProvSvcLocState { get; set; }

        public string ProvSvcLocZip { get; set; }
        public string ProvSvcLocCountryCode { get; set; }
        public string ProvSvcLocPhone { get; set; }
        public string ProvSvcLocSiteVisitIndicator { get; set; }

        //Not Sure of This 
        public string CustEssentialProvIndGroup5x { get; set; }
        //Not sure What is "REPEAT" means
        //  public string CustEssentialProvInd { get; set; }
        public string CustOthrProvIndGroup2x { get; set; }
        // missing Start Position
        // public string CustOthrProvIndicator { get; set; }
        public string CustDHHSSPTierGroup5x { get; set; }
        //Repeats : no start Position
        //   public string DHHSSpAMHTierTypeCode { get; set; }
        //  public string DHHSSpAMHTierEffectiveDt{ get; set; }
        //  public string DHHSSpAMHTierEndDt { get; set; }
        public string ProvTaxonomyGroup20x { get; set; }

        /*
         //Repeats : no start Position
        public string TaxonomyCode { get; set; }
        public string TaxonomyLvl2Code { get; set; }
        public string TaxonomyLvl3Code { get; set; }
        public string TaxonomyCodeStatusCurrent { get; set; }
        public string TaxonomyCodeEffDateCurrent { get; set; }
        public string TaxonomyCodeEndDateCurrent { get; set; }
        //
        public string TaxonomyCodeStatusPrev01 { get; set; }
        public string TaxonomyCodeEffDatePrev01 { get; set; }
        public string TaxonomyCodeEndDatePrev01 { get; set; }

        public string TaxonomyCodeStatusPrev02 { get; set; }
        public string TaxonomyCodeEffDatePrev02 { get; set; }
        public string TaxonomyCodeEndDatePrev02 { get; set; }

        public string TaxonomyCodeRetroTrigger{ get; set; }

       // public string Filler60of3649Pos { get; set; }

        */
        public string ProvTitle { get; set; }
        public string PresumptiveEligInd { get; set; }
        public string ProvBizTypeGroup3x { get; set; }
        /*
        //Repeats : no start Position
       public string ProvBizTypeCode { get; set; }
       public string ProvBizTypeBeginDt { get; set; }
       public string ProvBizTypeEndDt { get; set; }

       */

        public string CLIACertNumber { get; set; }
        public string CLIACertType { get; set; }
        public string CLIABeginDt { get; set; }
        public string CLIAEndDt { get; set; }
        public string CLIACertActionReasonCode { get; set; }

        // PEF Expansion : New Data Below 
        public string AffilOrgGroup10x { get; set; }

        //  public string AffilOrgSvcLocation { get; set; }
        // HAs repeats fields
        //  public string AffilOrgBeginDt { get; set; }
        // public string AffilOrgEndDt { get; set; }


        public string FirstNameOf1099 { get; set; }
        public string MiddleNameOf1099 { get; set; }
        public string LastNameOf1099 { get; set; }
        public string Address1Of1099 { get; set; }

        public string Address2Of1099 { get; set; }
        public string CityOf1099 { get; set; }
        public string StateOf1099 { get; set; }
        public string ZipOf1099 { get; set; }
        public string AttendingOrRenderingInd { get; set; }

        public string OutofStateLimitEnrollInd { get; set; }
        public string SvcLocAfterHrsPhone { get; set; }
        //Service Location Fax Number
        public string SvcLocAfterHrsFax { get; set; }
        public string SvcCountiesGroup100x { get; set; }
        /*
         // Repeating fields
        public string SvcCountyCode { get; set; }
        public string SvcCountyBeginDt { get; set; }
        public string SvcCountyEndDt { get; set; }
      

        */

        /*
         * Left some properties as I am not clear on what to do with them 
         * 
         */

        public string HONetworkLead { get; set; }
        public string HODomainHousingSvcProvInd { get; set; }
        public string HODomainInterPrsnSafetyInd { get; set; }
        public string HOFoodSvcProvInd { get; set; }
        public string HODomainTrnsprtSvcProvInd { get; set; }
        public string HOCrossDomainSvcProvInd { get; set; }

        public string Hours24Ind { get; set; }
        // some more fields 
        public string ProvLangCodeGroup33x { get; set; }
        //  public string ProvLanguage { get; set; }
        public string MaleAgeGroupcode { get; set; }
        public string FemaleAgeGroupcode { get; set; }

        public string AcceptNewPatientInd { get; set; }
        public string AcceptSiblingPatientInd { get; set; }
        public string WheelchairAccessibleInd { get; set; }
        public string LangInterpreterInd { get; set; }
        public string BrailleSvcInd { get; set; }
        public string SignlangSvcInd { get; set; }
        public string BHDisruptiveSvcInd { get; set; }
        public string DeafHearingSvcInd { get; set; }
        public string PhyhandicappedSvcInd { get; set; }
        public string BlindSvcInd { get; set; }
        //Intellectual and Development Disability Services Indicator
        public string IDSvcInd { get; set; }
        //Sexually Aggressive Services Indicator
        public string SASvcInd { get; set; }
        //
        public string TDDTTYEquipInd { get; set; }
        public string DHHSBHTCMType { get; set; }
        public string DHHSBHTCMEffectiveDt { get; set; }
        public string DHHSBHTCMEndDt { get; set; }
        public string HIEIndicator { get; set; }
        public string HIEEffectiveDt { get; set; }
        public string HIEEnddt { get; set; }


    }
}
