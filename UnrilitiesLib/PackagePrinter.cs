
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UnrilitiesLib
{
    public class PackagePrinter
    {
        private TextWriter writer;
        private Package package;

        public PackagePrinter(TextWriter writer, Package package)
        {
            this.writer = writer;
            this.package = package;
        }

        public void Print(Package obj)
        {
            writer.WriteLine();
            Print(obj.header);

            writer.WriteLine();
            Print(obj.nameTable);

            writer.WriteLine();
            Print(obj.exportTable);

            writer.WriteLine();
            Print(obj.importTable);   
        }

        public void Print(PackageHeader obj)
        {
            writer.WriteLine(obj.ToString());
            writer.WriteLine("{0:X}", obj.signature);
            writer.WriteLine("{0:X}", obj.packageVersion);
            writer.WriteLine("{0:X}", obj.licenseeMode);
            writer.WriteLine("{0:X}", obj.packageFlags);
        }

        public void Print(IPackageTable obj)
        {
            writer.WriteLine(obj.ToString());
            Print(obj.header);
            foreach (dynamic item in obj.items)
            {
                Print(item);
            }
        }

        public void Print(PackageTableHeader obj)
        {
            writer.WriteLine("{0:D8} {1:X8}", obj.count, obj.offset);
        }

        public void Print(NameTableItem obj)
        {
            writer.WriteLine("{0:D8} {1:X8} {2} {3}",
                obj.index,
                obj.offset,
                obj.name.value,
                obj.flags
                );
        }

        public void Print(ExportTableItem obj)
        {
            writer.WriteLine("{0:D8} {1:X8} {2:D8} {3:D8} {4:D8} {5:D8} {7:D8} {8:X8} {9} {10} {6}",
                obj.index,
                obj.offset,
                obj.Class,
                obj.Super,
                obj.Package,
                obj.ObjectName,
                obj.ObjectFlags,
                obj.SerialSize,
                obj.SerialOffset,
                package.GetName(obj.ObjectName),
                package.GetObjNameRec(obj.Class)
                );
        }


        public void Print(ImportTableItem obj)
        {
            writer.WriteLine("{0:D8} {1:X8} {2:D8} {3:D8} {4:D8} {5:D8} {6} {7}", 
                obj.index, 
                obj.offset,
                obj.ClassPackage,
                obj.Class,
                obj.Package,
                obj.ObjectName,
                package.GetName(obj.ObjectName),
                package.GetName(obj.Class)
                );
        }

    }
}
