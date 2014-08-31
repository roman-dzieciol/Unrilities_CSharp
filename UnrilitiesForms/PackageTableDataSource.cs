using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using UnrilitiesLib;

namespace UnrilitiesForms
{
    struct PackageTableDataGetter
    {
        public string column;
        public Func<int, IComparable> sort;
        public Func<int, String> data;
    }

    class PackageTableDataSource
    {
        protected PackageTableSorter tableSorter;
        protected PackageTableDataGetter[] dataGetters;
        
        public PackageTableDataSource(int count)
        {
            tableSorter = new PackageTableSorter(count);
        }


        public void SetupListView(ListView listView)
        {
            listView.VirtualListSize = tableSorter.Count;
            listView.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(listView_RetrieveVirtualItem);
            listView.ColumnClick += new ColumnClickEventHandler(listView_ColumnClick);
            listView.Sorting = SortOrder.Ascending;

            foreach (PackageTableDataGetter dataGetter in dataGetters)
            {
                listView.Columns.Add(dataGetter.column);
            }
        }

        void listView_ColumnClick(object o, ColumnClickEventArgs e)
        {
            ListView listView = (ListView)o;
            tableSorter.Sort(e.Column, new PackageTableComparer(dataGetters[e.Column].sort));
            listView.Refresh();
        }

        void listView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            int index = tableSorter.SortedIndex(e.ItemIndex);
            string[] items = new string[dataGetters.Length];
            for (int i = 0; i < dataGetters.Length; ++i)
            {
                items[i] = dataGetters[i].data((int)index);
            }

            e.Item = new ListViewItem(items);
        }
    }

    class PackageTableComparer : IComparer
    {
        Func<int, IComparable> dataGetter;

        public PackageTableComparer(Func<int, IComparable> dataGetter)
        {
            this.dataGetter = dataGetter;
        }

        public int Compare(object x, object y)
        {
            return dataGetter((int)x).CompareTo(dataGetter((int)y));
        }
    }
}
