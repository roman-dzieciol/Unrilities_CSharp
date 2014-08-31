using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace UnrilitiesLib
{
    [DebuggerDisplay("{offset}, {ObjectName}")]
    public class ImportTableItem : PackageTableItem
    {
        public Int32 ClassPackage;
        public Int32 Class;
        public Int32 Package;
        public Int32 ObjectName;

        public ImportTableItem(BinaryReader reader)
            : base(reader)
        {
            ClassPackage = UnrealIndex.Read(reader);
            Class = UnrealIndex.Read(reader);
            Package = reader.ReadInt32();
            ObjectName = UnrealIndex.Read(reader);
        }
    }
}
