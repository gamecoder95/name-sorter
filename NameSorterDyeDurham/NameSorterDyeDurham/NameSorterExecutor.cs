using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NameSorterDyeDurham
{
    public class NameSorterExecutor
    {
        public const string OUTPUT_FILENAME = "./sorted-names-list.txt";

        private readonly NameSorter _nameSorter = new NameSorter();

        public void ExecuteForInputFile(string inputFilename)
        {
            if (!File.Exists(inputFilename))
            {
                throw new ArgumentException($"Error: input file {inputFilename} does not exist!");
            }

            string[] unsortedNames = File.ReadAllLines(inputFilename);

            var sortedNames = _nameSorter.SortNames(unsortedNames);

            using (StreamWriter sw = File.CreateText(OUTPUT_FILENAME))
            {
                foreach (var name in sortedNames)
                {
                    sw.WriteLine(name);
                    Console.WriteLine(name);
                }
            }
        }
    }
}
