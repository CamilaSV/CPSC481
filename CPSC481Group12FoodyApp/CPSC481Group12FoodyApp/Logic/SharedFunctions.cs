using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp
{
    public static class SharedFunctions
    {
        // remove target by reading all lines and excluding target lines
        public static void removeLineFromFile(string filePath, string lineToRemove)
        {
            string[] allLines = File.ReadAllLines(filePath);

            StreamWriter fileWriter = File.CreateText(filePath);
            foreach (string line in allLines)
            {
                if (!line.Equals(lineToRemove))
                {
                    fileWriter.WriteLine(line);
                }
            }

            fileWriter.Close();
        }

        // remove target by reading all lines and excluding target lines
        public static void removeLineFromFile(string filePath, int lineToRemove)
        {
            string[] allLines = File.ReadAllLines(filePath);

            StreamWriter fileWriter = File.CreateText(filePath);
            foreach (string line in allLines)
            {
                if (!line.Equals(lineToRemove))
                {
                    fileWriter.WriteLine(line);
                }
            }

            fileWriter.Close();
        }

        // append target line to file
        public static void appendLineToFile(string filePath, string lineToAppend)
        {
            StreamWriter fileWriter = File.AppendText(filePath);
            fileWriter.WriteLine(lineToAppend);
            fileWriter.Close();
        }

        // append target line to file
        public static void appendLineToFile(string filePath, DateTime lineToAppend)
        {
            StreamWriter fileWriter = File.AppendText(filePath);
            fileWriter.WriteLine(lineToAppend);
            fileWriter.Close();
        }

        public static void appendLineToFile(string filePath, int lineToAppend)
        {
            StreamWriter fileWriter = File.AppendText(filePath);
            fileWriter.WriteLine(lineToAppend);
            fileWriter.Close();
        }

        // read line from file
        public static string getFirstLineFromFile(string filePath)
        {
            StreamReader fileReader = File.OpenText(filePath);
            string result = fileReader.ReadLine();
            fileReader.Close();

            return result;
        }
    }
}
