using MH.PEF.Models;
using MH.PEF.Models.PEF;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.BLL
{
  public static  class ProcessPEFData
    {
        private static  readonly string _MHdbConnStr;

        static ProcessPEFData()
        {
            _MHdbConnStr = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["JaganLocalDB"].ConnectionString).ToString();
            /* // For Async : 
              SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["JaganLocalDB"].ConnectionString){ AsynchronousProcessing = true}.ToString()
             */
        }

        public static string GetStringFieldValue( string lineData , int startPos, int length, string fieldName )
        {
            var splitString = lineData.Substring(startPos-1, length);
            if(String.IsNullOrEmpty(splitString) || String.IsNullOrWhiteSpace(splitString))
            {
                return null;
            }
            else 
            { 
                return splitString.Trim();
            }
            
        }

        public static DateTime GetDateFieldValue(string lineData, int startPos, int length, string fieldName)
        {

            var split = lineData.Substring(startPos, length);

            return  Convert.ToDateTime(split);
        }


        public static  Int32 GetNumbericFieldValue(string lineData, int startIndex, int length, string fieldName)
        {
            var split = lineData.Substring(startIndex, length);

            return Convert.ToInt32(split);
        }
        public static void PerformDBInsertion(DataTable InputTbl)
        {
            
            using (var connection = new SqlConnection(_MHdbConnStr))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
                {
                    bulkCopy.BatchSize = 100;
                    bulkCopy.DestinationTableName = "dbo.PEFRespModel2";
                    try
                    {
                        bulkCopy.WriteToServer(InputTbl);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        connection.Close();
                    }
                }

                transaction.Commit();
            }

        }


        //
        public static DataTable ToDataTable<T>(List<T> InputList)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (var item in InputList)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties) 
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

                table.Rows.Add(row);
            }
            return table;
        }



        // Process Individual Elements level

        public static PEFRespModel ProcessLine( string InputLine)
        {
            var resp = new PEFRespModel();

            // 
            resp.ProvNPI                     = Convert.ToInt32(GetStringFieldValue(InputLine, 1, 10, "Provider NPI") );
            //
            resp.ProvIdofNCTracks            = GetStringFieldValue(InputLine, 11, 8 , "NCTracks Internal Provider Identifier");
            resp.ProvEnrollmentType          = GetStringFieldValue(InputLine, 19, 1, "Provider Enrollment Type");
            resp.ProvSSN                     = GetStringFieldValue(InputLine, 20, 9, "");
            resp.ProvTaxId                   = GetStringFieldValue(InputLine, 29, 9, "");
            resp.ProvLastname                = GetStringFieldValue(InputLine, 38, 35, "Provider Last Name or Facility Name");
            resp.ProvFirstname               = GetStringFieldValue(InputLine, 73, 20, "Provider First Name");
            resp.ProvMiddleName              = GetStringFieldValue(InputLine, 93, 20, "Provider Middle Name");
            resp.ProvGender                  = GetStringFieldValue(InputLine, 113, 1, "Provider Gender");
            resp.ProvDOB                     = GetStringFieldValue(InputLine, 114, 10, "Provider Date Of Birth");
            resp.VendorName                  = GetStringFieldValue(InputLine, 124, 50, "Provider VendorName OR Doing Business As Name ");
            resp.EffectiveDate               = GetStringFieldValue(InputLine, 174, 10, "Ordering, Prescribing, Referring LITE Effective Date");
            resp.EndDate                     = GetStringFieldValue(InputLine, 184, 10, "Ordering, Prescribing, Referring LITE End Date");
            resp.MailingAddress1             = GetStringFieldValue(InputLine, 194, 40, "Mailing Address 1");
            resp.MailingAddress2             = GetStringFieldValue(InputLine, 234, 40, "Mailing Address 2");
            resp.MailingCity                 = GetStringFieldValue(InputLine, 274, 25, "Mailing City");
            resp.MailingState                = GetStringFieldValue(InputLine, 299, 2, "Mailing State");
            resp.MailingZip                  = GetStringFieldValue(InputLine, 301, 15, "Mailing Zip");
            //
            resp.ContractClass               = GetStringFieldValue(InputLine, 316, 1, "Provider Contract Class");
            resp.ContractEffectiveDate       = GetStringFieldValue(InputLine, 317, 10, "Provider Contract Effective Date");
            resp.ContractEndDate             = GetStringFieldValue(InputLine, 327, 10, "Provider Contract Expiration Date");
            resp.ContractClassPrev01         = GetStringFieldValue(InputLine, 337, 1, "Medicaid Health Plan Action Reason Code Previous1");
            resp.ContractEffDatePrev01       = GetStringFieldValue(InputLine, 338, 10, "Medicaid Health Plan Effective Date Previous1");
            resp.ContractEndDatePrev01       = GetStringFieldValue(InputLine, 348, 10, "Medicaid Health Plan End Date Previous1");
            resp.ContractClassPrev02         = GetStringFieldValue(InputLine, 358, 1, "Medicaid Health Plan Action Reason Code Previous2");
            resp.ContractEffDatePrev02       = GetStringFieldValue(InputLine, 359, 10, "Medicaid Health Plan Effective Date Previous2");
            resp.ContractEndDatePrev02       = GetStringFieldValue(InputLine, 369, 10, "Medicaid Health Plan End Date Previous2");
            //
            resp.CustAttRetrodateTrigger    = GetStringFieldValue(InputLine, 379, 10, "Retrodate Trigger for Medicaid Health Plan");
            resp.HCContractClass            = GetStringFieldValue(InputLine, 389, 1, "Health Choice Health Plan Action Reason Code Current");
            resp.HCContractEffDate          = GetStringFieldValue(InputLine, 390, 10, "Health Choice Health Plan Effective Date Current");
            resp.HCContractEndDate          = GetStringFieldValue(InputLine, 400, 10, "Health Choice Health Plan End Date Current");
            resp.HCContractClassPrev01      = GetStringFieldValue(InputLine, 410, 1, "Health Choice Health Plan Action Reason Code Previous1");
            resp.HCContractEffDatePrev01    = GetStringFieldValue(InputLine, 411, 10, "Health Choice Health Plan Effective Date Previous1");
            resp.HCContractEndDatePrev01    = GetStringFieldValue(InputLine, 421, 10, "Health Choice Health Plan End Date Previous1");
            resp.HCContractClassPrev02      = GetStringFieldValue(InputLine, 431, 1, "Health Choice Health Plan Action Reason Code2");
            resp.HCContractEffDatePrev02    = GetStringFieldValue(InputLine, 432, 10, "Health Choice Health Plan Effective Date2");
            resp.HCContractEndDatePrev02    = GetStringFieldValue(InputLine, 442, 10, "Health Choice Health Plan End Date2");
            resp.HCCustAttRetrodateTrigger  = GetStringFieldValue(InputLine, 452, 10, "Retrodate Trigger for Health Choice Health Plan");
            //
            resp.OfcAdminLastname                = GetStringFieldValue(InputLine, 1116, 35, "Office Administrator Last Name");
            resp.OfcAdminFirstname               = GetStringFieldValue(InputLine, 1151, 20, "Office Administrator First Name");
            resp.OfcAdminMiddlename              = GetStringFieldValue(InputLine, 1171, 20, "Office Administrator Middle Name");
            resp.OfcAdminEmail                   = GetStringFieldValue(InputLine, 1191, 75, "Office Administrator Email");
            resp.OfcAdminPhone                   = GetStringFieldValue(InputLine, 1266, 10, "Medicaid Health Plan End Date Previous2");
            resp.ProvSvcLocCode                  = GetStringFieldValue(InputLine, 1276, 3, "Service Location Code key");
            resp.ProvSvcLocBeginDt               = GetStringFieldValue(InputLine, 1279, 10, "Service Location Begin Date");
            resp.ProvSvcLocEndDt                 = GetStringFieldValue(InputLine, 1289, 10, "Service Location End Date");
            resp.ProvSvcLocName                  = GetStringFieldValue(InputLine, 1299, 35, "Service Location Name");
            resp.ProvSvcLocAddress1              = GetStringFieldValue(InputLine, 1334, 40, "Service Location Address 1");
            resp.ProvSvcLocAddress2              = GetStringFieldValue(InputLine, 1374, 40, "Service Location Address 2");
            resp.ProvSvcLocCity                  = GetStringFieldValue(InputLine, 1414, 25, "Service Location City");
            resp.ProvSvcLocState                 = GetStringFieldValue(InputLine, 1439, 2, "Service Location State");
            resp.ProvSvcLocZip                   = GetStringFieldValue(InputLine, 1441, 15, "Service Location Address 2");
            resp.ProvSvcLocCountryCode           = GetStringFieldValue(InputLine, 1456, 3, "Service Location County Code");
            resp.ProvSvcLocPhone                 = GetStringFieldValue(InputLine, 1459, 10, "Service Location Address 2");
            resp.ProvSvcLocSiteVisitIndicator    = GetStringFieldValue(InputLine, 1469, 1, "Service Location Site Visit Indicator ");
            // REPEAT-1
            resp.CustEssentialProvIndGroup5x = GetStringFieldValue(InputLine, 1470,10, "Property");
          //  resp.CustEssentialProvInd = GetStringFieldValue(InputLine, 1469, 1, "Property");

            resp.CustOthrProvIndGroup2x          = GetStringFieldValue(InputLine, 1480, 4, "Property");
            resp.CustDHHSSPAMHTierGroup5x = GetStringFieldValue(InputLine, 1484, 105, "DHHS SP AMH Tier Information Group (5x)");
            resp.ProvTaxonomyGroup20x            = GetStringFieldValue(InputLine, 1589, 2060, "Provider Taxonomy Group (20x)");
          //  resp.TaxonomyCode = GetStringFieldValue(InputLine, 1469, 1, "Property");
          //  resp.Property = GetStringFieldValue(InputLine, 1469, 1, "Property");
          //  resp.Property = GetStringFieldValue(InputLine, 1469, 1, "Property");

            resp.ProvTitle                       = GetStringFieldValue(InputLine, 3709, 20, "Provider Title");
            resp.PresumptiveEligInd              = GetStringFieldValue(InputLine, 3729, 1, "Presumptive Eligibility Indicator");
            resp.ProvBizTypeGroup3x              = GetStringFieldValue(InputLine, 3730, 63, "Provider Business Type Group (3x)");
         //   resp.Property = GetStringFieldValue(InputLine, 1469, 1, "Property");
         //   resp.Property = GetStringFieldValue(InputLine, 1469, 1, "Property");
          
            resp.CLIACertNumber                  = GetStringFieldValue(InputLine, 3793, 15, "CLIA Certification Number");
            resp.CLIACertType                    = GetStringFieldValue(InputLine, 3808, 2, "CLIA Certification Type");
            resp.CLIABeginDt                     = GetStringFieldValue(InputLine, 3810, 10, "CLIA Begin Date");
            resp.CLIAEndDt                       = GetStringFieldValue(InputLine, 3820, 10, "CLIA End Date ");
            resp.CLIACertActionReasonCode        = GetStringFieldValue(InputLine, 3830, 3, "CLIA Certification Action Reason Code");

            //New PEF fileds
            resp.AffilOrgGroup10x = GetStringFieldValue(InputLine, 3833, 1350, "Affiliation Organization Group (10x)");
            //some repeat fields here 

            resp.FirstNameOf1099                = GetStringFieldValue(InputLine, 5183, 35, "1099 Addr Contact First Name");
            resp.MiddleNameOf1099               = GetStringFieldValue(InputLine, 5218, 20, "Property");
            resp.LastNameOf1099                 = GetStringFieldValue(InputLine, 5238, 20, "1099 Addr Contact Last Name");
            resp.Address1Of1099                 = GetStringFieldValue(InputLine, 5258, 40, "1099 Addr Addr1");
            resp.Address2Of1099                 = GetStringFieldValue(InputLine, 5298, 40, "1099 Addr Addr2");
            resp.CityOf1099                     = GetStringFieldValue(InputLine, 5338, 25, "1099 Addr City");
            resp.StateOf1099                    = GetStringFieldValue(InputLine, 5363, 2, "1099 Addr State");
            resp.ZipOf1099                      = GetStringFieldValue(InputLine, 5365, 15, "1099 Addr Zip");
           
            resp.AttendingOrRenderingInd        = GetStringFieldValue(InputLine, 5380, 1, "Attending/Rendering Only Indicator");
            resp.OutofStateLimitEnrollInd       = GetStringFieldValue(InputLine, 5381, 1, "Out of State Limited Enrollment Indicator");
            resp.SvcLocAfterHrsPhone            = GetStringFieldValue(InputLine, 5382, 10, "Service Location After Hours Phone Number");
            resp.SvcLocAfterHrsFax              = GetStringFieldValue(InputLine, 5392, 10, "Service Location Fax Number");
            //
            resp.SvcCountiesGroup100x = GetStringFieldValue(InputLine, 5402, 2300, "Servicing Counties Group (100x)");
            //
            resp.HONetworkLead               = GetStringFieldValue(InputLine, 7702, 1, "HO Network Lead");
            resp.HODomainHousingSvcProvInd   = GetStringFieldValue(InputLine, 7704, 1, "HO Domain Housing Service Provider");
            resp.HODomainInterPrsnSafetyInd  = GetStringFieldValue(InputLine, 7705, 1, "HO Domain Interpersonal Safety or Toxic Stress Services Provider");
            resp.HOFoodSvcProvInd            = GetStringFieldValue(InputLine, 7706, 1, "HO Domain Food and Nutrition Services Provider");
            resp.HODomainTrnsprtSvcProvInd   = GetStringFieldValue(InputLine, 7707, 1, "HO Domain Transportation Services Provider");
            resp.HOCrossDomainSvcProvInd     = GetStringFieldValue(InputLine, 7708, 1, "HO Cross-Domain Services Provider");
           
            resp.Hours24Ind                  = GetStringFieldValue(InputLine, 7709, 1, "24 Hour Indicator");

            resp.MonAMFrmHr                  = GetStringFieldValue(InputLine, 7710, 4, "Monday AM From Hour");
            resp.MonAMToHr                   = GetStringFieldValue(InputLine, 7714, 4, "Monday AM To Hour");
            resp.MonPMFrmHr                  = GetStringFieldValue(InputLine, 7718, 4, "Monday PM From Hour");
            resp.MonPMToHr                   = GetStringFieldValue(InputLine, 7722, 4, "Monday PM To Hour");
            //
            resp.MonAMFrmHr = GetStringFieldValue(InputLine, 7710, 4, "Monday AM From Hour");
            resp.MonAMToHr = GetStringFieldValue(InputLine, 7714, 4,  "Monday AM To Hour");
            resp.MonPMFrmHr = GetStringFieldValue(InputLine, 7718, 4, "Monday PM From Hour");
            resp.MonPMToHr = GetStringFieldValue(InputLine, 7722, 4,  "Monday PM To Hour");
            //
            resp.TueAMFrmHr = GetStringFieldValue(InputLine, 7726, 4, "Tuesday AM From Hour");
            resp.TueAMToHr = GetStringFieldValue(InputLine, 7730, 4,  "Tuesday AM To Hour");
            resp.TuePMFrmHr = GetStringFieldValue(InputLine, 7734, 4, "Tuesday PM From Hour");
            resp.TuePMToHr = GetStringFieldValue(InputLine, 7738, 4,  "Tuesday PM To Hour");
            //
            resp.WedAMFrmHr = GetStringFieldValue(InputLine, 7742, 4, "Wednesday AM From Hour");
            resp.WedAMToHr = GetStringFieldValue(InputLine, 7746, 4,  "Wednesday AM To Hour");
            resp.WedPMFrmHr = GetStringFieldValue(InputLine, 7750, 4, "Wednesday PM From Hour");
            resp.WedPMToHr = GetStringFieldValue(InputLine, 7754, 4,  "Wednesday PM To Hour");
            //
            resp.ThuAMFrmHr = GetStringFieldValue(InputLine, 7758, 4, "Thursday AM From Hour");
            resp.ThuAMToHr = GetStringFieldValue(InputLine, 7762, 4,  "Thursday AM To Hour");
            resp.ThuPMFrmHr = GetStringFieldValue(InputLine, 7766, 4, "Thursday PM From Hour");
            resp.ThuPMToHr = GetStringFieldValue(InputLine, 7770, 4,  "Thursday PM To Hour");
            //
            resp.FriAMFrmHr = GetStringFieldValue(InputLine, 7774, 4, "Friday AM From Hour");
            resp.FriAMToHr = GetStringFieldValue(InputLine, 7778, 4,  "Friday AM To Hour");
            resp.FriPMFrmHr = GetStringFieldValue(InputLine, 7782, 4, "Friday PM From Hour");
            resp.FriPMToHr = GetStringFieldValue(InputLine, 7786, 4,  "Friday PM To Hour");
            //
            resp.SatAMFrmHr = GetStringFieldValue(InputLine, 7790, 4, "Saturday AM From Hour");
            resp.SatAMToHr = GetStringFieldValue(InputLine, 7794, 4,  "Saturday AM To Hour");
            resp.SatPMFrmHr = GetStringFieldValue(InputLine, 7798, 4, "Saturday PM From Hour");
            resp.SatPMToHr = GetStringFieldValue(InputLine, 7802, 4,  "Saturday PM To Hour");
            //
            resp.SunAMFrmHr = GetStringFieldValue(InputLine, 7806, 4, "Sunday AM From Hour");
            resp.SunAMToHr = GetStringFieldValue(InputLine, 7810, 4,  "Sunday AM To Hour");
            resp.SunPMFrmHr = GetStringFieldValue(InputLine, 7814, 4, "Sunday PM From Hour");
            resp.SunPMToHr = GetStringFieldValue(InputLine, 7818, 4,  "Sunday PM To Hour");
            // resp.Property = GetStringFieldValue(InputLine, 1469, 1, "Property");

            resp.ProvLangCodeGroup33x    = GetStringFieldValue(InputLine, 7822, 66, "Provider Language Group (33x)");
            
            resp.MaleAgeGroupcode        = GetStringFieldValue(InputLine, 7888, 2, "Male Age Group Code");
            resp.FemaleAgeGroupcode      = GetStringFieldValue(InputLine, 7890, 2, "Female Age Group Code");
            resp.AcceptNewPatientInd     = GetStringFieldValue(InputLine, 7892, 1, "Accepting New Patients Indicator");
            resp.AcceptSiblingPatientInd = GetStringFieldValue(InputLine, 7893, 1, "Property");

            resp.WheelchairAccessibleInd = GetStringFieldValue(InputLine, 7894, 1, "Physical Handicap Wheelchair Accessible Indicator");
            resp.LangInterpreterInd      = GetStringFieldValue(InputLine, 7895, 1, "Language Interpreter Indicator");
            resp.BrailleSvcInd           = GetStringFieldValue(InputLine, 7896, 1, "Braille Services Indicator");
            resp.SignlangSvcInd          = GetStringFieldValue(InputLine, 7897, 1, "Sign Language Services Indicator ");
            resp.BHDisruptiveSvcInd      = GetStringFieldValue(InputLine, 7898, 1, "Behaviorally Disruptive Services Indicator ");
            resp.DeafHearingSvcInd       = GetStringFieldValue(InputLine, 7899, 1, "Deaf Hearing Impaired Services Indicator ");
            resp.PhyhandicappedSvcInd    = GetStringFieldValue(InputLine, 7900, 1, "Physically Handicapped Services Indicator ");
            resp.BlindSvcInd    = GetStringFieldValue(InputLine, 7901, 1, "Blind Visually Impaired Services Indicator");
            resp.IDSvcInd = GetStringFieldValue(InputLine, 7902, 1, "Intellectual and Development Disability Services Indicator");
            resp.SASvcInd     = GetStringFieldValue(InputLine, 7903, 1, "Sexually Aggressive Services Indicator");
            resp.TDDTTYEquipInd         = GetStringFieldValue(InputLine, 7904, 1, "TDD TTY Equipped Indicator");

            resp.DHHSBHTCMType          = GetStringFieldValue(InputLine, 7905, 1, "DHHS BH TCM Type");
            resp.DHHSBHTCMEffectiveDt   = GetStringFieldValue(InputLine, 7906, 10, "DHHS BH TCM Effective Date");
            resp.DHHSBHTCMEndDt         = GetStringFieldValue(InputLine, 7916, 1, "DHHS BH TCM End Date");
            resp.HIEIndicator           = GetStringFieldValue(InputLine, 7926, 2, "HIE Indicator");
            resp.HIEEffectiveDt         = GetStringFieldValue(InputLine, 7928, 10, "HIE Effective Date");
            resp.HIEEnddt               = GetStringFieldValue(InputLine, 7938, 10, "HIE End Date");
           

            return resp;


        }

        //string PEFMasterDTOTblname , string PEFVendorDTOTblName
        public static void CreateSqlTblforPEF( )
        {
            try {
                var dbFactory = new OrmLiteConnectionFactory(_MHdbConnStr, SqlServerDialect.Provider);

                using (var db = dbFactory.Open())
                {
                    // Create a d/b table with a DTO class 
                   // db.CreateTableIfNotExists<PEFRespModel>();
                    
                    db.CreateTableIfNotExists<PEFMasterDTO>();
                    db.CreateTableIfNotExists<PEFVendorDTO>();

                    //Create a table with a specific  d/b Schema 
                    //  db.CreateSchema("Schema");
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }


        #region REPEAT- Logic 
        public static string GetStringFieldValueforRepeat(string lineData, string fieldName)
        {
            switch(fieldName)
            {
                case "CustEssentialProvIndGroup5x":


                default:
                    Console.WriteLine("Nothing");
                    break;

            }
            //var splitString = lineData.Substring(startPos - 1, length);
            //if (String.IsNullOrEmpty(splitString) || String.IsNullOrWhiteSpace(splitString))
            //{
            //    return null;
            //}
            //else
            //{
            //    return splitString.Trim();
            //}



            return string.Empty;
        }

        #endregion

    }
}
