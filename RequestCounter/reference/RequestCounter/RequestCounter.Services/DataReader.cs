using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RequestCounter.Services
{
    /// <summary>
    /// This class is supposed to be implemented as part of TASK "Save counts". Pay attention to setting of the file added to project
    /// </summary>
    internal static class DataReader
    {
        private static readonly string fileName = "request-counts.txt";

        internal static Dictionary<string, int> ReadFromFile()
        {
            var linesOfFile = File.ReadAllLines(GetFullFilePath());
            var stats = new Dictionary<string, int>();
            foreach (var line in linesOfFile)
            {
                var splitted = line.Split(",");
                if (splitted.Length == 2)
                {
                    stats.Add(splitted[0], int.Parse(splitted[1]));
                }
            }

            return stats;
        }

        internal static void WriteToFile(Dictionary<string, int> stats)
        {
            List<string> fileEntries = new List<string>();
            foreach (var entry in stats)
            {
                fileEntries.Add($"{entry.Key},{entry.Value}");
            }

            File.WriteAllLines(GetFullFilePath(), fileEntries);
        }

        private static string GetFullFilePath()
        {
            string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            var fullPath = Path.Combine(filePath, fileName);
            return fullPath;
        }
    }
}
