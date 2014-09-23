using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Andi.Utils.Citro.Audio
{
    public class BCSAR
    {
        #region Inner Class
        public class Header
        {
            #region Partition Class
            public class STRG
            {
                public struct STRGHeader
                {
                    // 64 byte
                    public byte[] MagicHeaderID; // 4 byte at 0
                    public Info Info;
                    public SubFile SubFile;
                }

                public struct Info
                {
                    public int Lenght;
                    public int u1;
                }

                public struct SubFile
                {
                    public int Lenght;
                    public long MaskOffset;
                    public int Count;
                    public int u1;
                    public SubFileEntry[] FileEntry;
                }

                public struct SubFileEntry
                {
                    public int RootID;
                    public long Offset;
                    public int Lenght;
                }

                public struct MaskEntry
                {
                    public int FileID;
                    public int TypeIndex;
                    public int TypeID;
                    public int Const;
                    public int u1;
                    public int u2;
                    public int u3;
                    public int u4;
                    public int u5;
                }
            }

            public class INFO
            {
                public struct INFOHeader
                {
                    // 64 byte
                    public byte[] MagicHeaderID; // 4 byte at 0
                    public Info Info;
                    public SubFile SubFile;
                }

                public struct Info
                {
                    public int Lenght;
                    public int u1;
                }

                public struct SubFile
                {
                    public int Lenght;
                    public ID Id;
                    public Offset Offset;
                    public SubSections SubSections;
                }

                public struct SubSections
                {
                    public SubSection SEC_0;
                    public SubSection SEC_1;
                    public SubSection SEC_2;
                    public SubSection SEC_3;
                    public SubSection SEC_4;
                    public SubSection SEC_5;
                    public SubSection SEC_6;
                }

                public struct ID
                {
                    public int SEC_1;
                    public int SEC_2;
                    public int SEC_3;
                    public int SEC_4;
                    public int SEC_5;
                    public int SEC_6;
                    public int SEC_7;
                }

                public struct Offset
                {
                    public long SEC_0;
                    public long SEC_1;
                    public long SEC_2;
                    public long SEC_3;
                    public long SEC_4;
                    public long SEC_5;
                    public long SEC_6;
                    public long SEC_7;
                }

                public struct SubSection
                {
                    public int Count;
                    public SubSectionEntry[] Entry;
                }

                public struct SubSectionEntry
                {
                    public int Type;
                    public long Offset;
                }

                public struct FILEEntry
                {
                    public string MagicHeader;
                    public long Offset;
                    public long Lenght;
                }
            }
            #endregion

            public static string GetTypeName(int id)
            {
                switch (id)
                {
                    case 1:
                        return ".cseq";
                    case 3:
                        return ".cbnk";
                    case 4:
                        return ".cwav";
                    case 5:
                        return ".group";
                    case 6:
                        return ".cwar";
                    default:
                        return ".bin";
                }
            }

            public enum Endian
            {
                BigEndian, LittleEndian // 0xFEFF = Big Endian, 0xFFFE = Little Endian
            }

            public struct CSARHeader
            {
                // 64 byte
                public byte[] MagicHeaderID; // 4 byte at 0
                public Endian ByteOrderMark; // 2 byte at 4
                public Info Info;
                public Partition Partition; // 1 byte at 10
            }

            public struct Info
            {
                public int Lenght; // 2 byte at 6
                public int Version; // 2 byte at A
                public int FileSize; // 4 byte at C
            }

            public struct Partition
            {
                public int Count;
                public int HeaderLenght;

                public Offset Offset;
                public Lenght Lenght;

                public int u1;
                public int u2;
                public int u3;
                public int u4;
            }

            public struct Offset
            {
                public long STRG;
                public long INFO;
                public long FILE;
            }

            public struct Lenght
            {
                public int STRG;
                public int INFO;
                public int FILE;
            }
        }
        #endregion 

        private string _Path = "";
        private Header.CSARHeader _CSARHeader = new Header.CSARHeader();
        private Header.STRG.STRGHeader _STRGHeader = new Header.STRG.STRGHeader();
        private Header.INFO.INFOHeader _INFOHeader = new Header.INFO.INFOHeader();

        private Stream _Stream;
        private long sPosition = 0;

        public Header.INFO.FILEEntry[] FILEe;

        public BCSAR(string path)
        {
            _Path = path;

            _Stream = new FileStream(_Path, FileMode.Open, FileAccess.Read);

            CSAR();
            STRG();
            INFO();
            FILEEntryLoad();

            _Stream.Close();
        }

        #region CSAR Header
        void CSAR()
        {
            _CSARHeader.ByteOrderMark = GetEndian();
            _CSARHeader.MagicHeaderID = MagicHeaderID();

            sPosition = 6;

            _CSARHeader.Info.Lenght = GetInt(4, sPosition);
            sPosition += 4;
            _CSARHeader.Info.Version = GetInt(2, sPosition);
            sPosition += 2;
            _CSARHeader.Info.FileSize = GetInt(4, sPosition);
            sPosition += 4;

            _CSARHeader.Partition.Count = GetInt(4, sPosition);
            sPosition += 4;
            _CSARHeader.Partition.HeaderLenght = GetInt(4, sPosition);
            sPosition += 4;

            _CSARHeader.Partition.Offset.STRG = GetInt(4, sPosition);
            sPosition += 4;
            _CSARHeader.Partition.Lenght.STRG = GetInt(4, sPosition);
            sPosition += 4;
            _CSARHeader.Partition.u1 = GetInt(4, sPosition);
            sPosition += 4;

            _CSARHeader.Partition.Offset.INFO = GetInt(4, sPosition);
            sPosition += 4;
            _CSARHeader.Partition.Lenght.INFO = GetInt(4, sPosition);
            sPosition += 4;
            _CSARHeader.Partition.u2 = GetInt(4, sPosition);
            sPosition += 4;

            _CSARHeader.Partition.Offset.FILE = GetInt(4, sPosition);
            sPosition += 4;
            _CSARHeader.Partition.Lenght.FILE = GetInt(4, sPosition);
            sPosition += 4;
            _CSARHeader.Partition.u3 = GetInt(4, sPosition);
            sPosition += 4;
            _CSARHeader.Partition.u4 = GetInt(4, sPosition);
            sPosition += 4;
        }

        public Header.CSARHeader CSARHeader
        {
            get
            {
                return _CSARHeader;
            }
        }
         
        #endregion

        #region STRG Header
        void STRG()
        {
            //_Stream.Position = _CSARHeader.Partition.Offset.STRG;
            sPosition = _CSARHeader.Partition.Offset.STRG;
            _STRGHeader.MagicHeaderID = MagicHeaderID();
            sPosition += 4;

            _STRGHeader.Info.Lenght = GetInt(4, sPosition);
            sPosition += 4;
            _STRGHeader.Info.u1 = GetInt(4, sPosition);
            sPosition += 4;

            _STRGHeader.SubFile.Lenght = GetInt(4, sPosition);
            sPosition += 4;
            _STRGHeader.SubFile.u1 = GetInt(4, sPosition);
            sPosition += 4;
            _STRGHeader.SubFile.MaskOffset = _CSARHeader.Partition.Offset.STRG + GetInt(4, sPosition) + 8;
            sPosition += 4;

            _STRGHeader.SubFile.Count = GetInt(4, sPosition);
            sPosition += 4;

            _STRGHeader.SubFile.FileEntry = new Header.STRG.SubFileEntry[_STRGHeader.SubFile.Count];

            for (int i = 0; i < _STRGHeader.SubFile.Count; i++)
            {
                _STRGHeader.SubFile.FileEntry[i].RootID = GetInt(4, sPosition);
                sPosition += 4;
                _STRGHeader.SubFile.FileEntry[i].Offset = GetInt(4, sPosition) + 24 + _CSARHeader.Partition.Offset.STRG;
                sPosition += 4;
                _STRGHeader.SubFile.FileEntry[i].Lenght = GetInt(4, sPosition);
                sPosition += 4;
            }
        }

        void FILEEntryLoad()
        {
            int index = getLastStream();
            int num1 = 16;

            FILEe = new Header.INFO.FILEEntry[_INFOHeader.SubFile.SubSections.SEC_6.Count-index];

            for (int i = 0; i < FILEe.Length; i++)
            {
                _Stream.Position = _INFOHeader.SubFile.SubSections.SEC_6.Entry[i + index].Offset + num1;

                byte[] temp = new byte[4];

                _Stream.Read(temp,0,temp.Length);

                FILEe[i].Offset = _CSARHeader.Partition.Offset.FILE + 8 + BitConverter.ToInt32(temp, 0);

                _Stream.Position = _INFOHeader.SubFile.SubSections.SEC_6.Entry[i + index].Offset + num1 + 4;
                _Stream.Read(temp,0,temp.Length);
                FILEe[i].Lenght = BitConverter.ToInt32(temp, 0);

                _Stream.Position = FILEe[i].Offset;
                _Stream.Read(temp,0,temp.Length);
                FILEe[i].MagicHeader = Encoding.ASCII.GetString(temp);
            }
        }
        public Header.STRG.STRGHeader STRGHeader
        {
            get
            {
                return _STRGHeader;
            }
        }

        public Header.STRG.MaskEntry GetMaskEntry(int id)
        {
            _Stream = new FileStream(_Path, FileMode.Open, FileAccess.Read);

            Header.STRG.MaskEntry _temp = new Header.STRG.MaskEntry();
            int num1 = 10;

            if (id == 0)
            {
                sPosition = _STRGHeader.SubFile.MaskOffset + num1;
                sPosition += 10;

                _temp.FileID = GetInt(4, sPosition);
                sPosition += 4;

                _temp.TypeIndex = GetInt(2, sPosition);
                sPosition += 2;

                _Stream.Position = sPosition;

                _temp.u1 = _Stream.ReadByte();
                sPosition += 1;

                _Stream.Position = sPosition;

                _temp.TypeID = _Stream.ReadByte();
                sPosition += 1;

                _temp.Const = GetInt(2, sPosition);
                sPosition += 2;
            }
            else
            {
                sPosition = _STRGHeader.SubFile.MaskOffset + num1;
                sPosition += 30 + (((int) id-1)*40);

                //_Stream.Position = sPosition;

                _temp.FileID = GetInt(4,sPosition); //4
                sPosition += 4;

                _temp.TypeIndex = GetInt(2, sPosition); //2
                sPosition += 2;

                _Stream.Position = sPosition;

                _temp.u1 = _Stream.ReadByte(); //1
                _temp.TypeID = _Stream.ReadByte(); //1

                sPosition += 2;

                _temp.u2 = GetInt(2, sPosition);//2
                sPosition += 2;

                _temp.u3 = GetInt(2, sPosition);//2
                sPosition += 2;

                _temp.u4 = GetInt(4, sPosition);//4
                sPosition += 4;

                _temp.u5 = GetInt(4, sPosition);//4
                sPosition += 12;

                _temp.Const = GetInt(2, sPosition);//2
            }
            _Stream.Close();
            return _temp;
        }

        public string GetNameString(int id)
        {
            _Stream = new FileStream(_Path, FileMode.Open, FileAccess.Read);
            _Stream.Position = _STRGHeader.SubFile.FileEntry[(int) id].Offset;
            byte[] temp = new byte[_STRGHeader.SubFile.FileEntry[(int)id].Lenght-1];
            _Stream.Read(temp, 0, temp.Length);
            _Stream.Close();
            return Encoding.ASCII.GetString(temp);
        }
        #endregion

        #region INFO Header

        void INFO()
        {
            //_Stream.Position = _CSARHeader.Partition.Offset.INFO;
            sPosition = _CSARHeader.Partition.Offset.INFO;

            _INFOHeader.MagicHeaderID = MagicHeaderID();
            sPosition += 4;

            _INFOHeader.Info.Lenght = GetInt(4, sPosition);
            sPosition += 4;
            _INFOHeader.Info.u1 = GetInt(4, sPosition);
            sPosition += 4;

            _INFOHeader.SubFile.Lenght = GetInt(4, sPosition);
            sPosition += 4;

            _INFOHeader.SubFile.Id.SEC_1 = GetInt(4, sPosition);
            sPosition += 4;
            _INFOHeader.SubFile.Offset.SEC_1 = GetInt(4, sPosition) + 8 + _CSARHeader.Partition.Offset.INFO;
            sPosition += 4;

            _INFOHeader.SubFile.Id.SEC_2 = GetInt(4, sPosition);
            sPosition += 4;
            _INFOHeader.SubFile.Offset.SEC_2 = GetInt(4, sPosition) + 8 + _CSARHeader.Partition.Offset.INFO;
            sPosition += 4;

            _INFOHeader.SubFile.Id.SEC_3 = GetInt(4, sPosition);
            sPosition += 4;
            _INFOHeader.SubFile.Offset.SEC_3 = GetInt(4, sPosition) + 8 + _CSARHeader.Partition.Offset.INFO;
            sPosition += 4;

            _INFOHeader.SubFile.Id.SEC_4 = GetInt(4, sPosition);
            sPosition += 4;
            _INFOHeader.SubFile.Offset.SEC_4 = GetInt(4, sPosition) + 8 + _CSARHeader.Partition.Offset.INFO;
            sPosition += 4;

            _INFOHeader.SubFile.Id.SEC_5 = GetInt(4, sPosition);
            sPosition += 4;
            _INFOHeader.SubFile.Offset.SEC_5 = GetInt(4, sPosition) + 8 + _CSARHeader.Partition.Offset.INFO;
            sPosition += 4;

            _INFOHeader.SubFile.Id.SEC_6 = GetInt(4, sPosition);
            sPosition += 4;
            _INFOHeader.SubFile.Offset.SEC_6 = GetInt(4, sPosition) + 8 + _CSARHeader.Partition.Offset.INFO;
            sPosition += 4;

            _INFOHeader.SubFile.Id.SEC_7 = GetInt(4, sPosition);
            sPosition += 4;
            _INFOHeader.SubFile.Offset.SEC_7 = GetInt(4, sPosition) + 8 + _CSARHeader.Partition.Offset.INFO;
            sPosition += 4;

            _Stream.Position = sPosition;

            _INFOHeader.SubFile.SubSections.SEC_0.Count = GetInt(4, sPosition);
            _INFOHeader.SubFile.SubSections.SEC_0.Entry = new Header.INFO.SubSectionEntry[_INFOHeader.SubFile.SubSections.SEC_0.Count];
            sPosition += 4;

            for (int i = 0; i < _INFOHeader.SubFile.SubSections.SEC_0.Count; i++)
            {
                _INFOHeader.SubFile.SubSections.SEC_0.Entry[i].Type = GetInt(4, sPosition);
                sPosition += 4;
                _INFOHeader.SubFile.SubSections.SEC_0.Entry[i].Offset = GetInt(4, sPosition) + (_INFOHeader.SubFile.Lenght + 12 + _CSARHeader.Partition.Offset.INFO);
                sPosition += 4;
            }

            _Stream.Position = _INFOHeader.SubFile.Offset.SEC_1;
            sPosition = _INFOHeader.SubFile.Offset.SEC_1;

            _INFOHeader.SubFile.SubSections.SEC_1.Count = GetInt(4, sPosition);
            _INFOHeader.SubFile.SubSections.SEC_1.Entry = new Header.INFO.SubSectionEntry[_INFOHeader.SubFile.SubSections.SEC_0.Count];
            sPosition += 4;

            if (_INFOHeader.SubFile.SubSections.SEC_1.Count == 0)
            {
                for (int i = 0; i < _INFOHeader.SubFile.SubSections.SEC_1.Count; i++)
                {
                    _INFOHeader.SubFile.SubSections.SEC_1.Entry[i].Type = GetInt(4, sPosition);
                    sPosition += 4;
                    _INFOHeader.SubFile.SubSections.SEC_1.Entry[i].Offset = GetInt(4, sPosition) + (_INFOHeader.SubFile.Offset.SEC_1);
                    sPosition += 4;
                }
            }
            

            _Stream.Position = _INFOHeader.SubFile.Offset.SEC_2;
            sPosition = _INFOHeader.SubFile.Offset.SEC_2;

            _INFOHeader.SubFile.SubSections.SEC_2.Count = GetInt(4, sPosition);
            _INFOHeader.SubFile.SubSections.SEC_2.Entry = new Header.INFO.SubSectionEntry[_INFOHeader.SubFile.SubSections.SEC_2.Count];
            sPosition += 4;

            for (int i = 0; i < _INFOHeader.SubFile.SubSections.SEC_2.Count; i++)
            {
                _INFOHeader.SubFile.SubSections.SEC_2.Entry[i].Type = GetInt(4, sPosition);
                sPosition += 4;
                _INFOHeader.SubFile.SubSections.SEC_2.Entry[i].Offset = GetInt(4, sPosition) + (_INFOHeader.SubFile.Offset.SEC_2);
                sPosition += 4;
            }

            _Stream.Position = _INFOHeader.SubFile.Offset.SEC_3;
            sPosition = _INFOHeader.SubFile.Offset.SEC_3;

            _INFOHeader.SubFile.SubSections.SEC_3.Count = GetInt(4, sPosition);
            _INFOHeader.SubFile.SubSections.SEC_3.Entry = new Header.INFO.SubSectionEntry[_INFOHeader.SubFile.SubSections.SEC_3.Count];
            sPosition += 4;

            for (int i = 0; i < _INFOHeader.SubFile.SubSections.SEC_3.Count; i++)
            {
                _INFOHeader.SubFile.SubSections.SEC_3.Entry[i].Type = GetInt(4, sPosition);
                sPosition += 4;
                _INFOHeader.SubFile.SubSections.SEC_3.Entry[i].Offset = GetInt(4, sPosition) + (_INFOHeader.SubFile.Offset.SEC_3);
                sPosition += 4;
            }

            _Stream.Position = _INFOHeader.SubFile.Offset.SEC_4;
            sPosition = _INFOHeader.SubFile.Offset.SEC_4;

            _INFOHeader.SubFile.SubSections.SEC_4.Count = GetInt(4, sPosition);
            _INFOHeader.SubFile.SubSections.SEC_4.Entry = new Header.INFO.SubSectionEntry[_INFOHeader.SubFile.SubSections.SEC_4.Count];
            sPosition += 4;

            for (int i = 0; i < _INFOHeader.SubFile.SubSections.SEC_4.Count; i++)
            {
                _INFOHeader.SubFile.SubSections.SEC_4.Entry[i].Type = GetInt(4, sPosition);
                sPosition += 4;
                _INFOHeader.SubFile.SubSections.SEC_4.Entry[i].Offset = GetInt(4, sPosition) + (_INFOHeader.SubFile.Offset.SEC_4);
                sPosition += 4;
            }

            _Stream.Position = _INFOHeader.SubFile.Offset.SEC_5;
            sPosition = _INFOHeader.SubFile.Offset.SEC_5;

            _INFOHeader.SubFile.SubSections.SEC_5.Count = GetInt(4, sPosition);
            _INFOHeader.SubFile.SubSections.SEC_5.Entry = new Header.INFO.SubSectionEntry[_INFOHeader.SubFile.SubSections.SEC_5.Count];
            sPosition += 4;

            for (int i = 0; i < _INFOHeader.SubFile.SubSections.SEC_5.Count; i++)
            {
                _INFOHeader.SubFile.SubSections.SEC_5.Entry[i].Type = GetInt(4, sPosition);
                sPosition += 4;
                _INFOHeader.SubFile.SubSections.SEC_5.Entry[i].Offset = GetInt(4, sPosition) + (_INFOHeader.SubFile.Offset.SEC_5);
                sPosition += 4;
            }

            _Stream.Position = _INFOHeader.SubFile.Offset.SEC_6;
            sPosition = _INFOHeader.SubFile.Offset.SEC_6;

            _INFOHeader.SubFile.SubSections.SEC_6.Count = GetInt(4, sPosition);
            _INFOHeader.SubFile.SubSections.SEC_6.Entry = new Header.INFO.SubSectionEntry[_INFOHeader.SubFile.SubSections.SEC_6.Count];
            sPosition += 4;

            for (int i = 0; i < _INFOHeader.SubFile.SubSections.SEC_6.Count; i++)
            {
                _INFOHeader.SubFile.SubSections.SEC_6.Entry[i].Type = GetInt(4, sPosition);
                sPosition += 4;
                _INFOHeader.SubFile.SubSections.SEC_6.Entry[i].Offset = GetInt(4, sPosition) + (_INFOHeader.SubFile.Offset.SEC_6);
                sPosition += 4;
            }

        }

        public Header.INFO.INFOHeader INFOHeader
        {
            get
            {
                return _INFOHeader;
            }
        }

        public int getLastStream()
        {
            //_Stream = new FileStream(_Path, FileMode.Open, FileAccess.Read);

            for (int i = 0; i < _INFOHeader.SubFile.SubSections.SEC_6.Count; i++)
            {
                _Stream.Position = _INFOHeader.SubFile.SubSections.SEC_6.Entry[i].Offset;
                byte[] temp = new byte[2];

                _Stream.Read(temp, 0, temp.Length);

                if (BitConverter.ToInt16(temp, 0) == 8716)
                {
                    return i;
                }
            }

            //_Stream.Close();
            return 0;
        }

        public int getLastStream2()
        {
            _Stream = new FileStream(_Path, FileMode.Open, FileAccess.Read);

            for (int i = 0; i < _INFOHeader.SubFile.SubSections.SEC_6.Count; i++)
            {
                _Stream.Position = _INFOHeader.SubFile.SubSections.SEC_6.Entry[i].Offset;
                byte[] temp = new byte[2];

                _Stream.Read(temp, 0, temp.Length);

                if (BitConverter.ToInt16(temp, 0) == 8716)
                {
                    return i;
                }
            }

            _Stream.Close();
            return 0;
        }

        #endregion

        #region Utilities
        byte[] MagicHeaderID()
        {
            byte[] vartemp = new byte[4];

            _Stream.Read(vartemp, 0, vartemp.Length);

            if (_CSARHeader.ByteOrderMark == Header.Endian.LittleEndian)
            {
                vartemp.Reverse();
            }

            return vartemp;
        }

        int GetInt(int lenght, long position)
        {
            byte[] vartemp = new byte[lenght];

            _Stream.Position = position;
            _Stream.Read(vartemp, 0, vartemp.Length);

            if (_CSARHeader.ByteOrderMark == Header.Endian.LittleEndian)
            {
                vartemp.Reverse();
            }

            if (lenght < 3)
            {
                return BitConverter.ToInt16(vartemp, 0);
            }
            else
            {
                return BitConverter.ToInt32(vartemp, 0);
            }
        }

        int GetInt(int lenght, int position)
        {
            byte[] vartemp = new byte[lenght];

            _Stream.Position = position;
            _Stream.Read(vartemp, 0, vartemp.Length);

            if (_CSARHeader.ByteOrderMark == Header.Endian.LittleEndian)
            {
                vartemp.Reverse();
            }

            if (lenght < 3)
            {
                return BitConverter.ToInt16(vartemp, 0);
            }
            else
            {
                return BitConverter.ToInt32(vartemp, 0);
            }
        }

        Header.Endian GetEndian()
        {
            byte[] vartemp = new byte[2];

            _Stream.Position = 4;
            _Stream.Read(vartemp, 0, vartemp.Length);

            if (vartemp[0] == (byte)254 && vartemp[1] == (byte)255)
            {
                return Header.Endian.LittleEndian;
            }
            else
            {
                return Header.Endian.BigEndian;
            }
        }
        #endregion
    }
}
