using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.Models.PEF
{
   public  class PEFMasterDTO
    {
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
            // Refer:Medicaid Health Plan Action Reason Code Current
            public string ContractClass { get; set; }
            public string ContractEffectiveDate { get; set; }
            public string ContractEndDate { get; set; }
            //Refer : Medicaid Health Plan Action Reason Code Previous1
            public string ContractClassPrev01 { get; set; }
            public string ContractEffDatePrev01 { get; set; }
            public string ContractEndDatePrev01 { get; set; }
            // Refer: Medicaid Health Plan Action Reason Code Previous2
            public string ContractClassPrev02 { get; set; }
            public string ContractEffDatePrev02 { get; set; }
            public string ContractEndDatePrev02 { get; set; }
            // Refer: Retrodate Trigger for Medicaid Health Plan
            public string CustAttRetrodateTrigger { get; set; }

            // Refer:  Health Choice Health Plan Action Reason Code Current
            public string HCContractClass { get; set; }
            public string HCContractEffDate { get; set; }
            public string HCContractEndDate { get; set; }

            // Refer: Health Choice Health Plan End Date Previous1
            public string HCContractClassPrev01 { get; set; }
            public string HCContractEffDatePrev01 { get; set; }
            public string HCContractEndDatePrev01 { get; set; }

            //Refer: Health Choice Health Plan Action Reason Code2
            public string HCContractClassPrev02 { get; set; }
            public string HCContractEffDatePrev02 { get; set; }
            public string HCContractEndDatePrev02 { get; set; }
            // Refer: Retrodate Trigger for Health Choice Health Plan
            public string HCCustAttRetrodateTrigger { get; set; }
            // public string Filler654 { get; set; }

            //Refer: Office Administrator Last Name
            public string OfcAdminLastname { get; set; }
            public string OfcAdminFirstname { get; set; }
            public string OfcAdminMiddlename { get; set; }
            public string OfcAdminEmail { get; set; }
            public string OfcAdminPhone { get; set; }

            // Refer: Service Location Code (key)
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

      // #1. REPEATS-1 ; Refer :Essential Provider Indicator Group(5x) : 10-len(1470 to 1479)
            public string EssentialProvIndGroup5x { get; set; }
            public string EssentialProvIndicator01 { get; set; } // pos: 1470
            public string EssentialProvIndicator02 { get; set; } // pos: 1472
            public string EssentialProvIndicator03 { get; set; } // pos: 1474
            public string EssentialProvIndicator04 { get; set; } // pos: 1476
            public string EssentialProvIndicator05 { get; set; } // pos: 1478

        // #2. REPEATS-2 ; Refer: Other Provider Indicator Group (2x) : 4-len(1480 to 1483)
             public string OthrProvIndGroup2x { get; set; }
            public string OthrProvIndicator01 { get; set; } // Pos: 1480 
            public string OthrProvIndicator02 { get; set; } // pos: 1482

           // #3. REPEATS-3 ; Refer: DHHS SP AMH Tier Information Group (5x) : 105-len(1484 to 1588)
            public string DhhsSpAmhTierInfoGroup5x { get; set; }

            /*
            public string DHHSSpAMHTierTypeCode { get; set; }          //Length: 1 
            public string DHHSSpAMHTierEffectiveDt { get; set; }      //Length: 10
            public string DHHSSpAMHTierEndDt { get; set; }           //Length: 10 

           */

            // #4. REPEATS-4 ; Refer: Provider Taxonomy Group (20x) : 2060-len (1589 to 3648)
            // will be moved to Provider.Vendor table
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

            // #5. REPEATS-5 ; Refer: Provider Business Type Group (3x) : 3730 to 3792 ( 63-length)
            public string ProvBizTypeGroup3x { get; set; }
            /*
            public string ProvBizTypeCode { get; set; }
            public string ProvBizTypeBeginDt { get; set; }
            public string ProvBizTypeEndDt { get; set; }
            */

            //
            public string CLIACertNumber { get; set; }
            public string CLIACertType { get; set; }
            public string CLIABeginDt { get; set; }
            public string CLIAEndDt { get; set; }
            public string CLIACertActionReasonCode { get; set; }

            // PEF Expansion : New Data Below 
            // 
            // #6. REPEATS ; Refer: Affiliation Organization Group (10x) : 1350-length ( 3833 to 5182)
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
            public string SvcLocFax { get; set; } //Service Location Fax Number

            // #7. REPEATS ; Refer: Servicing Counties Group (100x))  : 2300 (5402 to 7701)
            public string SvcCountiesGroup100x { get; set; }
            /*
             public string SvcCountyCode { get; set; }
             public string SvcCountyBeginDt { get; set; }
             public string SvcCountyEndDt { get; set; }
             */

            public string HONetworkLead { get; set; }
            public string HODomainHousingSvcProvInd { get; set; }
            public string HODomainInterPrsnSafetyInd { get; set; }
            public string HOFoodSvcProvInd { get; set; }
            public string HODomainTrnsprtSvcProvInd { get; set; }
            public string HOCrossDomainSvcProvInd { get; set; }
            // 24 hours fields 
            public string Hours24Ind { get; set; }
            public string MonAMFrmHr { get; set; }
            public string MonAMToHr { get; set; }
            public string MonPMFrmHr { get; set; }
            public string MonPMToHr { get; set; }
            public string TueAMFrmHr { get; set; }
            public string TueAMToHr { get; set; }
            public string TuePMFrmHr { get; set; }
            public string TuePMToHr { get; set; }
            public string WedAMFrmHr { get; set; }
            public string WedAMToHr { get; set; }
            public string WedPMFrmHr { get; set; }
            public string WedPMToHr { get; set; }
            public string ThuAMFrmHr { get; set; }
            public string ThuAMToHr { get; set; }
            public string ThuPMFrmHr { get; set; }
            public string ThuPMToHr { get; set; }
            public string FriAMFrmHr { get; set; }
            public string FriAMToHr { get; set; }
            public string FriPMFrmHr { get; set; }
            public string FriPMToHr { get; set; }
            public string SatAMFrmHr { get; set; }
            public string SatAMToHr { get; set; }
            public string SatPMFrmHr { get; set; }
            public string SatPMToHr { get; set; }
            public string SunAMFrmHr { get; set; }
            public string SunAMToHr { get; set; }
            public string SunPMFrmHr { get; set; }
            public string SunPMToHr { get; set; }

            // #8. REPEATS ; Refer: Provider Language Group (33x) : 66-len (7822 to 7887)
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
            public string BlindVisualImpairedSvcInd { get; set; }
            //Intellectual and Development Disability Services Indicator
            public string IntellectualDisabilitySvcInd { get; set; }
            //Sexually Aggressive Services Indicator
            public string SexuallyAggressiveSvcInd { get; set; }
            //
            public string TDDTTYEquipInd { get; set; }
            public string DHHSBHTCMType { get; set; }
            public string DHHSBHTCMEffectiveDt { get; set; }
            public string DHHSBHTCMEndDt { get; set; }
            //
            public string HIEIndicator { get; set; }
            public string HIEEffectiveDt { get; set; }
            public string HIEEnddt { get; set; }


        //end of main class
    }
}
