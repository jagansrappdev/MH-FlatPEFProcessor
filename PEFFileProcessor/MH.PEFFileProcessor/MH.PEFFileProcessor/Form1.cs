using MH.PEF.BLL;
using MH.PEF.BLL.BizLogic;
using MH.PEF.BLL.Utilities;
using MH.PEF.Models;
using MH.PEF.Models.PEF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MH.PEFFileProcessor
{
    public partial class Form1 : Form
    {
        // declarations 
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
                    //  MyDataTableExtensions.WriteToCsvFile(dt , csvfilePath);
                    ProcessPEFData.PerformDBInsertion(dt);

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
            var PEFOpFilespath = @"C:\New20kOutputFiles";
         //   var PEFOpFilespath = @"C:\PEFRepeatSplitFiles";
            var FilesCount = GetFileCount(PEFOpFilespath);
            if (FilesCount > 0)
            {
                Display("Files Exist already !! Please clean the folder !!!!");
            }
            else
            {
                var reader = File.OpenText(PEFFullFilePath);
                //  string outFileName = @"C:\Outputfiles\PEFfile{0}.txt";
                //  string outFileName = @"C:\PEFRepeatSplitFiles\PEFfile{0}.txt";
                string outFilesPathWithName = @"C:\New20kOutputFiles\PEFfile{0}.txt";
                int outFileNumber = 1;
                const int MAX_LINES = 20000;
                // const int MAX_LINES = 33119;
                while (!reader.EndOfStream)
                {
                    var writer = File.CreateText(string.Format(outFilesPathWithName, outFileNumber++));
                    for (int idx = 0; idx < MAX_LINES; idx++)
                    {
                        writer.WriteLine(reader.ReadLine());
                        if (reader.EndOfStream) break;
                    }
                    writer.Close();
                }

                reader.Close();


                // confirm the spliting and show message 
                var SplittedFilespath = @"C:\New20kOutputFiles";
                var splitCount = GetFileCount(SplittedFilespath);
                if (splitCount > 1)
                {
                    Display("File Split Success! " + "\n" + "Total Files : " + splitCount);
                }
            }
        }

        private void btnCreateDbTbl_Click(object sender, EventArgs e)
        {
            try
            {
                //#1
                PEFUtilities.CreateSqlTblforPEFFile();

                //Print msg
                Display("! DB Tables Creation completed ! " + "\n");
            }
            catch (Exception ex)
            {
                Display("!!!! BAD:  error in DB Tables Creation ! " + "\n" + ex.ToString());
                // throw ex;
            }


        }

        private void btn1SplitPEfFileProcess_Click(object sender, EventArgs e)
        {

            try
            {
                var respObj = new List<PEFMasterDTO>();
                // vendor table 
                //   var respVendorObj = new List<PEFVendorDTO>();
                // 
                //     int MhTrnxId = 0;



                //Read all files  
                // var pefAllSplitFilespath = PEFUtilities.GetAllFilesFromDir(PEFOutputFilespath);
                // var totals = pefAllSplitFilespath.Count();


                // foreach (var sp in pefAllSplitFilespath)
                //  {
                // var sp = pefAllSplitFilespath.ElementAt(2);

                // Read single file 
                var PEFOutputFilePath = @"C:\Outputfiles\PEFfile21.txt";


                foreach (string line in File.ReadLines(PEFOutputFilePath))
                {
                    // read single line 
                    var item = PEFProcessorLogic.ProcessPEFMasterDTOLine(line);
                    respObj.Add(item);
                }

                // Insert to databse 
                if (respObj.Any())
                {
                    var dt = PEFUtilities.ToDataTable(respObj);
                    //Export to csv 
                    //  MyDataTableExtensions.WriteToCsvFile(dt , csvfilePath);
                    PEFUtilities.PerformDBInsertion(dt, "dbo.PEFMasterDTO");
                }

                //Set vendor table 
                //if (respObj.Any())
                //{
                //    // filter criteria for vendor table 
                //    var filteredAffilGroup = respObj.Where(x => x.AffilOrgGroup10x != null 
                //                                                && ( x.ProvEnrollmentType == "2" || x.ProvEnrollmentType == "4" )).ToList();
                //    foreach (var item in filteredAffilGroup)
                //    {
                //        // Set Vendor Tbl data : only whne EnrollType == 2 Or 4
                //        if (item.ProvEnrollmentType == "2" || item.ProvEnrollmentType == "4")
                //        {
                //            if (!string.IsNullOrEmpty(item.AffilOrgGroup10x))
                //            {
                //                var vendoritems = PEFProcessorLogic.ProcessPEFVendorDTO(item, MhTrnxId);
                //                respVendorObj.AddRange(vendoritems);
                //                //increment counter 
                //                MhTrnxId++;
                //            }

                //        }
                //    }
                //}


                //    }
                Display("DB Operation Completed  " + "\n");

            }
            catch (Exception ex)
            {
                Display("!error in ProcessALLPEFfiles:! " + "\n" + ex.ToString());
                // throw ex;
            }

        }

        //Process all repeating groups per file 
        private void btn_Process_repeatgrp_Click(object sender, EventArgs e)
        {
            // chunk sizes & no.of times that repeats repeating groups
            var DhhsSPAmhChunkSize = 21;
            var dhhsSpRptTImes = 5;
            // removed the filler size in chunk size 
            var TaxonomyChunkSize = 103;
            var taxonmyRptTimes = 20;
            // Prov Biz Type 
            var ProvBizTypeGrpChunkSize = 21;
            var ProvBizTypeGrpRptTimes = 3;
            // affil 
            var AffilOrgGroupChunkSize = 135;
            var AffilOrgRptTimes = 10;
            // 
            var SvcCountiesChunkSize = 23;
            var SvcCountiesRptTimes = 100;


            try
            {
                //Read a Single  input file 
                var PEFInputSPlitFile1 = @"C:\PEFRepeatSplitFiles\PEFfile1.txt";
                //For each Line 
                foreach (string line in File.ReadLines(PEFInputSPlitFile1))
                {
                    var rptItem = PEFProcessorLogic.ParsePefRepeatline(line);

                    // process Dhhs Sp AMH repeat
                    if ( !string.IsNullOrEmpty(  rptItem.DhhsSpAmhTierInfoGroup5x))
                    {
                        var DhhsSpResp = PEFProcessorLogic.GetDhhsAMhTierInfoGrpList(rptItem, DhhsSPAmhChunkSize , dhhsSpRptTImes);
                        // insert to d/b
                        if (DhhsSpResp.Any())
                        {
                         //   var dt = PEFUtilities.ToDataTable(DhhsSpResp);
                         //   PEFUtilities.PerformDBInsertion(dt, "dbo.PEFDhhsAMhTierInfoGrp5xDTO");
                        }
                    }
                    // process Taxonomy 
                    if (!string.IsNullOrEmpty(rptItem.ProvTaxonomyGroup20x))
                    {
                        // Get List of Prov-Taxonmy group lines 
                        var pefTxnmyResp = PEFProcessorLogic.ProcessPEFTaxonomyGrpDTOItem(rptItem, TaxonomyChunkSize, taxonmyRptTimes);
                        // insert to d/b
                        if (pefTxnmyResp != null)
                        {
                            var dt = PEFUtilities.ToDataTable(pefTxnmyResp);
                            PEFUtilities.PerformDBInsertion(dt, "dbo.PEFProvTaxonomyGrp");
                        }
                    }
                    // prov Biz type :
                    if (!string.IsNullOrEmpty(rptItem.ProvBizTypeGroup3x))
                    {
                        var ProvBizTypeResp = PEFProcessorLogic.GetProvBizTypeGrpList(rptItem, ProvBizTypeGrpChunkSize, ProvBizTypeGrpRptTimes);
                        // insert to d/b
                        if (ProvBizTypeResp.Any())
                        {
                            //   var dt = PEFUtilities.ToDataTable(DhhsSpResp);
                            //   PEFUtilities.PerformDBInsertion(dt, "dbo.PEFDhhsAMhTierInfoGrp5xDTO");
                        }
                    }
                    // Affil Group
                    if (!string.IsNullOrEmpty(rptItem.AffilOrgGroup10x))
                    {
                        var AffilOrgGrpList = PEFProcessorLogic.GetProvAffilGroupList(rptItem, AffilOrgGroupChunkSize, AffilOrgRptTimes);
                        // insert to d/b
                        if (AffilOrgGrpList.Any())
                        {
                            //   var dt = PEFUtilities.ToDataTable(DhhsSpResp);
                            //   PEFUtilities.PerformDBInsertion(dt, "dbo.PEFDhhsAMhTierInfoGrp5xDTO");
                        }
                    }
                    //
                    if (!string.IsNullOrEmpty(rptItem.SvcCountiesGroup100x))
                    {
                        var SvcCountieGrpList = PEFProcessorLogic.GetSvcCountiesGrpList(rptItem, SvcCountiesChunkSize, SvcCountiesRptTimes);
                        // insert to d/b
                        if (SvcCountieGrpList.Any())
                        {
                            //   var dt = PEFUtilities.ToDataTable(DhhsSpResp);
                            //   PEFUtilities.PerformDBInsertion(dt, "dbo.PEFDhhsAMhTierInfoGrp5xDTO");
                        }
                    }
                }
                    // 1 
                 //   RunProvTaxonomy20xProcess(TaxonomyChunkSizeTax);

                Display("PEF Taxonly Group Insertion Completed  " + "\n");

            }
            catch (Exception ex)
            {
                Display("!error in ProcessALLPEFfiles:! " + "\n" + ex.ToString());
                // throw ex;
            }

        }

        //private static void RunProvTaxonomy20xProcess(int TaxonomyChunkSizeTax)
        //{
        //    var PEFOutputFilePath = @"C:\PEFRepeatSplitFiles\PEFfile1.txt";
        //    //
        //    foreach (string line in File.ReadLines(PEFOutputFilePath))
        //    {
        //        // read single line 
        //        var item = PEFProcessorLogic.ProcessPEFTaxonomyLine(line);
        //        //Check Taxonmy details exist 
        //        if (item.ProvTaxonomyGroup20x != null)
        //        {
        //            // Get List of Prov-Taxonmy group lines 
        //            var pefTxnmyResp = PEFProcessorLogic.ProcessPEFTaxonomyGrpDTOItem(item, TaxonomyChunkSizeTax);
        //            // insert to d/b
        //            if (pefTxnmyResp != null)
        //            {
        //                var dt = PEFUtilities.ToDataTable(pefTxnmyResp);
        //                PEFUtilities.PerformDBInsertion(dt, "dbo.PEFProvTaxonomyGrp");
        //            }
        //        }
        //    }
        //}


        // Process ALL PEF Files(spiltted )

        private void btnProcessAllfiles_Click(object sender, EventArgs e)
        {
            try
            {
                var InputSplitFiles = @"C:\New20kOutputFiles";
                var respObj = new List<PEFMasterDTO>();
              
                //Read all files  
                var pefAllSplitFilespath = PEFUtilities.GetAllFilesFromDir(InputSplitFiles);
                //Read file-by file 
                foreach(var fItem in pefAllSplitFilespath)
                {
                    // Read a file data 
                    foreach (string line in File.ReadLines(fItem))
                    {
                        // read single line 
                        var item = PEFProcessorLogic.ProcessPEFMasterDTOLine(line);
                        if (item != null)
                        {
                           // var dt = PEFUtilities.ToDataTable(item);
                            var dt = PEFUtilities.ClassToDataTable(item);
                          
                            PEFUtilities.PerformDBInsertion(dt, "dbo.PEFMasterDTO");
                        }
                          //  respObj.Add(item);
                    }

                }

                // Insert to databse 
                if (respObj.Any())
                {
                    var dt = PEFUtilities.ToDataTable(respObj);
                    //Export to csv 
                    //  MyDataTableExtensions.WriteToCsvFile(dt , csvfilePath);
                    PEFUtilities.PerformDBInsertion(dt, "dbo.PEFMasterDTO");

                }

            }
            catch (Exception ex)
            {
                Display("!error in ProcessALLPEFfiles:! " + "\n" + ex.ToString());
                // throw ex;
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
                var filepath = currentFile;
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
                    GetStringFieldValueforRepeat(res.CustEssentialProvIndGroup5x, "CustEssentialProvIndGroup5x", ref res);
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
        //private void ProcessALLPEFfiles(List<string> pefAllSplitFilespath)
        //{
        //    try
        //    {
        //        var respObj = new List<PEFMasterDTO>();
        //        // vendor table 
        //        var respVendorObj = new List<PEFVendorDTO>();
        //        // 
        //        int MhTrnxId = 0;


        //        // parallel 
        //        Parallel.ForEach(pefAllSplitFilespath, splitFile =>
        //        {

        //            // Read File 
        //            foreach (string line in File.ReadLines(splitFile))
        //            {
        //                // single line processing logic
        //                var item = PEFProcessorLogic.ProcessPEFMasterDTOLine(line);

        //                // Set Vendor Tbl data : only whne EnrollType == 2 Or 4
        //                if (item.ProvEnrollmentType == "2" || item.ProvEnrollmentType == "4")
        //                {
        //                    var vendoritems = PEFProcessorLogic.ProcessPEFVendorDTO(item, MhTrnxId);

        //                }

        //                // add to tbl 
        //                respObj.Add(item);

        //                //increment counter 
        //                MhTrnxId++;
        //            }
        //            Thread.Sleep(10);

        //            // Insert to databse 
        //            if (respObj.Any())
        //            {
        //                // ** Commenting out for now to test 
        //                /*
        //                var dt = ProcessPEFData.ToDataTable(respObj);
        //                ProcessPEFData.PerformDBInsertion(dt);
        //                */
        //            }
        //        } );

        //        //foreach (var file in pefFilespaths)
        //        //{
        //        //    var path = file;
        //        //    //Declare
        //        //    var respObj = new List<PEFRespModel>();
        //        //    List<string> allPEFLines = new List<string>();
        //        //    //read all lines 
        //        //    foreach (string line in File.ReadLines(path))
        //        //    {
        //        //        // Call the ProcessLine to Pick Elements 
        //        //        var item = ProcessPEFData.ProcessLine(line);
        //        //        respObj.Add(item);
        //        //    }


        //        //    // Insert to databse 
        //        //    if (respObj.Any())
        //        //    {
        //        //        var dt = ProcessPEFData.ToDataTable(respObj);
        //        //        ProcessPEFData.PerformDBInsertion(dt);
        //        //    }
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        Display("!error in ProcessALLPEFfiles:! " + "\n" + ex.ToString());
        //    }
        //}

        #endregion



        #region REPEAT- Logic 
        public void GetStringFieldValueforRepeat(string RepeatedStr, string fieldName, ref PEFRespModel res)
        {
            try
            {

                switch (fieldName)
                {
                    case "CustEssentialProvIndGroup5x":
                        if (RepeatedStr.Length > 1)
                        {
                            res.CustEssentialProvIndicator = ProcessPEFData.GetStringFieldValue(RepeatedStr, 1, 2, "Essential Provider Indicator");
                        }
                        else
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
                        res.TaxonomyCode = ProcessPEFData.GetStringFieldValue(RepeatedStr, 1, 10, "Taxonomy Code");
                        res.TaxonomyLvl2Code = ProcessPEFData.GetStringFieldValue(RepeatedStr, 11, 10, "Taxonomy Level 2 Code");
                        res.TaxonomyLvl3Code = ProcessPEFData.GetStringFieldValue(RepeatedStr, 21, 10, "Taxonomy Level 3 Code");
                        res.TaxonomyCodeStatusCurrent = ProcessPEFData.GetStringFieldValue(RepeatedStr, 22, 1, "Taxonomy Code Status Current");
                        res.TaxonomyCodeEffDateCurrent = ProcessPEFData.GetStringFieldValue(RepeatedStr, 23, 10, "Taxonomy Code Effective Date Current");
                        res.TaxonomyCodeEndDateCurrent = ProcessPEFData.GetStringFieldValue(RepeatedStr, 33, 10, "Taxonomy Code End Date Current");
                        res.TaxonomyCodeStatusPrev01 = ProcessPEFData.GetStringFieldValue(RepeatedStr, 43, 1, "Taxonomy Code Status Previous1");
                        res.TaxonomyCodeEffDatePrev01 = ProcessPEFData.GetStringFieldValue(RepeatedStr, 44, 10, "Taxonomy Code Effective Date Previous1");
                        res.TaxonomyCodeEndDatePrev01 = ProcessPEFData.GetStringFieldValue(RepeatedStr, 54, 10, "Taxonomy Code Effective Date Previous2");
                        res.TaxonomyCodeStatusPrev02 = ProcessPEFData.GetStringFieldValue(RepeatedStr, 64, 1, "Taxonomy Code Status Previous2");
                        res.TaxonomyCodeEffDatePrev02 = ProcessPEFData.GetStringFieldValue(RepeatedStr, 65, 10, "Taxonomy Code Effective Date Previous2");
                        res.TaxonomyCodeEndDatePrev02 = ProcessPEFData.GetStringFieldValue(RepeatedStr, 75, 10, "Taxonomy Code End Date Previous2");
                        res.TaxonomyCodeRetroTrigger = ProcessPEFData.GetStringFieldValue(RepeatedStr, 85, 10, "Retrodate Trigger for Taxonomy");
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
                        res.AffilOrgTypeCode = ProcessPEFData.GetStringFieldValue(RepeatedStr, 1, 2, "Affiliated Organization Type Code");
                        res.AffilOrgNPI = ProcessPEFData.GetStringFieldValue(RepeatedStr, 2, 10, "Affiliated Organization NPI/Atypical");
                        res.AffilOrgTaxId = ProcessPEFData.GetStringFieldValue(RepeatedStr, 12, 50, "Affiliated Organization Tax Id");
                        res.AffilOrgName = ProcessPEFData.GetStringFieldValue(RepeatedStr, 62, 50, "Affiliated Organization Name");
                        res.AffilOrgSvcLocation = ProcessPEFData.GetStringFieldValue(RepeatedStr, 112, 3, "Affiliated Organization Service Location Code");
                        res.AffilOrgBeginDt = ProcessPEFData.GetStringFieldValue(RepeatedStr, 115, 10, "Affiliated Organization Begin Date");
                        res.AffilOrgEndDt = ProcessPEFData.GetStringFieldValue(RepeatedStr, 125, 10, "Affiliated Organization End Date");

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


        #region Process ALL PEF Files(spiltted ) 


        //#1. Process new PEF Model / each line 
        public PEFMasterDTO ReadPEFMasterLine(string Line)
        {
            try
            {
                // Call the ProcessLine to Pick Elements 
                var res = PEFProcessorLogic.ProcessPEFMasterDTOLine(Line);
                //return final response
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // #2. 


        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //private void btnProcessAffilGrp10x_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnProcessServicingCounties100x_Click(object sender, EventArgs e)
        //{

        //}
    }
}

