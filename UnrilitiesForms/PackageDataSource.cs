using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using UnrilitiesLib;

namespace UnrilitiesForms
{
    class PackageDataSource
    {
        Package package;
        public NameTableDataSource nameTableDataSource;
        public ExportTableDataSource exportTableDataSource;
        public ImportTableDataSource importTableDataSource;

        public PackageDataSource(Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream);
            package = new Package(reader);
            StreamWriter writer = new StreamWriter(File.Create(String.Format("Package.txt")));
            PackagePrinter printer = new PackagePrinter(writer, package);
            printer.Print(package);
            writer.Close();

            nameTableDataSource = new NameTableDataSource(package.nameTable);
            exportTableDataSource = new ExportTableDataSource(package.exportTable, package);
            importTableDataSource = new ImportTableDataSource(package.importTable, package);
        }

        public void SetupListView(ListView listView)
        {
            nameTableDataSource.SetupListView(listView);
        }
    }
}
