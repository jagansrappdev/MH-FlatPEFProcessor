using MH.PEF.BLL.Utilities;
using MH.PEF.Models.PEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.BLL.BizLogic
{
   public static  class PEFProcessorLogic
    {

        // Process Individual Elements level

        public static PEFMasterDTO ProcessPEFMasterDTOLine(string InputLine)
        {
            var resp = new PEFMasterDTO();
            /*  -------Perform string operations based on field length ------------- */
            resp.ProvNPI                        = PEFUtilities.GetStringValue(InputLine, 1, 10, "Provider NPI");
            resp.ProvIdofNCTracks               = PEFUtilities.GetStringValue(InputLine, 11, 8, "NCTracks Internal Provider Identifier");
            resp.ProvEnrollmentType             = PEFUtilities.GetStringValue(InputLine, 19, 1, "Provider Enrollment Type");
            resp.ProvSSN                        = PEFUtilities.GetStringValue(InputLine, 20, 9, "Provider Social Security");
            resp.ProvTaxId                      = PEFUtilities.GetStringValue(InputLine, 29, 9, "Provider Tax Id ");
            resp.ProvLastname                   = PEFUtilities.GetStringValue(InputLine, 38, 35, "Provider Last Name or Facility Name");
            resp.ProvFirstname                  = PEFUtilities.GetStringValue(InputLine, 73, 20, "Provider First Name");
            resp.ProvMiddleName                 = PEFUtilities.GetStringValue(InputLine, 93, 20, "Provider Middle Name");
            resp.ProvGender                     = PEFUtilities.GetStringValue(InputLine, 113, 1, "Provider Gender");
            resp.ProvDOB                        = PEFUtilities.GetStringValue(InputLine, 114, 10, "Provider Date Of Birth");
            resp.VendorName                     = PEFUtilities.GetStringValue(InputLine, 124, 50, "Provider VendorName OR Doing Business As Name ");
            resp.EffectiveDate                  = PEFUtilities.GetStringValue(InputLine, 174, 10, "Ordering, Prescribing, Referring LITE Effective Date");
            resp.EndDate                        = PEFUtilities.GetStringValue(InputLine, 184, 10, "Ordering, Prescribing, Referring LITE End Date");
            resp.MailingAddress1                = PEFUtilities.GetStringValue(InputLine, 194, 40, "Mailing Address 1");
            resp.MailingAddress2                = PEFUtilities.GetStringValue(InputLine, 234, 40, "Mailing Address 2");
            resp.MailingCity                    = PEFUtilities.GetStringValue(InputLine, 274, 25, "Mailing City");
            resp.MailingState                   = PEFUtilities.GetStringValue(InputLine, 299, 2, "Mailing State");
            resp.MailingZip                     = PEFUtilities.GetStringValue(InputLine, 301, 15, "Mailing Zip");
            //normal fields
            resp.ContractClass                  = PEFUtilities.GetStringValue(InputLine, 316, 1, "Provider Contract Class");
            resp.ContractEffectiveDate          = PEFUtilities.GetStringValue(InputLine, 317, 10, "Provider Contract Effective Date");
            resp.ContractEndDate                = PEFUtilities.GetStringValue(InputLine, 327, 10, "Provider Contract Expiration Date");
            resp.ContractClassPrev01            = PEFUtilities.GetStringValue(InputLine, 337, 1, "Medicaid Health Plan Action Reason Code Previous1");
            resp.ContractEffDatePrev01          = PEFUtilities.GetStringValue(InputLine, 338, 10, "Medicaid Health Plan Effective Date Previous1");
            resp.ContractEndDatePrev01          = PEFUtilities.GetStringValue(InputLine, 348, 10, "Medicaid Health Plan End Date Previous1");
            resp.ContractClassPrev02            = PEFUtilities.GetStringValue(InputLine, 358, 1, "Medicaid Health Plan Action Reason Code Previous2");
            resp.ContractEffDatePrev02          = PEFUtilities.GetStringValue(InputLine, 359, 10, "Medicaid Health Plan Effective Date Previous2");
            resp.ContractEndDatePrev02          = PEFUtilities.GetStringValue(InputLine, 369, 10, "Medicaid Health Plan End Date Previous2");
            resp.CustAttRetrodateTrigger        = PEFUtilities.GetStringValue(InputLine, 379, 10, "Retrodate Trigger for Medicaid Health Plan");
            resp.HCContractClass                = PEFUtilities.GetStringValue(InputLine, 389, 1, "Health Choice Health Plan Action Reason Code Current");
            resp.HCContractEffDate              = PEFUtilities.GetStringValue(InputLine, 390, 10, "Health Choice Health Plan Effective Date Current");
            resp.HCContractEndDate              = PEFUtilities.GetStringValue(InputLine, 400, 10, "Health Choice Health Plan End Date Current");
            resp.HCContractClassPrev01          = PEFUtilities.GetStringValue(InputLine, 410, 1, "Health Choice Health Plan Action Reason Code Previous1");
            resp.HCContractEffDatePrev01        = PEFUtilities.GetStringValue(InputLine, 411, 10, "Health Choice Health Plan Effective Date Previous1");
            resp.HCContractEndDatePrev01        = PEFUtilities.GetStringValue(InputLine, 421, 10, "Health Choice Health Plan End Date Previous1");
            resp.HCContractClassPrev02          = PEFUtilities.GetStringValue(InputLine, 431, 1, "Health Choice Health Plan Action Reason Code2");
            resp.HCContractEffDatePrev02        = PEFUtilities.GetStringValue(InputLine, 432, 10, "Health Choice Health Plan Effective Date2");
            resp.HCContractEndDatePrev02        = PEFUtilities.GetStringValue(InputLine, 442, 10, "Health Choice Health Plan End Date2");
            resp.HCCustAttRetrodateTrigger      = PEFUtilities.GetStringValue(InputLine, 452, 10, "Retrodate Trigger for Health Choice Health Plan");
            // filler 
            resp.OfcAdminLastname               = PEFUtilities.GetStringValue(InputLine, 1116, 35, "Office Administrator Last Name");
            resp.OfcAdminFirstname              = PEFUtilities.GetStringValue(InputLine, 1151, 20, "Office Administrator First Name");
            resp.OfcAdminMiddlename             = PEFUtilities.GetStringValue(InputLine, 1171, 20, "Office Administrator Middle Name");
            resp.OfcAdminEmail                  = PEFUtilities.GetStringValue(InputLine, 1191, 75, "Office Administrator Email");
            resp.OfcAdminPhone                  = PEFUtilities.GetStringValue(InputLine, 1266, 10, "Medicaid Health Plan End Date Previous2");
            resp.ProvSvcLocCode                 = PEFUtilities.GetStringValue(InputLine, 1276, 3, "Service Location Code key");
            resp.ProvSvcLocBeginDt              = PEFUtilities.GetStringValue(InputLine, 1279, 10, "Service Location Begin Date");
            resp.ProvSvcLocEndDt                = PEFUtilities.GetStringValue(InputLine, 1289, 10, "Service Location End Date");
            resp.ProvSvcLocName                 = PEFUtilities.GetStringValue(InputLine, 1299, 35, "Service Location Name");
            resp.ProvSvcLocAddress1             = PEFUtilities.GetStringValue(InputLine, 1334, 40, "Service Location Address 1");
            resp.ProvSvcLocAddress2             = PEFUtilities.GetStringValue(InputLine, 1374, 40, "Service Location Address 2");
            resp.ProvSvcLocCity                 = PEFUtilities.GetStringValue(InputLine, 1414, 25, "Service Location City");
            resp.ProvSvcLocState                = PEFUtilities.GetStringValue(InputLine, 1439, 2, "Service Location State");
            resp.ProvSvcLocZip                  = PEFUtilities.GetStringValue(InputLine, 1441, 15, "Service Location Address 2");
            resp.ProvSvcLocCountryCode          = PEFUtilities.GetStringValue(InputLine, 1456, 3, "Service Location County Code");
            resp.ProvSvcLocPhone                = PEFUtilities.GetStringValue(InputLine, 1459, 10, "Service Location Address 2");
            resp.ProvSvcLocSiteVisitIndicator   = PEFUtilities.GetStringValue(InputLine, 1469, 1, "Service Location Site Visit Indicator ");
            // REPEAT-1
            resp.EssentialProvIndGroup5x        = PEFUtilities.GetStringValue(InputLine, 1470, 10, "Combined String-Essential Provider Indicator");
            resp.EssentialProvIndicator01       = PEFUtilities.GetStringValue(InputLine, 1470, 2, "Essential Provider Indicator01");
            resp.EssentialProvIndicator02       = PEFUtilities.GetStringValue(InputLine, 1472, 2, "Essential Provider Indicator02");
            resp.EssentialProvIndicator03       = PEFUtilities.GetStringValue(InputLine, 1474, 2, "Essential Provider Indicator03");
            resp.EssentialProvIndicator04       = PEFUtilities.GetStringValue(InputLine, 1476, 2, "Essential Provider Indicator04");
            resp.EssentialProvIndicator05       = PEFUtilities.GetStringValue(InputLine, 1478, 2, "Essential Provider Indicator05");
         //##.  REPEAT-2
            resp.OthrProvIndGroup2x             = PEFUtilities.GetStringValue(InputLine, 1480, 4, "Other Provider Indicator Group2x");
            resp.OthrProvIndicator01            = PEFUtilities.GetStringValue(InputLine, 1480, 2, "Other Provider Indicator01");
            resp.OthrProvIndicator02            = PEFUtilities.GetStringValue(InputLine, 1482, 2, "Other Provider Indicator02");
        //##.  REPEAT-3 ://pass it to a new function
            resp.DhhsSpAmhTierInfoGroup5x       = PEFUtilities.GetStringValueNOTrim(InputLine, 1484, 105, "DHHS SP AMH Tier Information Group (5x)");
        //##.  REPEAT-4 ://pass it to a new function  
            resp.ProvTaxonomyGroup20x           = PEFUtilities.GetStringValueNOTrim(InputLine, 1589, 2060, "Provider Taxonomy Group (20x)");
            // Normal fields 
            resp.ProvTitle                      = PEFUtilities.GetStringValue(InputLine, 3709, 20, "Provider Title");
            resp.PresumptiveEligInd             = PEFUtilities.GetStringValue(InputLine, 3729, 1, "Presumptive Eligibility Indicator");
       //##.  REPEAT-5 ://pass it to a new function  
            resp.ProvBizTypeGroup3x             = PEFUtilities.GetStringValue(InputLine, 3730, 63, "Provider Business Type Group (3x)");
            //normal fields 
            resp.CLIACertNumber                 = PEFUtilities.GetStringValue(InputLine, 3793, 15, "CLIA Certification Number");
            resp.CLIACertType                   = PEFUtilities.GetStringValue(InputLine, 3808, 2, "CLIA Certification Type");
            resp.CLIABeginDt                    = PEFUtilities.GetStringValue(InputLine, 3810, 10, "CLIA Begin Date");
            resp.CLIAEndDt                      = PEFUtilities.GetStringValue(InputLine, 3820, 10, "CLIA End Date ");
            resp.CLIACertActionReasonCode       = PEFUtilities.GetStringValue(InputLine, 3830, 3, "CLIA Certification Action Reason Code");
            //New PEF fileds
       //##.  REPEAT-6 ://pass it to a new function  
            resp.AffilOrgGroup10x               = PEFUtilities.GetStringValueNOTrim(InputLine, 3833, 1350, "Affiliation Organization Group (10x)");
            //normal fields 
            resp.FirstNameOf1099                = PEFUtilities.GetStringValue(InputLine, 5183, 35, "1099 Addr Contact First Name");
            resp.MiddleNameOf1099               = PEFUtilities.GetStringValue(InputLine, 5218, 20, "Property");
            resp.LastNameOf1099                 = PEFUtilities.GetStringValue(InputLine, 5238, 20, "1099 Addr Contact Last Name");
            resp.Address1Of1099                 = PEFUtilities.GetStringValue(InputLine, 5258, 40, "1099 Addr Addr1");
            resp.Address2Of1099                 = PEFUtilities.GetStringValue(InputLine, 5298, 40, "1099 Addr Addr2");
            resp.CityOf1099                     = PEFUtilities.GetStringValue(InputLine, 5338, 25, "1099 Addr City");
            resp.StateOf1099                    = PEFUtilities.GetStringValue(InputLine, 5363, 2, "1099 Addr State");
            resp.ZipOf1099                      = PEFUtilities.GetStringValue(InputLine, 5365, 15, "1099 Addr Zip");
            resp.AttendingOrRenderingInd        = PEFUtilities.GetStringValue(InputLine, 5380, 1, "Attending/Rendering Only Indicator");
            resp.OutofStateLimitEnrollInd       = PEFUtilities.GetStringValue(InputLine, 5381, 1, "Out of State Limited Enrollment Indicator");
            resp.SvcLocAfterHrsPhone            = PEFUtilities.GetStringValue(InputLine, 5382, 10, "Service Location After Hours Phone Number");
            resp.SvcLocFax                      = PEFUtilities.GetStringValue(InputLine, 5392, 10, "Service Location Fax Number");
            //##.  REPEAT-7 ://pass it to a new function  
            // resp.SvcCountiesGroup100x           = PEFUtilities.GetStringValue(InputLine, 5402, 2300, "Servicing Counties Group (100x)");
            resp.SvcCountiesGroup100x              = PEFUtilities.GetStringValueNOTrim(InputLine, 5402, 2300, "Servicing Counties Group (100x)");
           
            //normal fields
            resp.HONetworkLead                  = PEFUtilities.GetStringValue(InputLine, 7702, 1, "HO Network Lead");
            resp.HODomainHousingSvcProvInd      = PEFUtilities.GetStringValue(InputLine, 7704, 1, "HO Domain Housing Service Provider");
            resp.HODomainInterPrsnSafetyInd     = PEFUtilities.GetStringValue(InputLine, 7705, 1, "HO Domain Interpersonal Safety or Toxic Stress Services Provider");
            resp.HOFoodSvcProvInd               = PEFUtilities.GetStringValue(InputLine, 7706, 1, "HO Domain Food and Nutrition Services Provider");
            resp.HODomainTrnsprtSvcProvInd      = PEFUtilities.GetStringValue(InputLine, 7707, 1, "HO Domain Transportation Services Provider");
            resp.HOCrossDomainSvcProvInd        = PEFUtilities.GetStringValue(InputLine, 7708, 1, "HO Cross-Domain Services Provider");
            resp.Hours24Ind                     = PEFUtilities.GetStringValue(InputLine, 7709, 1, "24 Hour Indicator");
            resp.MonAMFrmHr                     = PEFUtilities.GetStringValue(InputLine, 7710, 4, "Monday AM From Hour");
            resp.MonAMToHr                      = PEFUtilities.GetStringValue(InputLine, 7714, 4, "Monday AM To Hour");
            resp.MonPMFrmHr                     = PEFUtilities.GetStringValue(InputLine, 7718, 4, "Monday PM From Hour");
            resp.MonPMToHr                      = PEFUtilities.GetStringValue(InputLine, 7722, 4, "Monday PM To Hour");
            resp.MonAMFrmHr                     = PEFUtilities.GetStringValue(InputLine, 7710, 4, "Monday AM From Hour");
            resp.MonAMToHr                      = PEFUtilities.GetStringValue(InputLine, 7714, 4, "Monday AM To Hour");
            resp.MonPMFrmHr                     = PEFUtilities.GetStringValue(InputLine, 7718, 4, "Monday PM From Hour");
            resp.MonPMToHr                      = PEFUtilities.GetStringValue(InputLine, 7722, 4, "Monday PM To Hour");
            resp.TueAMFrmHr                     = PEFUtilities.GetStringValue(InputLine, 7726, 4, "Tuesday AM From Hour");
            resp.TueAMToHr                      = PEFUtilities.GetStringValue(InputLine, 7730, 4, "Tuesday AM To Hour");
            resp.TuePMFrmHr                     = PEFUtilities.GetStringValue(InputLine, 7734, 4, "Tuesday PM From Hour");
            resp.TuePMToHr                      = PEFUtilities.GetStringValue(InputLine, 7738, 4, "Tuesday PM To Hour");
            resp.WedAMFrmHr                     = PEFUtilities.GetStringValue(InputLine, 7742, 4, "Wednesday AM From Hour");
            resp.WedAMToHr                      = PEFUtilities.GetStringValue(InputLine, 7746, 4, "Wednesday AM To Hour");
            resp.WedPMFrmHr                     = PEFUtilities.GetStringValue(InputLine, 7750, 4, "Wednesday PM From Hour");
            resp.WedPMToHr                      = PEFUtilities.GetStringValue(InputLine, 7754, 4, "Wednesday PM To Hour");
            resp.ThuAMFrmHr                     = PEFUtilities.GetStringValue(InputLine, 7758, 4, "Thursday AM From Hour");
            resp.ThuAMToHr                      = PEFUtilities.GetStringValue(InputLine, 7762, 4, "Thursday AM To Hour");
            resp.ThuPMFrmHr                     = PEFUtilities.GetStringValue(InputLine, 7766, 4, "Thursday PM From Hour");
            resp.ThuPMToHr                      = PEFUtilities.GetStringValue(InputLine, 7770, 4, "Thursday PM To Hour");
            resp.FriAMFrmHr                     = PEFUtilities.GetStringValue(InputLine, 7774, 4, "Friday AM From Hour");
            resp.FriAMToHr                      = PEFUtilities.GetStringValue(InputLine, 7778, 4, "Friday AM To Hour");
            resp.FriPMFrmHr                     = PEFUtilities.GetStringValue(InputLine, 7782, 4, "Friday PM From Hour");
            resp.FriPMToHr                      = PEFUtilities.GetStringValue(InputLine, 7786, 4, "Friday PM To Hour");
            resp.SatAMFrmHr                     = PEFUtilities.GetStringValue(InputLine, 7790, 4, "Saturday AM From Hour");
            resp.SatAMToHr                      = PEFUtilities.GetStringValue(InputLine, 7794, 4, "Saturday AM To Hour");
            resp.SatPMFrmHr                     = PEFUtilities.GetStringValue(InputLine, 7798, 4, "Saturday PM From Hour");
            resp.SatPMToHr                      = PEFUtilities.GetStringValue(InputLine, 7802, 4, "Saturday PM To Hour");
            resp.SunAMFrmHr                     = PEFUtilities.GetStringValue(InputLine, 7806, 4, "Sunday AM From Hour");
            resp.SunAMToHr                      = PEFUtilities.GetStringValue(InputLine, 7810, 4, "Sunday AM To Hour");
            resp.SunPMFrmHr                     = PEFUtilities.GetStringValue(InputLine, 7814, 4, "Sunday PM From Hour");
            resp.SunPMToHr                      = PEFUtilities.GetStringValue(InputLine, 7818, 4, "Sunday PM To Hour");
            //##. REPEAT-6 :  // Pass it to New function
            resp.ProvLangCodeGroup33x           = PEFUtilities.GetStringValueNOTrim(InputLine, 7822, 66, "Provider Language Group (33x)");
            //normal fields
            resp.MaleAgeGroupcode               = PEFUtilities.GetStringValue(InputLine, 7888, 2, "Male Age Group Code");
            resp.FemaleAgeGroupcode             = PEFUtilities.GetStringValue(InputLine, 7890, 2, "Female Age Group Code");
            resp.AcceptNewPatientInd            = PEFUtilities.GetStringValue(InputLine, 7892, 1, "Accepting New Patients Indicator");
            resp.AcceptSiblingPatientInd        = PEFUtilities.GetStringValue(InputLine, 7893, 1, "Property");
            resp.WheelchairAccessibleInd        = PEFUtilities.GetStringValue(InputLine, 7894, 1, "Physical Handicap Wheelchair Accessible Indicator");
            resp.LangInterpreterInd             = PEFUtilities.GetStringValue(InputLine, 7895, 1, "Language Interpreter Indicator");
            resp.BrailleSvcInd                  = PEFUtilities.GetStringValue(InputLine, 7896, 1, "Braille Services Indicator");
            resp.SignlangSvcInd                 = PEFUtilities.GetStringValue(InputLine, 7897, 1, "Sign Language Services Indicator ");
            resp.BHDisruptiveSvcInd             = PEFUtilities.GetStringValue(InputLine, 7898, 1, "Behaviorally Disruptive Services Indicator ");
            resp.DeafHearingSvcInd              = PEFUtilities.GetStringValue(InputLine, 7899, 1, "Deaf Hearing Impaired Services Indicator ");
            resp.PhyhandicappedSvcInd           = PEFUtilities.GetStringValue(InputLine, 7900, 1, "Physically Handicapped Services Indicator ");
            resp.BlindVisualImpairedSvcInd      = PEFUtilities.GetStringValue(InputLine, 7901, 1, "Blind Visually Impaired Services Indicator");
            resp.IntellectualDisabilitySvcInd   = PEFUtilities.GetStringValue(InputLine, 7902, 1, "Intellectual and Development Disability Services Indicator");
            resp.SexuallyAggressiveSvcInd       = PEFUtilities.GetStringValue(InputLine, 7903, 1, "Sexually Aggressive Services Indicator");
            resp.TDDTTYEquipInd                 = PEFUtilities.GetStringValue(InputLine, 7904, 1, "TDD TTY Equipped Indicator");
            resp.DHHSBHTCMType                  = PEFUtilities.GetStringValue(InputLine, 7905, 1, "DHHS BH TCM Type");
            resp.DHHSBHTCMEffectiveDt           = PEFUtilities.GetStringValue(InputLine, 7906, 10, "DHHS BH TCM Effective Date");
            resp.DHHSBHTCMEndDt                 = PEFUtilities.GetStringValue(InputLine, 7916, 1, "DHHS BH TCM End Date");
            resp.HIEIndicator                   = PEFUtilities.GetStringValue(InputLine, 7926, 2, "HIE Indicator");
            resp.HIEEffectiveDt                 = PEFUtilities.GetStringValue(InputLine, 7928, 10, "HIE Effective Date");
            resp.HIEEnddt                       = PEFUtilities.GetStringValue(InputLine, 7938, 10, "HIE End Date");

            // **  return final response 
            return resp;
        }

        //public static List<PEFVendorDTO> ProcessPEFVendorDTO(PEFMasterDTO parsedIpObj , int MhTrnxId )
        //{
        //    try
        //    {
        //        var res = new List<PEFVendorDTO>();
        //        //
        //        var AffilGroupList = new List<string>();

        //        //parse common values 
        //        var npi = parsedIpObj.ProvNPI;
        //        var ncId = parsedIpObj.ProvIdofNCTracks;
        //        var enroll = parsedIpObj.ProvEnrollmentType;
        //        var provTax = parsedIpObj.ProvTaxId;

        //        var RepeatString = parsedIpObj.AffilOrgGroup10x;
        //        if( !string.IsNullOrEmpty( RepeatString ))
        //        {
        //            int chunkSize = 135;
        //            int rptStringLen = RepeatString.Length;

        //            for (int i = 1; i <= 10; i++)
        //            {
        //                var startPos = chunkSize * i;
        //                var splitStr = PEFUtilities.GetStringValue(RepeatString, startPos, chunkSize, "AffilGroup-" + i);

        //                AffilGroupList.Add(splitStr);
        //            }

        //            foreach (var item in AffilGroupList)
        //            {
        //                var respItem = new PEFVendorDTO
        //                {
        //                    ProvNPI = npi,
        //                    ProvNCTracksId = ncId,
        //                    ProvEnrollmentType = enroll,
        //                    ProvTaxId = provTax,
        //                    MhTrnxId = MhTrnxId,
        //                    //
        //                    AffilOrgTypeCode = ProcessPEFData.GetStringFieldValue(item, 1, 2, "Affiliated Organization Type Code"),
        //                    AffilOrgNPI = ProcessPEFData.GetStringFieldValue(item, 2, 10, "Affiliated Organization NPI/Atypical"),
        //                    AffilOrgTaxId = ProcessPEFData.GetStringFieldValue(item, 12, 50, "Affiliated Organization Tax Id"),
        //                    AffilOrgName = ProcessPEFData.GetStringFieldValue(item, 62, 50, "Affiliated Organization Name"),
        //                    AffilOrgSvcLocation = ProcessPEFData.GetStringFieldValue(item, 112, 3, "Affiliated Organization Service Location Code"),
        //                    AffilOrgBeginDt = ProcessPEFData.GetStringFieldValue(item, 115, 10, "Affiliated Organization Begin Date"),
        //                    AffilOrgEndDt = ProcessPEFData.GetStringFieldValue(item, 125, 10, "Affiliated Organization End Date")
        //                };
        //                res.Add(respItem);

        //            }

        //        }

        //        return res;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
           
        //}


        public static ProvTaxonomyLineDTO ProcessPEFTaxonomyLine(string InputLine)
        {
            var resp = new ProvTaxonomyLineDTO();
            /*  -------Perform string operations based on field length ------------- */
            resp.ProvNPI = PEFUtilities.GetStringValue(InputLine, 1, 10, "Provider NPI");
            resp.ProvNCTracksId = PEFUtilities.GetStringValue(InputLine, 11, 8, "NCTracks Internal Provider Identifier");
            resp.ProvEnrollmentType = PEFUtilities.GetStringValue(InputLine, 19, 1, "Provider Enrollment Type");
            resp.ProvSvcLocCode = PEFUtilities.GetStringValue(InputLine, 1276, 3, "Service Location Code key");
            // repet string 
            //##.  REPEAT-4 ://pass it to a new function  
            resp.ProvTaxonomyGroup20x = PEFUtilities.GetStringValueNOTrim(InputLine, 1589, 2060, "Provider Taxonomy Group (20x)");

            return resp;

        }



        public static TaxonomyGroup ProcessTaxonomyLine (string RepeatedStr)
        {
            var res = new TaxonomyGroup();

            res.TaxonomyCode                = ProcessPEFData.GetStringFieldValue(RepeatedStr, 1, 10, "Taxonomy Code");
            res.TaxonomyLvl2Code            = ProcessPEFData.GetStringFieldValue(RepeatedStr, 11, 10, "Taxonomy Level 2 Code");
            res.TaxonomyLvl3Code            = ProcessPEFData.GetStringFieldValue(RepeatedStr, 21, 10, "Taxonomy Level 3 Code");
             //
            res.TaxonomyCodeStatusCurrent   = ProcessPEFData.GetStringFieldValue(RepeatedStr, 31, 1, "Taxonomy Code Status Current");
            res.TaxonomyCodeEffDateCurrent  = ProcessPEFData.GetStringFieldValue(RepeatedStr, 32, 10, "Taxonomy Code Effective Date Current");
            res.TaxonomyCodeEndDateCurrent  = ProcessPEFData.GetStringFieldValue(RepeatedStr, 42, 10, "Taxonomy Code End Date Current");
             //
            res.TaxonomyCodeStatusPrev01    = ProcessPEFData.GetStringFieldValue(RepeatedStr, 52, 1, "Taxonomy Code Status Previous1");
            res.TaxonomyCodeEffDatePrev01   = ProcessPEFData.GetStringFieldValue(RepeatedStr, 53, 10, "Taxonomy Code Effective Date Previous1");
            res.TaxonomyCodeEndDatePrev01   = ProcessPEFData.GetStringFieldValue(RepeatedStr, 63, 10, "Taxonomy Code Effective Date Previous2");
            //
            res.TaxonomyCodeStatusPrev02    = ProcessPEFData.GetStringFieldValue(RepeatedStr, 73, 1, "Taxonomy Code Status Previous2");
            res.TaxonomyCodeEffDatePrev02   = ProcessPEFData.GetStringFieldValue(RepeatedStr, 74, 10, "Taxonomy Code Effective Date Previous2");
            res.TaxonomyCodeEndDatePrev02   = ProcessPEFData.GetStringFieldValue(RepeatedStr, 84, 10, "Taxonomy Code End Date Previous2");
            res.TaxonomyCodeRetroTrigger    = ProcessPEFData.GetStringFieldValue(RepeatedStr, 94, 10, "Retrodate Trigger for Taxonomy");
            //
            return res;
        }

        //org
        public static List<PEFProvTaxonomyGrp> ProcessPEFTaxonomyGrpDTO(List<ProvTaxonomyLineDTO> parsedInpObj, int MhTrnxId)
        {

            try
            {
                var res = new List<PEFProvTaxonomyGrp>();
                //
                var txnGrpList = new List<string>();

                //Read input
                if(parsedInpObj.Any())
                {
                    // Process all 33k lines 
                    foreach (var item in parsedInpObj)
                    {

                        // Break into List<Strings> 
                        var RepeatString = item.ProvTaxonomyGroup20x;
                        int chunkSize = 103;
                        var startpos = 1;
                        // repeats 20 times 
                        for (int i = 1; i <= 20; i++)
                        {
                            var splitStr = PEFUtilities.GetStringValue(RepeatString, startpos, 103, "txnGrpList-" + i);
                            txnGrpList.Add(splitStr);
                            // reset start 
                            startpos = startpos + chunkSize;
                        }

                        //remove null lines 
                         txnGrpList?.RemoveAll(x => x == null);

                        // Loop Group Lines 
                        foreach (var str in txnGrpList)
                        {
                            var txnLine = PEFProcessorLogic.ProcessTaxonomyLine(str);

                            var line = new PEFProvTaxonomyGrp
                            {
                                ProvNPI = item.ProvNPI,
                                ProvNCTracksId = item.ProvNCTracksId,
                                ProvEnrollmentType = item.ProvEnrollmentType,
                                ProvSvcLocCode = item.ProvSvcLocCode,
                             //   ProvTaxonomyGroup20x = item.ProvTaxonomyGroup20x,
                                // repeat lines 
                                TaxonomyCode = txnLine.TaxonomyCode,
                                TaxonomyLvl2Code = txnLine.TaxonomyLvl2Code,
                                TaxonomyLvl3Code = txnLine.TaxonomyLvl3Code,
                                //
                                TaxonomyCodeStatusCurrent = txnLine.TaxonomyCodeStatusCurrent,
                                TaxonomyCodeEffDateCurrent = txnLine.TaxonomyCodeEffDateCurrent,
                                TaxonomyCodeEndDateCurrent = txnLine.TaxonomyCodeEndDateCurrent,
                                //
                                TaxonomyCodeStatusPrev01 = txnLine.TaxonomyCodeStatusPrev01,
                                TaxonomyCodeEffDatePrev01 = txnLine.TaxonomyCodeEffDatePrev01,
                                TaxonomyCodeEndDatePrev01 = txnLine.TaxonomyCodeEndDatePrev01,
                                //
                                TaxonomyCodeStatusPrev02 = txnLine.TaxonomyCodeStatusPrev02,
                                TaxonomyCodeEffDatePrev02 = txnLine.TaxonomyCodeEffDatePrev02,
                                TaxonomyCodeEndDatePrev02 = txnLine.TaxonomyCodeEndDatePrev02,
                                TaxonomyCodeRetroTrigger = txnLine.TaxonomyCodeRetroTrigger
                            };
                            //add to resp obj
                            res.Add(line);

                        }

                        /*
                        //parse repat string :
                        var txnLine = PEFProcessorLogic.ProcessTaxonomyLine(item.ProvTaxonomyGroup20x);
                        var line = new PEFProvTaxonomyGrp
                        {
                            ProvNPI = item.ProvNPI,
                            ProvNCTracksId = item.ProvNCTracksId,
                            ProvEnrollmentType = item.ProvEnrollmentType,
                            ProvSvcLocCode = item.ProvSvcLocCode,
                            ProvTaxonomyGroup20x = item.ProvTaxonomyGroup20x ,
                            // repeat lines 
                            TaxonomyCode = txnLine.TaxonomyCode,
                            TaxonomyLvl2Code = txnLine.TaxonomyLvl2Code,
                            TaxonomyLvl3Code = txnLine.TaxonomyLvl3Code,
                            //
                            TaxonomyCodeStatusCurrent = txnLine.TaxonomyCodeStatusCurrent,
                            TaxonomyCodeEffDateCurrent = txnLine.TaxonomyCodeEffDateCurrent,
                            TaxonomyCodeEndDateCurrent = txnLine.TaxonomyCodeEndDateCurrent,
                            //
                            TaxonomyCodeStatusPrev01 = txnLine.TaxonomyCodeStatusPrev01,
                            TaxonomyCodeEffDatePrev01 = txnLine.TaxonomyCodeEffDatePrev01,
                            TaxonomyCodeEndDatePrev01 = txnLine.TaxonomyCodeEndDatePrev01,
                            //
                            TaxonomyCodeStatusPrev02 = txnLine.TaxonomyCodeStatusPrev02,
                            TaxonomyCodeEffDatePrev02 = txnLine.TaxonomyCodeEffDatePrev02,
                            TaxonomyCodeEndDatePrev02 = txnLine.TaxonomyCodeEndDatePrev02,
                            TaxonomyCodeRetroTrigger = txnLine.TaxonomyCodeRetroTrigger
                        };
                        */

                    }
                    //final obj
                    var final = res;

                }
                





                //------ parse Unique KEY Combo
                //var npi = parsedIpObj.;
                //var ncId = parsedIpObj.ProvIdofNCTracks;
                //var enroll = parsedIpObj.ProvEnrollmentType;
                //var svcLocKey = parsedIpObj.ProvSvcLocCode;
                //// repeat String group
                //var RepeatString = parsedIpObj.ProvTaxonomyGroup20x;


                //if (!string.IsNullOrEmpty(RepeatString))
                //{
                //    int chunkSize = 135;
                //    int rptStringLen = RepeatString.Length;

                //    for (int i = 1; i <= 10; i++)
                //    {
                //        var startPos = chunkSize * i;
                //        var splitStr = PEFUtilities.GetStringValue(RepeatString, startPos, chunkSize, "AffilGroup-" + i);

                //        AffilGroupList.Add(splitStr);
                //    }

                //    foreach (var item in AffilGroupList)
                //    {
                //        var respItem = new PEFVendorDTO
                //        {
                //            ProvNPI = npi,
                //            ProvNCTracksId = ncId,
                //            ProvEnrollmentType = enroll,
                //            ProvTaxId = provTax,
                //            MhTrnxId = MhTrnxId,
                //            //
                //            AffilOrgTypeCode = ProcessPEFData.GetStringFieldValue(item, 1, 2, "Affiliated Organization Type Code"),
                //            AffilOrgNPI = ProcessPEFData.GetStringFieldValue(item, 2, 10, "Affiliated Organization NPI/Atypical"),
                //            AffilOrgTaxId = ProcessPEFData.GetStringFieldValue(item, 12, 50, "Affiliated Organization Tax Id"),
                //            AffilOrgName = ProcessPEFData.GetStringFieldValue(item, 62, 50, "Affiliated Organization Name"),
                //            AffilOrgSvcLocation = ProcessPEFData.GetStringFieldValue(item, 112, 3, "Affiliated Organization Service Location Code"),
                //            AffilOrgBeginDt = ProcessPEFData.GetStringFieldValue(item, 115, 10, "Affiliated Organization Begin Date"),
                //            AffilOrgEndDt = ProcessPEFData.GetStringFieldValue(item, 125, 10, "Affiliated Organization End Date")
                //        };
                //        res.Add(respItem);

                //    }

                //}

                return res;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //new 
        public static List<PEFProvTaxonomyGrp> ProcessPEFTaxonomyGrpDTOItem(ProvTaxonomyLineDTO parsedInpObj, int MhTrnxId)
        {

            try
            {
                var res = new List<PEFProvTaxonomyGrp>();
                //
                var txnGrpList = new List<string>();

                //Read input
                if (parsedInpObj != null)
                {
                        // Break into List<Strings> 
                        var RepeatString = parsedInpObj.ProvTaxonomyGroup20x;
                        int chunkSize = 103;
                        var startpos = 1;
                        // repeats 20 times 
                        for (int i = 1; i <= 20; i++)
                        {
                            var splitStr = PEFUtilities.GetStringValue(RepeatString, startpos, 103, "txnGrpList-" + i);
                            txnGrpList.Add(splitStr);
                            // reset start 
                            startpos = startpos + chunkSize;
                        }

                        //remove null lines 
                        txnGrpList?.RemoveAll(x => x == null);

                        // Loop Group Lines 
                        foreach (var str in txnGrpList)
                        {
                            var txnLine = ProcessTaxonomyLine(str);

                            var line = new PEFProvTaxonomyGrp
                            {
                                ProvNPI = parsedInpObj.ProvNPI,
                                ProvNCTracksId = parsedInpObj.ProvNCTracksId,
                                ProvEnrollmentType = parsedInpObj.ProvEnrollmentType,
                                ProvSvcLocCode = parsedInpObj.ProvSvcLocCode,
                                //   ProvTaxonomyGroup20x = item.ProvTaxonomyGroup20x,
                                // repeat lines 
                                TaxonomyCode = txnLine.TaxonomyCode,
                                TaxonomyLvl2Code = txnLine.TaxonomyLvl2Code,
                                TaxonomyLvl3Code = txnLine.TaxonomyLvl3Code,
                                //
                                TaxonomyCodeStatusCurrent = txnLine.TaxonomyCodeStatusCurrent,
                                TaxonomyCodeEffDateCurrent = txnLine.TaxonomyCodeEffDateCurrent,
                                TaxonomyCodeEndDateCurrent = txnLine.TaxonomyCodeEndDateCurrent,
                                //
                                TaxonomyCodeStatusPrev01 = txnLine.TaxonomyCodeStatusPrev01,
                                TaxonomyCodeEffDatePrev01 = txnLine.TaxonomyCodeEffDatePrev01,
                                TaxonomyCodeEndDatePrev01 = txnLine.TaxonomyCodeEndDatePrev01,
                                //
                                TaxonomyCodeStatusPrev02 = txnLine.TaxonomyCodeStatusPrev02,
                                TaxonomyCodeEffDatePrev02 = txnLine.TaxonomyCodeEffDatePrev02,
                                TaxonomyCodeEndDatePrev02 = txnLine.TaxonomyCodeEndDatePrev02,
                                TaxonomyCodeRetroTrigger = txnLine.TaxonomyCodeRetroTrigger
                            };
                            //add to resp obj
                            res.Add(line);

                        }

                  //  }
                    //final obj
                    var final = res;

                }

                return res;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
