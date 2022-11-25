using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Windows.Shapes;

namespace CPSC481Group12FoodyApp.Logic
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

        // filepaths[0] looks for linetoRemoveFromItem1
        // if found, then that line is excluded, and that line number is excluded in all files in the filepaths
        public static void removeLineFromMultipleFiles(List<string> filepaths, string linetoRemoveFromItem1)
        {
            List<string[]> allLinesItems = new List<string[]>();
            List<StreamWriter> fileWriters = new List<StreamWriter>();
            for (int i = 0; i < filepaths.Count; i++)
            {
                allLinesItems.Add(File.ReadAllLines(filepaths[i]));
                fileWriters.Add(File.CreateText(filepaths[i]));
            }

            // traverse in reverse so it doesn't mess with the line numbers
            for (int i = allLinesItems[0].Length - 1; i >= 0; i--)
            {
                if (!allLinesItems[0][i].Equals(linetoRemoveFromItem1))
                {
                    for (int j = 0; j < filepaths.Count; j++)
                    {
                        fileWriters[j].WriteLine(allLinesItems[j][i]);
                    }
                }
            }

            foreach (StreamWriter fileWriter in fileWriters)
            {
                fileWriter.Close();
            }
        }

        // remove a line only if every linesToRemove match every corresponding file on the same line
        // filepaths and linesToRemove must have same length
        public static void removeLinesOnMatchAll(List<string> filepaths, List<string> linesToRemove)
        {
            List<string[]> allLinesItems = new List<string[]>();
            List<StreamWriter> fileWriters = new List<StreamWriter>();
            for (int i = 0; i < filepaths.Count; i++)
            {
                allLinesItems.Add(File.ReadAllLines(filepaths[i]));
                fileWriters.Add(File.CreateText(filepaths[i]));
            }

            Boolean matchedAll;
            // traverse in reverse so it doesn't mess with the line numbers
            for (int i = allLinesItems[0].Length - 1; i >= 0; i--)
            {
                matchedAll = true;
                for (int j = 0; j < filepaths.Count; j++)
                {
                    if (!allLinesItems[j][i].Equals(linesToRemove[j]))
                    {
                        matchedAll = false;
                        break;
                    }
                }

                if (matchedAll)
                {
                    for (int j = 0; j < filepaths.Count; j++)
                    {
                        fileWriters[j].WriteLine(allLinesItems[j][i]);
                    }
                }
            }

            foreach (StreamWriter fileWriter in fileWriters)
            {
                fileWriter.Close();
            }
        }

        // append target line to file
        public static void appendLineToFile(string filePath, string lineToAppend)
        {
            StreamWriter fileWriter = File.AppendText(filePath);
            fileWriter.WriteLine(lineToAppend);
            fileWriter.Close();
        }

        public static void createFileWithText(string filePath, string text)
        {
            StreamWriter fileWriter = File.CreateText(filePath);
            fileWriter.WriteLine(text);
            fileWriter.Close();
        }

        public static Boolean isLineInFile(string filePath, string text)
        {
            string[] allLines = File.ReadAllLines(filePath);

            foreach (string line in allLines)
            {
                if (line.Equals(text))
                {
                    return true;
                }
            }

            return false;
        }

        // read line from file
        public static string getFirstLineFromFile(string filePath)
        {
            StreamReader fileReader = File.OpenText(filePath);
            string result = fileReader.ReadLine();
            fileReader.Close();

            return result;
        }

        // polymorphism methods go here
        public static void removeLineFromFile(string filePath, int lineToRemove)
        {
            removeLineFromFile(filePath, lineToRemove.ToString());
        }

        public static void appendLineToFile(string filePath, DateTime lineToAppend)
        {
            appendLineToFile(filePath, lineToAppend.ToString());
        }

        public static void appendLineToFile(string filePath, int lineToAppend)
        {
            appendLineToFile(filePath, lineToAppend.ToString());
        }

        public static void createFileWithText(string filePath, DateTime text)
        {
            createFileWithText(filePath, text.ToString());
        }

        public static void createFileWithText(string filePath, int text)
        {
            createFileWithText(filePath, text.ToString());
        }

        public static string getCurrentEpochTime()
        {
            return DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
        }

        public static string getDateOrTimefromEpoch(string epochTime)
        {
            DateTimeOffset timeoff = DateTimeOffset.FromUnixTimeSeconds(long.Parse(epochTime.Trim()));

            DateTime epochDateTime = timeoff.DateTime.ToLocalTime();
            string dateOrTime;

            if ((int)(DateTime.Now - epochDateTime).TotalDays > 0)
            {
                // at least 1 day has passed; only show date
                dateOrTime = epochDateTime.ToString("MM-dd", new CultureInfo("en-US"));
            }
            else
            {
                dateOrTime = epochDateTime.ToString("hh:mm tt", new CultureInfo("en-US"));
            }

            return dateOrTime;
        }
    }
}
