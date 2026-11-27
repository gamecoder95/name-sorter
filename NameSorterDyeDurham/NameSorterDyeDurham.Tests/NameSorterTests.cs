using NUnit.Framework.Legacy;

namespace NameSorterDyeDurham.Tests;

[TestFixture]
public class NameSorterTests
{
    private readonly NameSorter _nameSorter = new NameSorter();


    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void Given_EmptyListOfNames_When_SortNames_Then_ReturnEmptyListOfNames()
    {
        string[] unsortedNames = [];
        var expectedSortedNames = new List<string>();

        var sortedNames = _nameSorter.SortNames(unsortedNames);

        Assert.That(sortedNames, Is.EqualTo(expectedSortedNames).AsCollection);
    }

    [Test]
    public void Given_ListOfNames_When_SortNames_Then_ReturnSortedNames()
    {
        var unsortedNames = NameSorterTestsHelper.GetStandardListOfNames();
        var expectedSortedNames = NameSorterTestsHelper.GetStandardListOfNamesSorted();

        var sortedNames = _nameSorter.SortNames(unsortedNames);

        Assert.That(sortedNames, Is.EqualTo(expectedSortedNames).AsCollection);
    }

    [Test]
    public void Given_AlreadySortedListOfNames_When_SortNames_Then_ReturnListOfExactSortedNames()
    {
        var unsortedNames = NameSorterTestsHelper.GetStandardListOfNamesSorted().ToArray();
        var expectedSortedNames = NameSorterTestsHelper.GetStandardListOfNamesSorted();

        var sortedNames = _nameSorter.SortNames(unsortedNames);

        Assert.That(sortedNames, Is.EqualTo(expectedSortedNames).AsCollection);
    }

    [Test]
    public void Given_ListOfNamesWithSameLastNames_When_SortNames_Then_ReturnListOfNamesSortedByMiddleNames()
    {
        string[] unsortedNames =
        [
            "Muhammad Mahmoud Ahmad",
            "Ayyoub Idris Ahmad",
            "Mahmoud Qasim Ahmad",
            "Zaynab Bint Ahmad",
            "Omar Ahmad"
        ];
        var expectedSortedNames = new List<string>()
        {
            "Zaynab Bint Ahmad",
            "Ayyoub Idris Ahmad",
            "Muhammad Mahmoud Ahmad",
            "Mahmoud Qasim Ahmad",
            "Omar Ahmad"
        };

        var sortedNames = _nameSorter.SortNames(unsortedNames);

        Assert.That(sortedNames, Is.EqualTo(expectedSortedNames).AsCollection);
    }

    [Test]
    public void Given_ListOfNamesWithSameLastAndMiddleNames_When_SortNames_Then_ReturnListOfNamesSortedByFirstNames()
    {
        string[] unsortedNames =
        [
            "Muhammad Mahmoud Ahmad",
            "Ayyoub Mahmoud Ahmad",
            "Mahmoud Mahmoud Ahmad",
            "Zaynab Mahmoud Ahmad",
            "Omar Ahmad"
        ];
        var expectedSortedNames = new List<string>()
        {
            "Ayyoub Mahmoud Ahmad",
            "Mahmoud Mahmoud Ahmad",
            "Muhammad Mahmoud Ahmad",
            "Zaynab Mahmoud Ahmad",
            "Omar Ahmad"
        };

        var sortedNames = _nameSorter.SortNames(unsortedNames);

        Assert.That(sortedNames, Is.EqualTo(expectedSortedNames).AsCollection);
    }

    [Test]
    public void Given_ListOfNamesWithSameLastAndMiddleNamesAndDifferentLengths_When_SortNames_Then_ReturnListOfNamesSortedPreferringLongerNamesFirst()
    {
        string[] unsortedNames =
        [
            "Muhammad Hammaad Mahmoud Ahmad",
            "Ayyoub Mahmoud Ahmad",
            "Mahmoud Ahmad",
            "Zaynab Mahmoud Ahmad",
            "Omar Ahmad"
        ];
        var expectedSortedNames = new List<string>()
        {
            "Muhammad Hammaad Mahmoud Ahmad",
            "Ayyoub Mahmoud Ahmad",
            "Zaynab Mahmoud Ahmad",
            "Mahmoud Ahmad",
            "Omar Ahmad"
        };

        var sortedNames = _nameSorter.SortNames(unsortedNames);

        Assert.That(sortedNames, Is.EqualTo(expectedSortedNames).AsCollection);
    }
}
