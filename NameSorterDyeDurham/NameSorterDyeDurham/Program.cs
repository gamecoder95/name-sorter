using System.Diagnostics;

namespace NameSorterDyeDurham
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();

            string outputFilename = $"{Directory.GetCurrentDirectory()}/sorted-names-list.txt";
            var executor = new NameSorterExecutor(outputFilename);
            executor.ExecuteForInputFile(args[0]);

            sw.Stop();
            Console.WriteLine($"Process took {sw.ElapsedMilliseconds} ms");
        }
    }
}
