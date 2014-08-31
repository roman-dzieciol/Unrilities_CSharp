using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace UnrilitiesLib
{
    [DebuggerDisplay("{index}, {offset}")]
    public class PackageTableItem
    {
        public UInt32 index;
        public UInt32 offset;

        public PackageTableItem(BinaryReader reader)
        {
            offset = (UInt32)reader.BaseStream.Position;
        }
    }
}
