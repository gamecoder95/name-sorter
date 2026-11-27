namespace NameSorterDyeDurham
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string outputFilename = $"{Directory.GetCurrentDirectory()}/sorted-names-list.txt";
            var executor = new NameSorterExecutor(outputFilename);
            executor.ExecuteForInputFile(args[0]);
        }
    }
}
