using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UnrilitiesLib
{
    public class NameTable : PackageTable<NameTableItem>
    {

        public NameTable(BinaryReader reader)
            : base(reader, r => new NameTableItem(r))
        {
        }
    }
}
