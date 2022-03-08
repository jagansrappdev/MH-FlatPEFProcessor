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

        private void btnCountLines_Click(object sender, EventArgs e)
        {
            try
            { // int count = File.ReadAllLines(PEFFullFilePath).Length;
                var lineCount = File.ReadLines(PEFFullFilePath).Count();
                // rtb_Status.Text = );
                Display("!Total Lines in selected-File = " + lineCount.ToString() + "\n");

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
                Display("\n" + "! DB Tables Creation completed ! " + "\n");
            }
            catch (Exception ex)
            {
                Display("!!!! BAD:  error in DB Tables Creation ! " + "\n" + ex.ToString());
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
                //  var PEFInputSPlitFile1 = @"C:\PEFRepeatSplitFiles\PEFfile1.txt";
                //Read all files  
                var InputSplitFiles = @"C:\New20kOutputFiles";
                var pefAllSplitFilespath = PEFUtilities.GetAllFilesFromDir(InputSplitFiles);

                foreach (var fItem in pefAllSplitFilespath)
                {

                    //For each Line 
                    foreach (string line in File.ReadLines(fItem))
                    {
                        var rptItem = PEFProcessorLogic.ParsePefRepeatline(line);

                        // process Dhhs Sp AMH repeat
                        if (!string.IsNullOrEmpty(rptItem.DhhsSpAmhTierInfoGroup5x))
                        {
                            var DhhsSpResp = PEFProcessorLogic.GetDhhsAMhTierInfoGrpList(rptItem, DhhsSPAmhChunkSize, dhhsSpRptTImes);
                            // insert to d/b
                            if (DhhsSpResp.Any())
                            {
                                var dt = PEFUtilities.ToDataTable(DhhsSpResp);
                                PEFUtilities.PerformDBInsertion(dt, "dbo.PEFDhhsAMhTierInfoGrp5xDTO");
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
                                var dt = PEFUtilities.ToDataTable(ProvBizTypeResp);
                                PEFUtilities.PerformDBInsertion(dt, "dbo.PEFProvBizTypeGrp3xDTO");
                            }
                        }
                        // Affil Group
                        if (!string.IsNullOrEmpty(rptItem.AffilOrgGroup10x))
                        {
                            var AffilOrgGrpList = PEFProcessorLogic.GetProvAffilGroupList(rptItem, AffilOrgGroupChunkSize, AffilOrgRptTimes);
                            // insert to d/b
                            if (AffilOrgGrpList.Any())
                            {
                                var dt = PEFUtilities.ToDataTable(AffilOrgGrpList);
                                PEFUtilities.PerformDBInsertion(dt, "dbo.PEFProvAffilGroupDTO");
                            }
                        }
                        //
                        if (!string.IsNullOrEmpty(rptItem.SvcCountiesGroup100x))
                        {
                            var SvcCountieGrpList = PEFProcessorLogic.GetSvcCountiesGrpList(rptItem, SvcCountiesChunkSize, SvcCountiesRptTimes);
                            // insert to d/b
                            if (SvcCountieGrpList.Any())
                            {
                                var dt = PEFUtilities.ToDataTable(SvcCountieGrpList);
                                PEFUtilities.PerformDBInsertion(dt, "dbo.PEFSvcCountiesGrp100xDTO");
                            }
                        }
                    }


                    // end of files- loops 
                }

                //display a message 
                Display("--------- All Repeating groups Iterations completed !!------ " + "\n");

            }
            catch (Exception ex)
            {
                Display("\n" + "!! >> error in Process_repeatgrp_Click() ! " + "\n" + ex.ToString());
            }

        }

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
                foreach (var fItem in pefAllSplitFilespath)
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



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnProcessFailedRptGroups_Click(object sender, EventArgs e)
        {
            // chunk sizes & no.of times that repeats repeating groups
            var DhhsSPAmhChunkSize = 21;
            var dhhsSpRptTImes = 5;
            //Read all files  
            var InputSplitFiles = @"C:\New20kOutputFiles";
              var pefAllSplitFilespath = PEFUtilities.GetAllFilesFromDir(InputSplitFiles);
            // test 
          //  var pefAllSplitFilespath = @"C:\New20kOutputFiles\PEFfile1.txt";
          try
            {
                foreach (var fItem in pefAllSplitFilespath)
                {
                    //For each Line 
                    foreach (string line in File.ReadLines(fItem))
                    {
                        var rptItem = PEFProcessorLogic.ParsePefRepeatline(line);

                        // process Dhhs Sp AMH repeat
                        if (!string.IsNullOrEmpty(rptItem.DhhsSpAmhTierInfoGroup5x))
                        {
                            var DhhsSpResp = PEFProcessorLogic.GetDhhsAMhTierInfoGrpList(rptItem, DhhsSPAmhChunkSize, dhhsSpRptTImes);
                            // insert to d/b
                            if (DhhsSpResp.Any())
                            {
                                var dt = PEFUtilities.ToDataTable(DhhsSpResp);
                                PEFUtilities.PerformDBInsertion(dt, "dbo.PEFDhhsAMhTierInfoGrp5xDTO");
                            }
                        }
                    }
                }
                //display a message 
                Display("--------- All Failed  groups Iterations completed !!------ " + "\n");
            }
            catch (Exception ex)
            {
                Display("\n" + "!! >> error in Process_repeatgrp_Click() ! " + "\n" + ex.ToString());
            }

           
        }


    }
}

