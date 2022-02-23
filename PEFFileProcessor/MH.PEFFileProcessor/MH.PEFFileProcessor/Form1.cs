using MH.PEF.BLL;
using MH.PEF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MH.PEFFileProcessor
{
    public partial class Form1 : Form
    {
        public string PEFFilePath = @"C:\InputFiles\PEF-01.txt";
        public string PEFFullFilePath = @"C:\InputFiles\PEFfullFile.txt";
        public string PEFOutputFilespath = @"C:\Outputfiles";
        //  public string csvfilePath = @"C:\InputFiles\CSVExport\provs100.csv";
        public string csvfilePath = @"C:\InputFiles\CSVExport\";
        // Read single file 
        public string PEFOutputFile1Path = @"C:\Outputfiles\PEFfile1.txt";

        public Form1()
        {
            InitializeComponent();
        }

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}

        #region Button Events 
        private void btnProcessPEFtoDB_Click(object sender, EventArgs e)
        {
            try
            {

                var SplittedFiles = GetAllFilesFromDir(PEFOutputFilespath);

                //Declare
                var respObj = new List<PEFRespModel>();
                // Read File 
                //  List<string> allPEFLines = File.ReadAllLines(PEFFilePath).ToList();
                List<string> allPEFLines = new List<string>();
                foreach (string line in File.ReadLines(PEFOutputFile1Path))
                {
                    // single line processing logic
                    var item = ReadPEFLine(line);
                    respObj.Add(item);
                }

                // Read File 
                //List<string> allPEFLines = File.ReadAllLines(PEFFilePath).ToList();
                //foreach (var line in allPEFLines)
                //{
                //    //  respObj.Add();
                //    var item = ReadPEFLine(line);
                //    respObj.Add(item);
                //}

                // Insert to databse 
                if (respObj.Any())
                {
                    var dt = ProcessPEFData.ToDataTable(respObj);
                    //Export to csv 
                    MyDataTableExtensions.WriteToCsvFile(dt , csvfilePath);
                  // ProcessPEFData.PerformDBInsertion(dt);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void btnCountLines_Click(object sender, EventArgs e)
        {
            try
            { // int count = File.ReadAllLines(PEFFullFilePath).Length;
                var lineCount = File.ReadLines(PEFFullFilePath).Count();
                rtb_Status.Text = lineCount.ToString();

            }
            catch (Exception ex)
            {
                Display(ex.ToString());
            }

        }

        private void btnSplitFile_Click(object sender, EventArgs e)
        {
            var FilesCount = GetFileCount(PEFOutputFilespath);
            if (FilesCount > 0)
            {
                Display("Files Exist already !! Please clean the folder !!!!");
            }
            else
            {
                var reader = File.OpenText(PEFFullFilePath);
                string outFileName = @"C:\Outputfiles\PEFfile{0}.txt";
                int outFileNumber = 1;
                const int MAX_LINES = 33119;
                while (!reader.EndOfStream)
                {
                    var writer = File.CreateText(string.Format(outFileName, outFileNumber++));
                    for (int idx = 0; idx < MAX_LINES; idx++)
                    {
                        writer.WriteLine(reader.ReadLine());
                        if (reader.EndOfStream) break;
                    }
                    writer.Close();
                }

                reader.Close();
                // confirm the spliting and show message 
                var splitCount = GetFileCount(PEFOutputFilespath);
                if (splitCount > 1)
                {
                    Display("File Split Success! " + "\n" + "Total Files : " + splitCount);
                }
            }
        }


        #endregion


        #region Helper Methods 

        public void Display(string linetoshow)
        {
            rtb_Status.AppendText(linetoshow);
        }

        private int GetFileCount(string s)
        {
            return Directory.GetFiles(s, "*.txt").Count() + Directory.GetDirectories(s).Select(GetFileCount).Sum();
        }

        private List<string> GetAllFilesFromDir(string src)
        {
            var resp = new List<string>();
            var txtFiles = Directory.EnumerateFiles(src, "*.txt");
            foreach (string currentFile in txtFiles)
            {
                var filepath = src + currentFile;
                resp.Add(filepath);
            }
            return resp;
        }

        #endregion


        #region PEF file Processing 

        public PEFRespModel ReadPEFLine(string Line)
        {
            try
            {

            
            // Call the ProcessLine to Pick Elements 
            var res = ProcessPEFData.ProcessLine(Line);
            //1
            if (res.CustEssentialProvIndGroup5x != null)
            {
                  GetStringFieldValueforRepeat(res.CustEssentialProvIndGroup5x, "CustEssentialProvIndGroup5x", ref  res);
            }
            //2
            if (res.CustOthrProvIndGroup2x != null)
            {
                 GetStringFieldValueforRepeat(res.CustOthrProvIndGroup2x, "CustOthrProvIndGroup2x", ref res);
            }
            //3
            if (res.CustDHHSSPAMHTierGroup5x != null)
            {
                GetStringFieldValueforRepeat(res.CustDHHSSPAMHTierGroup5x, "CustDHHSSPAMHTierGroup5x", ref res);
            }
            //4
            if (res.ProvTaxonomyGroup20x != null)
            {
               GetStringFieldValueforRepeat(res.ProvTaxonomyGroup20x, "ProvTaxonomyGroup20x", ref res);
            }
            //5
            if (res.ProvBizTypeGroup3x != null)
            {
                GetStringFieldValueforRepeat(res.ProvBizTypeGroup3x, "ProvBizTypeGroup3x", ref res);
            }
            //6
            if (res.AffilOrgGroup10x != null)
            {
                GetStringFieldValueforRepeat(res.AffilOrgGroup10x, "AffilOrgGroup10x", ref res);
            }
            //7
            if (res.SvcCountiesGroup100x != null)
            {
                GetStringFieldValueforRepeat(res.SvcCountiesGroup100x, "SvcCountiesGroup100x", ref res);
            }
            //8
            if (res.ProvLangCodeGroup33x != null)
            {
                GetStringFieldValueforRepeat(res.ProvLangCodeGroup33x, "ProvLangCodeGroup33x", ref res);
            }


            //return fial response
            return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // #1. Process All Files 
        private void ProcessALLPEFfiles(List<string> pefFilespaths)
        {
            try
            {
                foreach (var file in pefFilespaths)
                {
                    var path = file;
                    //Declare
                    var respObj = new List<PEFRespModel>();
                    List<string> allPEFLines = new List<string>();
                    //read all lines 
                    foreach (string line in File.ReadLines(path))
                    {
                        // Call the ProcessLine to Pick Elements 
                        var item = ProcessPEFData.ProcessLine(line);
                        respObj.Add(item);
                    }

                    // Insert to databse 
                    if (respObj.Any())
                    {
                        var dt = ProcessPEFData.ToDataTable(respObj);
                        ProcessPEFData.PerformDBInsertion(dt);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        #endregion

        private void btnCreateDbTbl_Click(object sender, EventArgs e)
        {
            ProcessPEFData.CreateSqlTblforPEF();
        }



        #region REPEAT- Logic 
        public  void  GetStringFieldValueforRepeat(string RepeatedStr, string fieldName , ref PEFRespModel res )
        {
            try
            {

            switch (fieldName)
            {
                case "CustEssentialProvIndGroup5x":
                        if(RepeatedStr.Length > 1)
                        {
                            res.CustEssentialProvIndicator = ProcessPEFData.GetStringFieldValue(RepeatedStr ,1,2 , "Essential Provider Indicator");
                        } else
                        {
                            res.CustEssentialProvIndicator = ProcessPEFData.GetStringFieldValue(RepeatedStr, 1, 1, "Essential Provider Indicator");
                        }
                      
                        break;

                case "CustOthrProvIndGroup2x":
                        if (RepeatedStr.Length > 1)
                        {
                            res.CustOthrProvIndicator = ProcessPEFData.GetStringFieldValue(RepeatedStr, 1, 2, "Other Provider Indicator");
                        }
                        else
                        {
                            res.CustOthrProvIndicator = ProcessPEFData.GetStringFieldValue(RepeatedStr, 1, 1, "Other Provider Indicator");
                        }
                 
                    break;


                case "CustDHHSSPAMHTierGroup5x":
                    res.DHHSSpAMHTierTypeCode = ProcessPEFData.GetStringFieldValue(RepeatedStr, 1, 1, "DHHS SP AMH Tier Type Code");
                    res.DHHSSpAMHTierEffectiveDt = ProcessPEFData.GetStringFieldValue(RepeatedStr, 2, 10, "DHHS SP AMH Tier Type Effective Date");
                    res.DHHSSpAMHTierEndDt = ProcessPEFData.GetStringFieldValue(RepeatedStr, 12, 10, "DHHS SP AMH Tier Type End Date");
                    break;

                case "ProvTaxonomyGroup20x":
                    res.TaxonomyCode               = ProcessPEFData.GetStringFieldValue(RepeatedStr, 1, 10,  "Taxonomy Code");
                    res.TaxonomyLvl2Code           = ProcessPEFData.GetStringFieldValue(RepeatedStr, 11, 10, "Taxonomy Level 2 Code");
                    res.TaxonomyLvl3Code           = ProcessPEFData.GetStringFieldValue(RepeatedStr, 21, 10, "Taxonomy Level 3 Code");
                    res.TaxonomyCodeStatusCurrent  = ProcessPEFData.GetStringFieldValue(RepeatedStr, 22, 1,  "Taxonomy Code Status Current");
                    res.TaxonomyCodeEffDateCurrent = ProcessPEFData.GetStringFieldValue(RepeatedStr, 23, 10, "Taxonomy Code Effective Date Current");
                    res.TaxonomyCodeEndDateCurrent = ProcessPEFData.GetStringFieldValue(RepeatedStr, 33, 10, "Taxonomy Code End Date Current");
                    res.TaxonomyCodeStatusPrev01   = ProcessPEFData.GetStringFieldValue(RepeatedStr, 43, 1,  "Taxonomy Code Status Previous1");
                    res.TaxonomyCodeEffDatePrev01  = ProcessPEFData.GetStringFieldValue(RepeatedStr, 44, 10, "Taxonomy Code Effective Date Previous1");
                    res.TaxonomyCodeEndDatePrev01  = ProcessPEFData.GetStringFieldValue(RepeatedStr, 54, 10, "Taxonomy Code Effective Date Previous2");
                    res.TaxonomyCodeStatusPrev02   = ProcessPEFData.GetStringFieldValue(RepeatedStr, 64, 1, "Taxonomy Code Status Previous2");
                    res.TaxonomyCodeEffDatePrev02  = ProcessPEFData.GetStringFieldValue(RepeatedStr, 65, 10, "Taxonomy Code Effective Date Previous2");
                    res.TaxonomyCodeEndDatePrev02  = ProcessPEFData.GetStringFieldValue(RepeatedStr, 75, 10, "Taxonomy Code End Date Previous2");
                    res.TaxonomyCodeRetroTrigger   = ProcessPEFData.GetStringFieldValue(RepeatedStr, 85, 10, "Retrodate Trigger for Taxonomy");
                    //Reset the main string : only here for now 
                    res.ProvTaxonomyGroup20x = "JaganTest";
                    break;

                //
                case "ProvBizTypeGroup3x":
                    res.ProvBizTypeCode = ProcessPEFData.GetStringFieldValue(RepeatedStr, 1, 1, "Provider Business Type Code");
                    res.ProvBizTypeBeginDt = ProcessPEFData.GetStringFieldValue(RepeatedStr, 2, 10, "Provider Business Type Begin Date");
                    res.ProvBizTypeEndDt = ProcessPEFData.GetStringFieldValue(RepeatedStr, 11, 10, "Provider Business Type End Date");
                    break;

                //
                case "AffilOrgGroup10x":
                    res.AffilOrgTypeCode    = ProcessPEFData.GetStringFieldValue(RepeatedStr, 1, 2, "Affiliated Organization Type Code");
                    res.AffilOrgNPI         = ProcessPEFData.GetStringFieldValue(RepeatedStr, 2, 10, "Affiliated Organization NPI/Atypical");
                    res.AffilOrgTaxId       = ProcessPEFData.GetStringFieldValue(RepeatedStr, 12, 50, "Affiliated Organization Tax Id");
                    res.AffilOrgName        = ProcessPEFData.GetStringFieldValue(RepeatedStr, 62, 50, "Affiliated Organization Name");
                    res.AffilOrgSvcLocation = ProcessPEFData.GetStringFieldValue(RepeatedStr, 112, 3, "Affiliated Organization Service Location Code");
                    res.AffilOrgBeginDt     = ProcessPEFData.GetStringFieldValue(RepeatedStr, 115, 10, "Affiliated Organization Begin Date");
                    res.AffilOrgEndDt       = ProcessPEFData.GetStringFieldValue(RepeatedStr, 125, 10, "Affiliated Organization End Date");
                   
                    break;

                //
                case "SvcCountiesGroup100x":
                    res.SvcCountyCode = ProcessPEFData.GetStringFieldValue(RepeatedStr, 1, 3, "Servicing County Code");
                    res.SvcCountyBeginDt = ProcessPEFData.GetStringFieldValue(RepeatedStr, 3, 10, "Servicing County Begin Date");
                    res.SvcCountyEndDt = ProcessPEFData.GetStringFieldValue(RepeatedStr, 13, 10, "Servicing County End Date");
                    break;

                //
                case "ProvLangCodeGroup33x":
                    res.ProvLanguage = ProcessPEFData.GetStringFieldValue(RepeatedStr, 1, 2, "Provider Language");
                    break;


                default:
                   // Console.WriteLine("Nothing");
                    break;

            }
           }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

    }
}

