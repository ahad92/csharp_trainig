﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Xml.Serialization;
using WebaddressbookTests;
namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            string filename = args[1];
            string format = args[2];
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10),
                });
            }
            if (format == "excel")
            {
                WriteGroupsToExcellFile(groups, filename);
            }
            else
            {
                StreamWriter writer = new StreamWriter(filename);
                if (format == "csv")
                {
                    WriteGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    WriteGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    WriteGroupsToJsonlFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }
                writer.Close();
            }
        }
        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }
        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        static void WriteGroupsToJsonlFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Formatting.Indented));
        }
        static void WriteGroupsToExcellFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;
            sheet.Cells[1, 1] = "test";
            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);
        }
    }
}




























