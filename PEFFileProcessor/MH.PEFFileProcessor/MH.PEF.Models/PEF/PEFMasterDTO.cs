using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.Models.PEF
{
    public class PEFMasterDTO
    {
        [StringLength(10)]
        public string ProvNPI { get; set; }
        [StringLength(10)]
        public string ProvIdofNCTracks { get; set; }
        [StringLength(1)]
        public string ProvEnrollmentType { get; set; }
        [StringLength(10)]
        public string ProvSSN { get; set; }
        [StringLength(10)]
        public string ProvTaxId { get; set; }
        [StringLength(40)]
        public string ProvLastname { get; set; }
        [StringLength(25)]
        public string ProvFirstname { get; set; }
        [StringLength(20)]
        public string ProvMiddleName { get; set; }
        [StringLength(1)]
        public string ProvGender { get; set; }
        [StringLength(10)]
        public string ProvDOB { get; set; }

        //Refer to excel : "Doing Business As Name" -> HSP crosswalk:Vendor - Vendor Name 
        [StringLength(50)]
        public string VendorName { get; set; }

        //Refer : "Ordering, Prescribing, Referring LITE Effective Date"
        [StringLength(10)]
        public string EffectiveDate { get; set; }
        [StringLength(10)]
        public string EndDate { get; set; }
        [StringLength(40)]
        public string MailingAddress1 { get; set; }
        [StringLength(40)]
        public string MailingAddress2 { get; set; }
        [StringLength(25)]
        public string MailingCity { get; set; }
        [StringLength(2)]
        public string MailingState { get; set; }
        [StringLength(15)]
        public string MailingZip { get; set; }
        // Refer:Medicaid Health Plan Action Reason Code Current
        [StringLength(1)]
        public string ContractClass { get; set; }
        [StringLength(10)]
        public string ContractEffectiveDate { get; set; }
        [StringLength(10)]
        public string ContractEndDate { get; set; }
        //Refer : Medicaid Health Plan Action Reason Code Previous1
        [StringLength(1)]
        public string ContractClassPrev01 { get; set; }
        [StringLength(10)]
        public string ContractEffDatePrev01 { get; set; }
        [StringLength(10)]
        public string ContractEndDatePrev01 { get; set; }
        // Refer: Medicaid Health Plan Action Reason Code Previous2
        [StringLength(1)]
        public string ContractClassPrev02 { get; set; }
        [StringLength(10)]
        public string ContractEffDatePrev02 { get; set; }
        [StringLength(10)]
        public string ContractEndDatePrev02 { get; set; }
        // Refer: Retrodate Trigger for Medicaid Health Plan
        [StringLength(10)]
        public string CustAttRetrodateTrigger { get; set; }

        // Refer:  Health Choice Health Plan Action Reason Code Current
        [StringLength(1)]
        public string HCContractClass { get; set; }
        [StringLength(10)]
        public string HCContractEffDate { get; set; }
        [StringLength(10)]
        public string HCContractEndDate { get; set; }

        // Refer: Health Choice Health Plan End Date Previous1
        [StringLength(1)]
        public string HCContractClassPrev01 { get; set; }
        [StringLength(10)]
        public string HCContractEffDatePrev01 { get; set; }
        [StringLength(10)]
        public string HCContractEndDatePrev01 { get; set; }

        //Refer: Health Choice Health Plan Action Reason Code2
        [StringLength(1)]
        public string HCContractClassPrev02 { get; set; }
        [StringLength(10)]
        public string HCContractEffDatePrev02 { get; set; }
        [StringLength(10)]
        public string HCContractEndDatePrev02 { get; set; }
        // Refer: Retrodate Trigger for Health Choice Health Plan
        [StringLength(10)]
        public string HCCustAttRetrodateTrigger { get; set; }
        // public string Filler654 { get; set; }

        //Refer: Office Administrator Last Name
        [StringLength(40)]
        public string OfcAdminLastname { get; set; }
        [StringLength(20)]
        public string OfcAdminFirstname { get; set; }
        [StringLength(20)]
        public string OfcAdminMiddlename { get; set; }
        [StringLength(80)]
        public string OfcAdminEmail { get; set; }
        [StringLength(10)]
        public string OfcAdminPhone { get; set; }

        // Refer: Service Location Code (key)
        [StringLength(3)]
        public string ProvSvcLocCode { get; set; }
        [StringLength(10)]
        public string ProvSvcLocBeginDt { get; set; }
        [StringLength(10)]
        public string ProvSvcLocEndDt { get; set; }
        [StringLength(40)]
        public string ProvSvcLocName { get; set; }
        [StringLength(40)]
        public string ProvSvcLocAddress1 { get; set; }
        [StringLength(40)]
        public string ProvSvcLocAddress2 { get; set; }
        [StringLength(25)]
        public string ProvSvcLocCity { get; set; }
        [StringLength(2)]
        public string ProvSvcLocState { get; set; }
        [StringLength(15)]
        public string ProvSvcLocZip { get; set; }
        [StringLength(5)]
        public string ProvSvcLocCountryCode { get; set; }
        [StringLength(10)]
        public string ProvSvcLocPhone { get; set; }
        [StringLength(1)]
        public string ProvSvcLocSiteVisitIndicator { get; set; }

        // #1. REPEATS-1 ; Refer :Essential Provider Indicator Group(5x) : 10-len(1470 to 1479)
        [StringLength(10)]
        public string EssentialProvIndGroup5x { get; set; }
        [StringLength(2)]
        public string EssentialProvIndicator01 { get; set; } // pos: 1470
        [StringLength(2)]
        public string EssentialProvIndicator02 { get; set; } // pos: 1472
        [StringLength(2)]
        public string EssentialProvIndicator03 { get; set; } // pos: 1474
        [StringLength(2)]
        public string EssentialProvIndicator04 { get; set; } // pos: 1476
        [StringLength(2)]
        public string EssentialProvIndicator05 { get; set; } // pos: 1478

        // #2. REPEATS-2 ; Refer: Other Provider Indicator Group (2x) : 4-len(1480 to 1483)
        [StringLength(4)]
        public string OthrProvIndGroup2x { get; set; }
        [StringLength(2)]
        public string OthrProvIndicator01 { get; set; } // Pos: 1480 
        [StringLength(2)]
        public string OthrProvIndicator02 { get; set; } // pos: 1482

        // #3. REPEATS-3 ; Refer: DHHS SP AMH Tier Information Group (5x) : 105-len(1484 to 1588)
        [StringLength(105)]
        public string DhhsSpAmhTierInfoGroup5x { get; set; }

        /*
        public string DHHSSpAMHTierTypeCode { get; set; }          //Length: 1 
        public string DHHSSpAMHTierEffectiveDt { get; set; }      //Length: 10
        public string DHHSSpAMHTierEndDt { get; set; }           //Length: 10 

       */

        // #4. REPEATS-4 ; Refer: Provider Taxonomy Group (20x) : 2060-len (1589 to 3648)
        // will be moved to Provider.Vendor table
        [StringLength(2060)]
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

        [StringLength(20)]
        public string ProvTitle { get; set; }
        [StringLength(1)]
        public string PresumptiveEligInd { get; set; }

        // #5. REPEATS-5 ; Refer: Provider Business Type Group (3x) : 3730 to 3792 ( 63-length)
        [StringLength(63)]
        public string ProvBizTypeGroup3x { get; set; }
        /*
        public string ProvBizTypeCode { get; set; }
        public string ProvBizTypeBeginDt { get; set; }
        public string ProvBizTypeEndDt { get; set; }
        */

        //
        [StringLength(15)]
        public string CLIACertNumber { get; set; }
        [StringLength(2)]
        public string CLIACertType { get; set; }
        [StringLength(10)]
        public string CLIABeginDt { get; set; }
        [StringLength(10)]
        public string CLIAEndDt { get; set; }
        [StringLength(3)]
        public string CLIACertActionReasonCode { get; set; }

        // PEF Expansion : New Data Below 
        // 
        // #6. REPEATS ; Refer: Affiliation Organization Group (10x) : 1350-length ( 3833 to 5182)
        [StringLength(1350)]
        public string AffilOrgGroup10x { get; set; }
        /*
        public string AffilOrgTypeCode { get; set; }
        public string AffilOrgNPI { get; set; }
        public string AffilOrgTaxId { get; set; }
        public string AffilOrgName { get; set; }
        public string AffilOrgSvcLocation { get; set; }
        public string AffilOrgBeginDt { get; set; }
        public string AffilOrgEndDt { get; set; }
        */

        // regular
        [StringLength(35)]
        public string FirstNameOf1099 { get; set; }
        [StringLength(20)]
        public string MiddleNameOf1099 { get; set; }
        [StringLength(20)]
        public string LastNameOf1099 { get; set; }
        [StringLength(40)]
        public string Address1Of1099 { get; set; }
        [StringLength(40)]
        public string Address2Of1099 { get; set; }
        [StringLength(25)]
        public string CityOf1099 { get; set; }
        [StringLength(2)]
        public string StateOf1099 { get; set; }
        [StringLength(15)]
        public string ZipOf1099 { get; set; }
        [StringLength(1)]
        public string AttendingOrRenderingInd { get; set; }
        [StringLength(1)]
        public string OutofStateLimitEnrollInd { get; set; }
        [StringLength(10)]
        public string SvcLocAfterHrsPhone { get; set; }
        [StringLength(10)]
        public string SvcLocFax { get; set; } //Service Location Fax Number

        // #7. REPEATS ; Refer: Servicing Counties Group (100x))  : 2300 (5402 to 7701)
        [StringLength(2300)]
        public string SvcCountiesGroup100x { get; set; }
        /*
         public string SvcCountyCode { get; set; }
         public string SvcCountyBeginDt { get; set; }
         public string SvcCountyEndDt { get; set; }
         */

        [StringLength(1)]
        public string HONetworkLead { get; set; }
        [StringLength(1)]
        public string HODomainHousingSvcProvInd { get; set; }
        [StringLength(1)]
        public string HODomainInterPrsnSafetyInd { get; set; }
        [StringLength(1)]
        public string HOFoodSvcProvInd { get; set; }
        [StringLength(1)]
        public string HODomainTrnsprtSvcProvInd { get; set; }
        [StringLength(1)]
        public string HOCrossDomainSvcProvInd { get; set; }
        // 24 hours fields 
        [StringLength(1)]
        public string Hours24Ind { get; set; }
        [StringLength(4)]
        public string MonAMFrmHr { get; set; }
        [StringLength(4)]
        public string MonAMToHr { get; set; }
        [StringLength(4)]
        public string MonPMFrmHr { get; set; }
        [StringLength(4)]
        public string MonPMToHr { get; set; }
        [StringLength(4)]
        public string TueAMFrmHr { get; set; }
        [StringLength(4)]
        public string TueAMToHr { get; set; }
        [StringLength(4)]
        public string TuePMFrmHr { get; set; }
        [StringLength(4)]
        public string TuePMToHr { get; set; }
        [StringLength(4)]
        public string WedAMFrmHr { get; set; }
        [StringLength(4)]
        public string WedAMToHr { get; set; }
        [StringLength(4)]
        public string WedPMFrmHr { get; set; }
        [StringLength(4)]
        public string WedPMToHr { get; set; }
        [StringLength(4)]
        public string ThuAMFrmHr { get; set; }
        [StringLength(4)]
        public string ThuAMToHr { get; set; }
        [StringLength(4)]
        public string ThuPMFrmHr { get; set; }
        [StringLength(4)]
        public string ThuPMToHr { get; set; }
        [StringLength(4)]
        public string FriAMFrmHr { get; set; }
        [StringLength(4)]
        public string FriAMToHr { get; set; }
        [StringLength(4)]
        public string FriPMFrmHr { get; set; }
        [StringLength(4)]
        public string FriPMToHr { get; set; }
        [StringLength(4)]
        public string SatAMFrmHr { get; set; }
        [StringLength(4)]
        public string SatAMToHr { get; set; }
        [StringLength(4)]
        public string SatPMFrmHr { get; set; }
        [StringLength(4)]
        public string SatPMToHr { get; set; }
        [StringLength(4)]
        public string SunAMFrmHr { get; set; }
        [StringLength(4)]
        public string SunAMToHr { get; set; }
        [StringLength(4)]
        public string SunPMFrmHr { get; set; }
        [StringLength(4)]
        public string SunPMToHr { get; set; }

        // #8. REPEATS ; Refer: Provider Language Group (33x) : 66-len (7822 to 7887)
        [StringLength(66)]
        public string ProvLangCodeGroup33x { get; set; }

        //  public string ProvLanguage { get; set; }
        [StringLength(2)]
        public string MaleAgeGroupcode { get; set; }
        [StringLength(2)]
        public string FemaleAgeGroupcode { get; set; }
        [StringLength(1)]
        public string AcceptNewPatientInd { get; set; }
        [StringLength(1)]
        public string AcceptSiblingPatientInd { get; set; }
        [StringLength(1)]
        public string WheelchairAccessibleInd { get; set; }
        [StringLength(1)]
        public string LangInterpreterInd { get; set; }
        [StringLength(1)]
        public string BrailleSvcInd { get; set; }
        [StringLength(1)]
        public string SignlangSvcInd { get; set; }
        [StringLength(1)]
        public string BHDisruptiveSvcInd { get; set; }
        [StringLength(1)]
        public string DeafHearingSvcInd { get; set; }
        [StringLength(1)]
        public string PhyhandicappedSvcInd { get; set; }
        [StringLength(1)]
        public string BlindVisualImpairedSvcInd { get; set; }
        //Intellectual and Development Disability Services Indicator
        [StringLength(1)]
        public string IntellectualDisabilitySvcInd { get; set; }
        //Sexually Aggressive Services Indicator
        [StringLength(1)]
        public string SexuallyAggressiveSvcInd { get; set; }
        //
        [StringLength(1)]
        public string TDDTTYEquipInd { get; set; }
        [StringLength(10)]
        public string DHHSBHTCMType { get; set; }
        [StringLength(10)]
        public string DHHSBHTCMEffectiveDt { get; set; }
        [StringLength(10)]
        public string DHHSBHTCMEndDt { get; set; }
        //
        [StringLength(2)]
        public string HIEIndicator { get; set; }
        [StringLength(10)]
        public string HIEEffectiveDt { get; set; }

        [StringLength(10)]
        public string HIEEnddt { get; set; }


        //end of main class
    }
}
