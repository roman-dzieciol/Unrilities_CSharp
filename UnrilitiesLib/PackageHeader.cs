using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UnrilitiesLib
{
    public class PackageHeader
    {
        private const UInt32 unrealSignature = 0x9E2A83C1;
        public UInt32 signature;
        public UInt16 packageVersion;
        public UInt16 licenseeMode;
        public UInt32 packageFlags;

        public PackageHeader()
        {
        }

        public PackageHeader(BinaryReader reader)
            : this()
        {
            signature = reader.ReadUInt32();
            if (signature != unrealSignature)
            {
                throw new System.Exception("Not an unreal engine package");
            }
            packageVersion = reader.ReadUInt16();
            licenseeMode = reader.ReadUInt16();
            packageFlags = reader.ReadUInt32();
        }
    }
}
