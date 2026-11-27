using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorterDyeDurham.Tests
{
    [TestFixture]
    public class NameSorterExecutorTests
    {
        private readonly string INPUT_FILE_NAME = $"{Directory.GetCurrentDirectory()}/res/test_input_file.txt";
        private readonly string INPUT_SMALL_FILE_NAME = $"{Directory.GetCurrentDirectory()}/res/test_input_file_small.txt";

        private readonly string OUTPUT_FILENAME = $"{Directory.GetCurrentDirectory()}/res/output_file.txt";
        private NameSorterExecutor _executor;

        [SetUp]
        public void Setup()
        {
            _executor = new NameSorterExecutor(OUTPUT_FILENAME);
        }

        [Test]
        public void Given_InputFileOfNames_When_ExecuteForInputFile_Then_OutputFileIsProduced()
        {
            _executor.ExecuteForInputFile(INPUT_FILE_NAME);

            Assert.That(File.Exists(OUTPUT_FILENAME), Is.True);
        }

        [Test]
        public void Given_InputFileOfNames_When_ExecuteForInputFileTwiceInSuccession_Then_OutputFileIsOverwrittenSecondTime()
        {
            _executor.ExecuteForInputFile(INPUT_FILE_NAME);
            int numLinesFirstExec = File.ReadAllLines(OUTPUT_FILENAME).Length;

            _executor.ExecuteForInputFile(INPUT_SMALL_FILE_NAME);
            int numLinesSecondExec = File.ReadAllLines(OUTPUT_FILENAME).Length;

            Assert.That(File.Exists(OUTPUT_FILENAME), Is.True);
            Assert.That(numLinesSecondExec, Is.Not.EqualTo(numLinesFirstExec));
        }

        [Test]
        public void Given_NonExistantInputFile_When_ExecuteForInputFile_Then_ThrowArgumentException()
        {
            string nonexistantFilename = "./res/non_existant_file.txt";

            var ex = Assert.Throws<ArgumentException>(() => _executor.ExecuteForInputFile(nonexistantFilename));

            Assert.That(ex.Message, Is.EqualTo($"Error: input file {nonexistantFilename} does not exist!"));
        }

    }
}
