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
            string[] name1Split = name1.Split(' ');
            string[] name2Split = name2.Split(' ');

            int i, j, comparison = 0;

            // Case 1: Both names are the same length
            // We compare from last name to first name in cases of equality
            if (name1Split.Length == name2Split.Length)
            {
                i = name1Split.Length - 1;
                j = name2Split.Length - 1;

                for (; i > 0; --i, --j)
                {
                    comparison = name1Split[i].CompareTo(name2Split[j]);
                    if (comparison != 0)
                    {
                        return comparison;
                    }
                }

                // If we reached this point, that means that all other given names were equal, so we default to comparing the first names.
                return name1Split[0].CompareTo(name2Split[0]);
            }
            // Case 2: Names are different lengths
            // We compare from last name to the second given name, defaulting to the one with more given names in the case of consistent equality
            else if (name1Split.Length > 2 || name2Split.Length > 2)
            {
                var longerName = name1Split.Length > name2Split.Length ? name1Split : name2Split;
                var shorterName = longerName == name1Split ? name2Split : name1Split;

                i = longerName.Length - 1;
                j = shorterName.Length - 1;

                for (; j > 0; --i, --j)
                {
                    comparison = longerName[i].CompareTo(shorterName[j]);
                    if (comparison != 0)
                    {
                        // The comparison has to be in relation to name1, so reverse it if name2 ended up being the longer name
                        return comparison * (longerName == name2Split ? -1 : 1);
                    }
                }

                // Give preference to the one with more names if we reach here
                return longerName == name2Split ? 1 : -1;
            }

            // Default in exceptional but not erroneous circumstances is to compare first names.
            return name1Split[0].CompareTo(name2Split[0]);
        }
    }
}
