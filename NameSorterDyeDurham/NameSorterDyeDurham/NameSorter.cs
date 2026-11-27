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

            int i = name1Split.Length - 1,
                j = name2Split.Length - 1,
                comparison = 0;

            while (comparison == 0 && i > 0 && j > 0)
            {
                comparison = name1Split[i].CompareTo(name2Split[j]);

                if (comparison == 0)
                {
                    if (i > 0) --i;
                    if (j > 0) --j;
                }
            }

            // If we reached this point, that means that all other given names were equal, so we default to comparing the first names.
            return name1Split[0].CompareTo(name2Split[0]);
        }
    }
}
