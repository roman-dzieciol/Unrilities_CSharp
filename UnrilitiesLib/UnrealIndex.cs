using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace UnrilitiesLib
{
    [DebuggerDisplay("{value}")]
    public class UnrealIndex : IComparable
    {

        public Int32 value;

        public UnrealIndex()
        {
            value = 0;
        }

        public UnrealIndex(BinaryReader reader) : this()
        {
            value = UnrealIndex.Read(reader);
        }

        static public int Read(BinaryReader reader)
        {
            int value = 0;

            byte b0 = reader.ReadByte();

            if ((b0 & 0x40) != 0)
            {
                byte b1 = reader.ReadByte();
                if ((b1 & 0x80) != 0)
                {
                    byte b2 = reader.ReadByte();
                    if ((b2 & 0x80) != 0)
                    {
                        byte b3 = reader.ReadByte();
                        if ((b3 & 0x80) != 0)
                        {
                            byte b4 = reader.ReadByte();
                            value = b4;
                        } value = (value << 0x07) | (b3 & 0x4f);
                    } value = (value << 0x07) | (b2 & 0x4f);
                } value = (value << 0x07) | (b1 & 0x4f);
            } value = (value << 0x06) | (b0 & 0x3f);

            if ((b0 & 0x80) != 0)
            {
                value = -value;
            }
            return value;
        }

        static public explicit operator int(UnrealIndex i)
        {
            return i.value;
        }

        public override string ToString()
        {
            return value.ToString();
        }


        public int CompareTo(object obj)
        {
            return value.CompareTo(((UnrealIndex)obj).value);
        }
    }
}
