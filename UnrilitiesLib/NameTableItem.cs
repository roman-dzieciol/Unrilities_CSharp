using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace UnrilitiesLib
{
    [DebuggerDisplay("{offset}, {name.value,nq}")]
    public class NameTableItem : PackageTableItem
    {
        public UnrealName name;
        public EObjectFlags flags;

        public NameTableItem(BinaryReader reader) : base(reader)
        {
            name = new UnrealName(reader);
            flags = (EObjectFlags)reader.ReadUInt32();
        }
    }
}
