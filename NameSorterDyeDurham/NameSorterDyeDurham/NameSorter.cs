using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorterDyeDurham
{
    public class NameSorter
    {
        public List<string> SortNames(string[] unsortedNames)
        {
            var sortedList = new List<string>(unsortedNames);

            if (sortedList.Count > 1)
            {
                sortedList.Sort(CompareNames);
            }

            return sortedList;
        }

        private int CompareNames(string name1, string name2)
        {
            // We compare names from last name to first name, stopping at the first comparison that's unequal
            // In the case that last name and given names are equal between two full names:
            //  - In the case that both full names have the same number of given names, we simply compare up to the first name, defaulting to the result of that comparison.
            //  - In the case that the full names differ in the number of given names, preference is given to the longer name.

            string[] name1Split = name1.Split(' ');
            string[] name2Split = name2.Split(' ');

            // In the case that they are equal, longerName = name1, and shorterName = name2, so regular comparison ensues.
            var longerName = name1Split.Length >= name2Split.Length ? name1Split : name2Split;
            var shorterName = longerName == name1Split ? name2Split : name1Split;

            int i = longerName.Length - 1, 
                j = shorterName.Length - 1, 
                comparison = 0;

            for (; j > 0; --i, --j)
            {
                comparison = longerName[i].CompareTo(shorterName[j]);
                if (comparison != 0)
                {
                    // The comparison has to be in relation to name1, so reverse it if name2 ended up being the truly longer name
                    return comparison * (longerName == name2Split ? -1 : 1);
                }
            }

            // In the case of equality of names, give preference to longer name if they are not the same lengths
            if (longerName.Length != shorterName.Length)
            {
                return longerName == name2Split ? 1 : -1;
            }

            // Default otherwise is to compare first names
            return name1Split[0].CompareTo(name2Split[0]);
        }
    }
}
