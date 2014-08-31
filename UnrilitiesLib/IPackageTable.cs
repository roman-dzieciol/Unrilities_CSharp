using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace UnrilitiesLib
{
    public interface IPackageTable
    {
        PackageTableHeader header { get; set; }
        ArrayList items { get; set; }
    }
}
