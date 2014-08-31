using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using UnrilitiesLib;

namespace UnrilitiesForms
{

    class NameTableDataSource : PackageTableDataSource
    {        
        public NameTableDataSource(NameTable nameTable) 
            : base(nameTable.items.Count)
        {
            
            dataGetters = new PackageTableDataGetter[] {
                new PackageTableDataGetter { column = "#", 
                    sort = (i => { return nameTable[i].index; }),
                    data = (i => { return nameTable[i].index.ToString(); }),
                },
                new PackageTableDataGetter { column = "offset", 
                    sort = (i => { return nameTable[i].offset; }),
                    data = (i => { return String.Format("{0:X8}", nameTable[i].offset); }),
                },
                new PackageTableDataGetter { column = "name", 
                    sort = (i => { return nameTable[i].name; }),
                    data = (i => { return nameTable[i].name.ToString(); }),
                },
                new PackageTableDataGetter { column = "flags", 
                    sort = (i => { return nameTable[i].flags; }),
                    data = (i => { return nameTable[i].flags.ToString(); }),
                },
            };
        }
    }

    class ExportTableDataSource : PackageTableDataSource
    {
        public ExportTableDataSource(ExportTable exportTable, Package pkg)
            : base(exportTable.items.Count)
        {
            dataGetters = new PackageTableDataGetter[] {
                new PackageTableDataGetter { column = "#", 
                    sort = (i => { return exportTable[i].index; }),
                    data = (i => { return exportTable[i].index.ToString(); }),
                },
                new PackageTableDataGetter { column = "offset", 
                    sort = (i => { return exportTable[i].offset; }),
                    data = (i => { return String.Format("{0:X8}", exportTable[i].offset); }),
                },

                new PackageTableDataGetter { column = "# of", 
                    sort = (i => { return exportTable[i].ObjectName; }),
                    data = (i => { return exportTable[i].ObjectName.ToString(); }),
                },
                new PackageTableDataGetter { column = "ObjectName", 
                    sort = (i => { return pkg.GetName(exportTable[i].ObjectName); }),
                    data = (i => { return pkg.GetName(exportTable[i].ObjectName); })
                },
                    
                new PackageTableDataGetter { column = "# of", 
                    sort = (i => { return exportTable[i].Class; }),
                    data = (i => { return exportTable[i].Class.ToString(); }),
                },
                new PackageTableDataGetter { column = "Class", 
                    sort = (i => { return pkg.GetObjNameRec(exportTable[i].Class); }),                
                    data = (i => { return pkg.GetObjNameRec(exportTable[i].Class); }),
                },

                new PackageTableDataGetter { column = "# of", 
                    sort = (i => { return exportTable[i].Super; }),
                    data = (i => { return exportTable[i].Super.ToString(); }),
                },
                new PackageTableDataGetter { column = "Super", 
                    sort = (i => { return pkg.GetObjNameRec(exportTable[i].Super); }),
                    data = (i => { return pkg.GetObjNameRec(exportTable[i].Super); })
                },

                new PackageTableDataGetter { column = "# of", 
                    sort = (i => { return exportTable[i].Package; }),
                    data = (i => { return exportTable[i].Package.ToString(); }),
                },
                new PackageTableDataGetter { column = "Package", 
                    sort = (i => { return pkg.GetObjNameRec(exportTable[i].Package); }),                
                    data = (i => { return pkg.GetObjNameRec(exportTable[i].Package); }),
                },
                    
                new PackageTableDataGetter { column = "SerialSize", 
                    sort = (i => { return exportTable[i].SerialSize; }),
                    data = (i => { return exportTable[i].SerialSize.ToString(); }),
                },

                new PackageTableDataGetter { column = "SerialOffset", 
                    sort = (i => { return exportTable[i].SerialOffset; }),
                    data = (i => { return String.Format("{0:X8}", exportTable[i].SerialOffset); }),
                },
                                        
                new PackageTableDataGetter { column = "ObjectFlags", 
                    sort = (i => { return exportTable[i].ObjectFlags; }),
                    data = (i => { return exportTable[i].ObjectFlags.ToString(); }),
                },
            };
        }
    }

    class ImportTableDataSource : PackageTableDataSource
    {
        public ImportTableDataSource(ImportTable importTable, Package pkg)
            : base(importTable.items.Count)
        {
            dataGetters = new PackageTableDataGetter[] {
                new PackageTableDataGetter { column = "#", 
                    sort = (i => { return importTable[i].index; }),
                    data = (i => { return importTable[i].index.ToString(); }),
                },
                new PackageTableDataGetter { column = "offset", 
                    sort = (i => { return importTable[i].offset; }),
                    data = (i => { return String.Format("{0:X8}", importTable[i].offset); }),
                },

                new PackageTableDataGetter { column = "# of", 
                    sort = (i => { return importTable[i].ClassPackage; }),
                    data = (i => { return importTable[i].ClassPackage.ToString(); }),
                                },
                new PackageTableDataGetter { column = "ClassPackage", 
                    sort = (i => { return pkg.GetName(importTable[i].ClassPackage); }),
                    data = (i => { return pkg.GetName(importTable[i].ClassPackage); }),
                },

                new PackageTableDataGetter { column = "# of", 
                    sort = (i => { return importTable[i].ObjectName; }),
                    data = (i => { return importTable[i].ObjectName.ToString(); }),                
                },
                new PackageTableDataGetter { column = "ObjectName", 
                    sort = (i => { return pkg.GetName(importTable[i].ObjectName); }),
                    data = (i => { return pkg.GetName(importTable[i].ObjectName); }),
                },

                new PackageTableDataGetter { column = "# of", 
                    sort = (i => { return importTable[i].Package; }),
                    data = (i => { return importTable[i].Package.ToString(); }),                
                },
                new PackageTableDataGetter { column = "Package", 
                    sort = (i => { return pkg.GetObjNameRec(importTable[i].Package); }),
                    data = (i => { return pkg.GetObjNameRec(importTable[i].Package); }),
                },

                new PackageTableDataGetter { column = "# of", 
                    sort = (i => { return importTable[i].Class; }),
                    data = (i => { return importTable[i].Class.ToString(); }),                
                },
                new PackageTableDataGetter { column = "Class", 
                    sort = (i => { return pkg.GetName(importTable[i].Class); }),
                    data = (i => { return pkg.GetName(importTable[i].Class); }),
                },
            };
        }
    }
    
}
