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
                sortedList.Sort((name1, name2) => {
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

                            if (i == 0 && j == 0)
                            {
                                return name1Split[i].CompareTo(name2Split[j]);
                            }
                        }
                    }

                    return comparison;

                });
            }

            return sortedList;
        }
    }
}
