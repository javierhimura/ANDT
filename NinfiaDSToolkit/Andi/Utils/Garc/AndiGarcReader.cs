using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NinfiaDSToolkit.Andi.Utils.Garc
{
    // Note : This Code not ready, and not include on this tool

    public class AndiGarcReader
    {
        Stream _stream = new MemoryStream();
        GARCHeader _GARCARC = new GARCHeader();
        string _path ="";

        public AndiGarcReader()
        {
            
        }

        public AndiGarcReader(string path)
        {
            _path = path;
            Open();
        }

        public GARCHeader GetGarc()
        {
            return _GARCARC;
        }

        public static uint Reverse(uint x)
        {
            uint y = 0;
            for (int i = 0; i < 32; ++i)
            {
                y <<= 1;
                y |= (x & 1);
                x >>= 1;
            }
            return y;
        }

        public static char[] Reverse(char[] charArray)
        {
            Array.Reverse(charArray);
            return charArray;
        }

        public void Open()
        {
            if (_path == "")
            {
                throw new Exception("Bang!");
            }

            BinaryReader br = new BinaryReader(System.IO.File.OpenRead(_path));

            // GARC Header
            _GARCARC.MagicHeader = br.ReadChars(4);
            _GARCARC.HeaderSize = br.ReadUInt32();
            _GARCARC.EndianId = br.ReadUInt16();
            if (_GARCARC.EndianId == 0xFEFF)
            {
                _GARCARC.MagicHeader = Reverse(_GARCARC.MagicHeader);
            }
            _GARCARC.Constant = br.ReadUInt16();
            _GARCARC.FileSize = br.ReadUInt32();

            _GARCARC.DataOffset = br.ReadUInt32();
            _GARCARC.FileLenght = br.ReadUInt32();
            _GARCARC.EndSize = br.ReadUInt32();

            // OTAF 
            _GARCARC.OTAF.MagicHeader = br.ReadChars(4);
            _GARCARC.OTAF.SectionSize = br.ReadUInt32();
            _GARCARC.OTAF.FileCount = br.ReadUInt16();
            _GARCARC.OTAF.Padding = br.ReadUInt16();

            _GARCARC.OTAF.Entries = new OTAF_Entry[_GARCARC.OTAF.FileCount];
            // not really needed; plus it's wrong
            for (int i = 0; i < _GARCARC.OTAF.FileCount; i++)
            {
                uint val = br.ReadUInt32();
                if (_GARCARC.OTAF.Padding == 0xffff)
                {
                    val = Reverse(val);
                }
                _GARCARC.OTAF.Entries[i].Name = val.ToString();
            }

            // BTAF (File Allocation TaBle)
            _GARCARC.BTAF.MagicHeader = br.ReadChars(4);
            _GARCARC.BTAF.SectionSize = br.ReadUInt32();
            _GARCARC.BTAF.FileCount = br.ReadUInt32();

            _GARCARC.BTAF.Entries = new BTAF_Entry[_GARCARC.BTAF.FileCount];
            for (int i = 0; i < _GARCARC.BTAF.FileCount; i++)
            {
                _GARCARC.BTAF.Entries[i].bits = br.ReadUInt32();
                _GARCARC.BTAF.Entries[i].StartOffset = br.ReadUInt32();
                _GARCARC.BTAF.Entries[i].EndOffset = br.ReadUInt32();
                _GARCARC.BTAF.Entries[i].Lenght = br.ReadUInt32();
            }

            // BMIF
            _GARCARC.GMIF.MagicHeader = br.ReadChars(4);
            _GARCARC.GMIF.SectionSize = br.ReadUInt32();
            _GARCARC.GMIF.DataSize = br.ReadUInt32();

            // Files data

            br.Close();
        }

        public byte[] Extract(int id)
        {
            _stream = new FileStream(_path,FileMode.Open);

            _stream.Position = _GARCARC.BTAF.Entries[id].StartOffset + _GARCARC.DataOffset;
            byte[] tempdata = new byte[_GARCARC.BTAF.Entries[id].Lenght];
           
            _stream.Read(tempdata,0,tempdata.Length);
            _stream.Close();

            return tempdata;
        }

        public int getFileCount()
        {
            return _GARCARC.BTAF.Entries.Length;
        }
    }

    #region struct 

    public struct GARCHeader
    {
        public char[] MagicHeader;
        public uint HeaderSize;
        public ushort EndianId;
        public ushort Constant;
        public uint FileSize;

        public uint DataOffset;
        public uint FileLenght;
        public uint EndSize;

        public OTAF OTAF;
        public BTAF BTAF;
        public GMIF GMIF;
    }

    public struct OTAF
    {
        public char[] MagicHeader;
        public uint SectionSize;
        public uint FileCount;
        public uint Padding;

        public OTAF_Entry[] Entries;
    }

    public struct OTAF_Entry
    {
        public string Name;
    }

    public struct BTAF
    {
        public char[] MagicHeader;
        public uint SectionSize;
        public uint FileCount;
        public BTAF_Entry[] Entries;
    }

    public struct BTAF_Entry
    {
        public uint bits;
        public uint StartOffset;
        public uint EndOffset;
        public uint Lenght;
    }

    public struct GMIF
    {
        public char[] MagicHeader;
        public uint SectionSize;
        public uint DataSize;
    }

    #endregion
}
