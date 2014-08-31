using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace UnrilitiesLib
{
    [DebuggerDisplay("{offset}, {ObjectName}")]
    public class ExportTableItem : PackageTableItem
    {
        public Int32 Class;
        public Int32 Super;
        public Int32 Package;
        public Int32 ObjectName;
        public EObjectFlags ObjectFlags;
        public Int32 SerialSize;
        public Int32 SerialOffset;
        
        public ExportTableItem(BinaryReader reader)
            : base(reader)
        {
            Class = UnrealIndex.Read(reader);
            Super = UnrealIndex.Read(reader);
            Package = reader.ReadInt32();
            ObjectName = UnrealIndex.Read(reader);
            ObjectFlags = (EObjectFlags)reader.ReadUInt32();
            SerialSize = UnrealIndex.Read(reader);
            if (SerialSize > 0)
            {
                SerialOffset = UnrealIndex.Read(reader);
            }
            else
            {
                SerialOffset = 0;
            }

        }
    }
}
