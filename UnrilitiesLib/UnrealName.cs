using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace UnrilitiesLib
{
    [DebuggerDisplay("{value}")]
    public class UnrealName : IComparable
    {
        public String value;

        public UnrealName(BinaryReader reader)
        {
            UnrealIndex length = new UnrealIndex(reader);
            if (length.value > 0)
            {
                unsafe
                {
                    byte[] data = new byte[length.value];
                    data = reader.ReadBytes(length.value);
                    fixed (byte* dataPtr = &data[0])
                    {
                        value = new String((sbyte*)dataPtr, 0, length.value - 1, System.Text.Encoding.ASCII);
                    }
                }
            }
        }

        public override string ToString()
        {
            return value.ToString();
        }
        
            

        public int CompareTo(object obj)
        {
            return value.CompareTo(((UnrealName)obj).value);
        }
    }
}
