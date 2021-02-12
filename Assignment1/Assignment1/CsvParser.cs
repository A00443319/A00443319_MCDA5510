using Microsoft.VisualBasic.FileIO;
using System;
using System.Text.RegularExpressions;
using System.IO;

namespace SampleAssignment1
{
    class CsvParser
    {
        public void parse(String fileName)
        {
//            Console.WriteLine("File name : " + fileName);
            try
            {
                /**
                 * With output csv is open, parse sample csv files and store good records in output csv file.
                 */
                using (StreamWriter fileStreamWriter = File.AppendText(Utils.outputCsvFilePath))
                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                      parser.TextFieldType = FieldType.Delimited;
                      parser.SetDelimiters(",");
                      
                    //Process row
                      while (!parser.EndOfData)
                      {

                          string[] fields = parser.ReadFields();
                        
                            //skip header row
                            if (fields[0] == Fields.F_NAME)
                              {
                                  continue;
                              }

                            //checks null for fname,lname, phone num should be numeric and email should contain @
                            if ((fields[0] == "") || (fields[1] == "") || !(Regex.IsMatch(fields[8], @"^\d+$")) || !(fields[9].Contains('@')))
                            {
                            
                            //log bad records
                                string badRow = ""  ;
                                for (int j = 0; j < fields.Length; j++)
                                {
                                    if (j == (fields.Length - 1))
                                    {
                                        badRow += fields[j];
                                    }
                                    else
                                    {
                                        badRow += fields[j] + ",";
                                    }
                                }
                                Logger.Log(fileName + "\n{"+ badRow +"}");
                                Utils.badRecords++;
                              }
                              else
                              {
                                //store good records in output csv
                                Utils.goodRecords++;
                                string goodRow = "";
                            for (int k = 0; k < fields.Length; k++)
                                {
                                    if (k == (fields.Length - 1))
                                    {
                                        goodRow += fields[k];
                                    }
                                    else
                                    {
                                        goodRow += fields[k] + ",";
                                    }
                                }
                            fileStreamWriter.Write(goodRow);
                            fileStreamWriter.WriteLine("");
                            }   
                    }
                    fileStreamWriter.Close();
                }
            }
            catch (FileNotFoundException e)
            {
                Logger.Log("CsvParser\n"+"File not found\t" + e.Message);
            }
            catch (Exception e)
            {
                Logger.Log("CsvParser\n" + e.StackTrace);
            }
        }
    }
}
