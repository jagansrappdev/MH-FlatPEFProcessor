using MH.PEF.Models.PEF;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.BLL.Utilities
{
    //
    public static class PEFUtilities
    {

        private static readonly string _MHdbConnStr;
        private static readonly string _MHPEFdbConnStr;

        static PEFUtilities()
        {
            _MHdbConnStr = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["JaganLocalDB"].ConnectionString).ToString();
            /* // For Async : 
              SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["JaganLocalDB"].ConnectionString){ AsynchronousProcessing = true}.ToString()
             */
            _MHPEFdbConnStr = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["MHPEFDBLocal"].ConnectionString).ToString();
        }

        public static string GetStringValue(string lineData, int startPos, int length, string fieldName)
        {
            var splitString = lineData.Substring(startPos - 1, length);
            if (String.IsNullOrEmpty(splitString) || String.IsNullOrWhiteSpace(splitString))
            {
                return null;
            }
            else
            {
                return splitString.Trim();
            }

        }

        public static string GetStringValueNOTrim(string lineData, int startPos, int length, string fieldName)
        {
            var splitString = lineData.Substring(startPos - 1, length);
            if (String.IsNullOrEmpty(splitString) || String.IsNullOrWhiteSpace(splitString))
            {
                return null;
            }
            else
            {
                return splitString;
            }

        }


        public static string GetStringValueTrimEND(string lineData, int startPos, int length, string fieldName)
        {
            var splitString = lineData.Substring(startPos - 1, length);
            if (String.IsNullOrEmpty(splitString) || String.IsNullOrWhiteSpace(splitString))
            {
                return null;
            }
            else
            {
                return splitString.TrimEnd();
            }

        }

        //PEFUtilities.GetStringValue

        public static List<string> GetAllFilesFromDir(string src)
        {
            var resp = new List<string>();
            var txtFiles = Directory.EnumerateFiles(src, "*.txt");
            foreach (string currentFile in txtFiles)
            {
                var filepath = currentFile;
                resp.Add(filepath);
            }
            return resp;
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


        //Class to DT
        public static DataTable ClassToDataTable<T>(T InputList)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

          //  foreach (var item in InputList)
          //  {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(InputList) ?? DBNull.Value;

                table.Rows.Add(row);
          //  }
            return table;
        }




        //
        public static void PerformDBInsertion(DataTable InputTbl, string DbTblname)
        {
            try
            {

                // using (var connection = new SqlConnection(_MHdbConnStr))
                using (var connection = new SqlConnection(_MHPEFdbConnStr))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
                    {
                        bulkCopy.BatchSize = 100;
                        bulkCopy.DestinationTableName = DbTblname;
                        //"dbo.PEFRespModel2";
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
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void CreateSqlTblforPEFFile()
        {
            try
            {
                // var dbFactory = new OrmLiteConnectionFactory(_MHdbConnStr, SqlServerDialect.Provider);
                var dbFactory = new OrmLiteConnectionFactory(_MHPEFdbConnStr, SqlServerDialect.Provider);

                using (var db = dbFactory.Open())
                {
                    // Create a d/b table with a DTO class 
                    // db.CreateTableIfNotExists<PEFRespModel>();

                    db.CreateTableIfNotExists<PEFMasterDTO>();
                    // Repeat groups

                    db.CreateTableIfNotExists<PEFDhhsAMhTierInfoGrp5xDTO>();
                    //
                    db.CreateTableIfNotExists<PEFProvTaxonomyGrp>();
                    //
                    db.CreateTableIfNotExists<PEFProvBizTypeGrp3xDTO>();
                    //
                    db.CreateTableIfNotExists<PEFProvAffilGroupDTO>();
                    //
                    db.CreateTableIfNotExists<PEFSvcCountiesGrp100xDTO>();

                    //Create a table with a specific  d/b Schema 
                    //  db.CreateSchema("Schema");
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void CreateSqlTblforPEFRepeatGroups()
        {
            try
            {
                var dbFactory = new OrmLiteConnectionFactory(_MHdbConnStr, SqlServerDialect.Provider);

                using (var db = dbFactory.Open())
                {
                    db.CreateTableIfNotExists<PEFProvTaxonomyGrp>();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

    }
}
