using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UnrilitiesLib
{
    public class ImportTable : PackageTable<ImportTableItem>
    {
        public ImportTable(BinaryReader reader)
            : base(reader, r => new ImportTableItem(r))
        {
        }
    }
}
