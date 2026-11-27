using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace NameSorterDyeDurham
{
    public class NameSorterExecutor
    {
        public readonly string _outputFilename;

        private readonly NameSorter _nameSorter;

        public NameSorterExecutor(string outputFilename) 
        {
            _nameSorter = new NameSorter();
            _outputFilename = outputFilename;
        }

        public void ExecuteForInputFile(string inputFilename)
        {   
            if (!File.Exists(inputFilename))
            {
                throw new ArgumentException($"Error: input file {inputFilename} does not exist!");
            }

            string[] unsortedNames = File.ReadAllLines(inputFilename);

            var sortedNames = _nameSorter.SortNames(unsortedNames);

            Console.WriteLine($"Output written to: {_outputFilename}");
            using (StreamWriter sw = File.CreateText(_outputFilename))
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
