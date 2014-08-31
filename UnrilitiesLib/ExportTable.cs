using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UnrilitiesLib
{
    public class ExportTable : PackageTable<ExportTableItem>
    {
        public ExportTable(BinaryReader reader)
            : base(reader, r => new ExportTableItem(r))
        {
        }
    }
}
