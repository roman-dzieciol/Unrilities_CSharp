using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UnrilitiesLib
{
    public class PackageTableHeader
    {
        public UInt32 count;
        public UInt32 offset;

        public PackageTableHeader(BinaryReader reader)
        {
            count = reader.ReadUInt32();
            offset = reader.ReadUInt32();
        }
    }
}
