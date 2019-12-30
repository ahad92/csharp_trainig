using System;
using System.Collections.Generic;
using WebaddressbookTests;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            string filename = args[1];
            string format = args[2];
            string type = args[3];


            List<GroupData> groups = new List<GroupData>();
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < count; i++)
            {
                if (type == "groups")
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }
                else if (type == "contacts")
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10))
                    {
                        FirstName = TestBase.GenerateRandomString(10),
                        LastName = TestBase.GenerateRandomString(10)
                    });
                }
            }

            if (format == "excel")
            {
                writeGroupsToExcelFile(groups, filename);
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
                    if (type == "groups")
                    {
                        WriteGroupsToXmlFile(groups, writer);
                    }
                    else if (type == "contacts")
                    {
                        WriteContactsToXmlFile(contacts, writer);
                    }
                }
                else if (format == "json")
                {
                    if (type == "groups")
                    {
                        WriteGroupsToJsonFile(groups, writer);
                    }
                    else if (type == "contacts")
                    {
                        WriteContactsToJsonFile(contacts, writer);
                    }
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }

                writer.Close();
            }

        }

        static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

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
            wb.Close();
            app.Visible = false;
            app.Quit();
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

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}