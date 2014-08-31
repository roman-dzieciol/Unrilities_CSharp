using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace UnrilitiesForms
{
    class PackageTableSorter
    {
        private int column;
        private int[] indexTable;
        public int Count { get { return indexTable.Length; } }

        public PackageTableSorter(int count)
        {
            column = 0;
            indexTable = new int[count];
            for (int i = 0; i < count; ++i)
            {
                indexTable[i] = i;
            }
        }

        public int SortedIndex(int idx)
        {
            return indexTable[idx];
        }

        public void Sort(int column, IComparer comparer)
        {
            if (column == this.column)
            {
                Array.Reverse(indexTable);
            }
            else
            {
                this.column = column;
                Array.Sort(indexTable, comparer);
            }
        }
    }
}
