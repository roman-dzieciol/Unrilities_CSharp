using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UnrilitiesLib
{
    [Flags]
    public enum EObjectFlags : uint
    {
        RF_Transactional = 0x00000001,   // Object is transactional.
        RF_Unreachable = 0x00000002,	// Object is not reachable on the object graph.
        RF_Public = 0x00000004,	// Object is visible outside its package.
        RF_TagImp = 0x00000008,	// Temporary import tag in load/save.
        RF_TagExp = 0x00000010,	// Temporary export tag in load/save.
        RF_SourceModified = 0x00000020,   // Modified relative to source files.
        RF_TagGarbage = 0x00000040,	// Check during garbage collection.
        RF_NeedLoad = 0x00000200,   // During load, indicates object needs loading.
        RF_HighlightedName = 0x00000400,	// A hardcoded name which should be syntax-highlighted.
        RF_EliminateObject = 0x00000400,   // NULL out references to this during garbage collecion.
        RF_InSingularFunc = 0x00000800,	// In a singular function.
        RF_RemappedName = 0x00000800,   // Name is remapped.
        RF_Suppress = 0x00001000,	//warning: Mirrored in UnName.h. Suppressed log name.
        RF_StateChanged = 0x00001000,   // Object did a state change.
        RF_InEndState = 0x00002000,   // Within an EndState call.
        RF_Transient = 0x00004000,	// Don't save object.
        RF_Preloading = 0x00008000,   // Data is being preloaded from file.
        RF_LoadForClient = 0x00010000,	// In-file load for client.
        RF_LoadForServer = 0x00020000,	// In-file load for client.
        RF_LoadForEdit = 0x00040000,	// In-file load for client.
        RF_Standalone = 0x00080000,   // Keep object around for editing even if unreferenced.
        RF_NotForClient = 0x00100000,	// Don't load this object for the game client.
        RF_NotForServer = 0x00200000,	// Don't load this object for the game server.
        RF_NotForEdit = 0x00400000,	// Don't load this object for the editor.
        RF_Destroyed = 0x00800000,	// Object Destroy has already been called.
        RF_NeedPostLoad = 0x01000000,   // Object needs to be postloaded.
        RF_HasStack = 0x02000000,	// Has execution stack.
        RF_Native = 0x04000000,   // Native (UClass only).
        RF_Marked = 0x08000000,   // Marked (for debugging).
        RF_ErrorShutdown = 0x10000000,	// ShutdownAfterError called.
        RF_DebugPostLoad = 0x20000000,   // For debugging Serialize calls.
        RF_DebugSerialize = 0x40000000,   // For debugging Serialize calls.
        RF_DebugDestroy = 0x80000000   // For debugging Destroy calls.
    }


    public class Package
    {
        public PackageHeader header;
        public NameTable nameTable;
        public ExportTable exportTable;
        public ImportTable importTable;

        public Package()
        {
        }

        public Package(BinaryReader reader) : this()
        {
            header = new PackageHeader(reader);
            nameTable = new NameTable(reader);
            exportTable = new ExportTable(reader);
            importTable = new ImportTable(reader);
        }

        public String GetObjectName(Int32 index)
        {
            if (index > 0)
            {
                return nameTable[exportTable[index-1].ObjectName].name.value;
            } 
            else if (index < 0)
            {
                return nameTable[importTable[-index-1].ObjectName].name.value;
            }
            else
            {
                return "";
            }
        }
        
        public String GetObjNameRec(Int32 index)
        {
            Int32 pkgIndex = 0;
            if (index > 0)
            {
                pkgIndex = exportTable[index - 1].Package;
            }
            else if (index < 0)
            {
                pkgIndex = importTable[-index - 1].Package;
            }
            else
            {
                return "";
            }

            if (pkgIndex != 0)
            {
                return GetObjNameRec(pkgIndex) + "." + GetObjectName(index);
            }
            else
            {
                return GetObjectName(index);
            }
        }

        public Int32 GetObjRef(Int32 index)
        {
            if (index > 0)
            {
                return exportTable[index - 1].ObjectName;
            }
            else if (index < 0)
            {
                return importTable[-index - 1].ObjectName;
            }
            else
            {
                return 0;
            }
        }

        public String GetName(Int32 index)
        {
            return nameTable[index].name.value;
        }

    }
}
