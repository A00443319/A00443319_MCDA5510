namespace SampleAssignment1
{
    using System;
    using System.IO;
    
    public class DirWalker
    {
        
        public void walk(String path)
        {
            string[] list = Directory.GetDirectories(path);

            if (list == null) return;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath);
                }
            }

            string[] fileList = Directory.GetFiles(path);
            CsvParser parser = new CsvParser();
            foreach (string filepath in fileList)
            {
                parser.parse(filepath);
            }
        }

       
        public static void Main(String[] args)
        {
            DirWalker fw = new DirWalker();

            var watch = new System.Diagnostics.Stopwatch();

            //start time
            watch.Start();
            Logger.Log("Start");

            //create output.csv and add headers
            try
            {
                using (var stream = File.CreateText(Utils.outputCsvFilePath))
                {
                    stream.WriteLine(Fields.writeInCsv());
                    stream.Close();
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("DirWalker\n"+e.FileName+"\t"+e.Message);
            }
            catch (Exception e)
            {
                Logger.Log("DirWalker\n"+e.StackTrace);
            }

            //directory traversing
            fw.walk(Utils.sampleCsvFilesPath);

            //stop time
            Logger.Log("Stop");
            watch.Stop();

            Console.WriteLine("Execution Complete.");
            Logger.Log("Execution Time : "+watch.Elapsed.ToString());
            Logger.Log(" Good records :" + Utils.goodRecords);
            Logger.Log(" Bad records :" + Utils.badRecords);
        }
    }
}
