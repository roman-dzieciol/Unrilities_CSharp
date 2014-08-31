using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace UnrilitiesLib
{
    public class PackageTable<T> : IPackageTable where T : PackageTableItem
    {
        public PackageTableHeader header { get; set; }
        public ArrayList items { get; set; }
        public Func<BinaryReader, T> factory;
        
        public PackageTable()
        {
        }

        public PackageTable(BinaryReader reader, Func<BinaryReader, T> factory) : this()
        {
            this.factory = factory;
            header = new PackageTableHeader(reader);
            items = new ArrayList((int)header.count);

            long offset = reader.BaseStream.Position;
            reader.BaseStream.Seek(header.offset, System.IO.SeekOrigin.Begin);

            for (UInt32 i = 0; i < header.count; ++i)
            {
                T item = factory(reader);
                item.index = i;
                items.Add(item); 
            }

            reader.BaseStream.Seek(offset, System.IO.SeekOrigin.Begin);
        }

        public T this[int idx]
        {
            get
            {
                return (T)items[idx];
            }
            set
            {
                items[idx] = value;
            }
        }


    }
}
