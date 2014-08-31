using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnrilitiesLib;

namespace Unrilities
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = File.OpenRead(args[0]);
            BinaryReader reader = new BinaryReader(file);
            Package package = new Package(reader);

            StreamWriter writer = new StreamWriter(File.Create(String.Format("{0}.txt", args[0])));
            PackagePrinter printer = new PackagePrinter(writer, package);
            printer.Print(package);
            writer.Close();
        }
    }
}
