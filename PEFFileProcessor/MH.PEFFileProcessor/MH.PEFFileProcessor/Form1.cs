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
        public string csvfilePath = @"C:\InputFiles\CSVExport\provs100.csv";

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
            // Call the ProcessLine to Pick Elements 
            var res = ProcessPEFData.ProcessLine(Line);
            return res;
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
    }
}

