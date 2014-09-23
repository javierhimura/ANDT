using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Andi.Utils.Citro.Audio;

namespace Andi.Utils.Nitro.Archive
{
    public class Narc
    {
        #region Inner Class
        public class Header
        {
            public struct NARCHeader
            {
                public byte[] MagicHeaderID; // 4 byte
                public BCSAR.Header.Endian ByteMarkOrder; // 2 byte
                public long u1; // 2 byte
                public long FileSize; // 4
                public long HeaderSize; // 2
                public int HeaderSection; // 2

                public FATBHeader FATBheader;
                public FATBEntry[] FATBEntry;

                public FNTBHeader FNTBheader;
                public FNTBRootEntry[] FNTBRootEntry;
                public FNTBFileEntry[] FNTBFileEntry;
                public FIMGHeader FIMGHeader;
            }

            public struct FATBHeader
            {
                public byte[] MagicHeaderID; // 4
                public long Lenght; // 4
                public long Count; // 4
            }

            public struct FATBEntry
            {
                public int Offset;
                public int Size;
            }

            public struct FNTBHeader
            {
                public byte[] MagicHeaderID; // 4
                public long Lenght; // 4
                public int DirCount; // 2
            }

            public struct FNTBRootEntry
            {
                public int Offset; // 4
                public int Position; // 2
                public int Count; // 2
            }

            public struct FNTBFileEntry
            {
                public int FirstOffset;
                public int FirstPosition; //2
                public int ParentDir; //2
                public int NameSize; //1
                public string Name; //
            }

            public struct FIMGHeader
            {
                public byte[] MagicHeaderID; // 4
                public long Lenght; // 4
            }
        }
        #endregion

        private Stream _Stream;
        private Header.NARCHeader _Narcs = new Header.NARCHeader();
        private string _Paths;
        private byte[] _cad;
        private int mode = 0;

        public Narc(string pathdata, bool MemorySteam=false)
        {
            _Paths = pathdata;

            if (MemorySteam == false)
            {
                mode = 0;
            }
            else
            {
                mode = 1;
            }
            
            FileOpener(mode);
        }

        public Header.NARCHeader NARCS
        {
            get { return _Narcs; }
        }

        public Narc(byte[] input)
        {
            FileOpener(2,input);
        }

        void FileOpener(int id, byte[] b = null)
        {
            if (id == 0)
            {
                _Stream = new FileStream(_Paths, FileMode.Open);
            }
            else if (id == 1)
            {
                _cad = File.ReadAllBytes(_Paths);
                _Stream = new MemoryStream(_cad);
            }
            else
            {
                _Stream = new MemoryStream(b);
            }

            FileLoad();

            _Stream.Close();
        }

        void FileLoad()
        {
            byte[] _temp = new byte[4];
            _Stream.Position = 0;

            #region GetNARC Header
            _temp = new[]   {
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte(), 
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte()
                            };

            _Narcs.MagicHeaderID = _temp;

            _temp = new[]   {
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte()
                            };

            if (_temp[0] == (byte)254 && _temp[1] == (byte)255)
            {
                _Narcs.ByteMarkOrder = BCSAR.Header.Endian.LittleEndian;
            }
            else
            {
                _Narcs.ByteMarkOrder = BCSAR.Header.Endian.BigEndian;
            }

            _temp = new[]   {
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte()
                            };

            _Narcs.u1 = BitConverter.ToInt16(_temp, 0);

            _temp = new[]   {
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte(), 
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte()
                            };

            _Narcs.FileSize = BitConverter.ToInt32(_temp, 0);

            _temp = new[]   {
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte()
                            };

            _Narcs.HeaderSize = BitConverter.ToInt16(_temp, 0);

            _temp = new[]   {
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte()
                            };

            _Narcs.HeaderSection = BitConverter.ToInt16(_temp, 0);
            #endregion

            #region GetNARC FATB Header and entries
            _Stream.Position = _Narcs.HeaderSize;

            _temp = new[]   {
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte(), 
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte()
                            };

            _Narcs.FATBheader.MagicHeaderID = _temp;

            _temp = new[]   {
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte(), 
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte()
                            };

            _Narcs.FATBheader.Lenght = BitConverter.ToInt32(_temp, 0);

            _temp = new[]   {
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte(), 
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte()
                            };

            _Narcs.FATBheader.Count = BitConverter.ToInt32(_temp, 0);
            _Narcs.FATBEntry = new Header.FATBEntry[_Narcs.FATBheader.Count];

            for (int i = 0; i < _Narcs.FATBheader.Count; i++)
            {
                _temp = new[]   {
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte(), 
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte()
                            };

                _Narcs.FATBEntry[i].Offset = BitConverter.ToInt32(_temp, 0);

                _temp = new[]   {
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte(), 
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte()
                            };

                _Narcs.FATBEntry[i].Size = BitConverter.ToInt32(_temp, 0) - _Narcs.FATBEntry[i].Offset;
            }

            #endregion

            #region FNTBheader and entry

            _Stream.Position = _Narcs.HeaderSize + _Narcs.FATBheader.Lenght;

            _temp = new[]   {
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte(), 
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte()
                            };

            _Narcs.FNTBheader.MagicHeaderID = _temp;

            _temp = new[]   {
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte(), 
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte()
                            };

            _Narcs.FNTBheader.Lenght = BitConverter.ToInt32(_temp, 0);

            // Not Complete, but it will done shortly

            #endregion

            #region FIMGHeader and entry

            _Stream.Position = _Narcs.HeaderSize + _Narcs.FATBheader.Lenght + _Narcs.FNTBheader.Lenght;

            _temp = new[]   {
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte(), 
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte()
                            };

            _Narcs.FIMGHeader.MagicHeaderID = _temp;

            _temp = new[]   {
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte(), 
                                (byte) _Stream.ReadByte(), (byte) _Stream.ReadByte()
                            };

            _Narcs.FIMGHeader.Lenght = BitConverter.ToInt32(_temp, 0);

            long num = _Narcs.HeaderSize + _Narcs.FATBheader.Lenght + _Narcs.FNTBheader.Lenght + 8;

            for (int i = 0; i < _Narcs.FATBheader.Count; i++)
            {
                _Narcs.FATBEntry[i].Offset += (int)num;
            }
            #endregion
        }

        

        public void ReplaceFile(int index, int newsize, byte[] replacement)
        {
            if (mode == 1 || mode == 2)
            {
                byte[] cached = _cad;

                try
                {
                    int num1 = newsize - this._Narcs.FATBEntry[index].Size;
                    _Stream = new MemoryStream();
                    _Stream.Write(_cad, 0, this._cad.Length);

                    if (num1 > 0)
                    {
                        _Stream.SetLength(_Stream.Length + num1);
                    }

                    this._Stream.Seek(8L, SeekOrigin.Begin);
                    new BinaryWriter((Stream)this._Stream).Write((int)_Narcs.FileSize + num1);
                    _cad = Io.Utils.ReadToEnd(_Stream);
                    _Stream.Close();
                    
                    if (num1 > 0)
                    {
                        for (int index1 = (int) _Narcs.FATBheader.Count - 1; index1 > index; --index1)
                        {
                            this._Stream = new MemoryStream(this._cad);
                            this._Stream.Seek((long)this._Narcs.FATBEntry[index1].Offset, SeekOrigin.Begin);
                            BinaryReader binaryReader = new BinaryReader((Stream)this._Stream);
                            BinaryWriter binaryWriter = new BinaryWriter((Stream)this._Stream);

                            byte[] buffer = new byte[this._Narcs.FATBEntry[index1].Size];
                            binaryReader.Read(buffer, 0, this._Narcs.FATBEntry[index1].Size);
                            this._Stream.Seek((long)(-this._Narcs.FATBEntry[index1].Size + num1), SeekOrigin.Current);
                            binaryWriter.Write(buffer, 0, this._Narcs.FATBEntry[index1].Size);
                            _cad = Io.Utils.ReadToEnd(_Stream);
                            this._Stream.Close();
                        }
                        this._Stream = new MemoryStream(this._cad);
                        this._Stream.Seek((long)this._Narcs.FATBEntry[index].Offset, SeekOrigin.Begin);
                        new BinaryWriter((Stream)this._Stream).Write(replacement);
                        _cad = Io.Utils.ReadToEnd(_Stream);
                        this._Stream.Close();

                        for (int index1 = index; index1 < this._Narcs.FATBheader.Count; ++index1)
                        {
                            this._Stream = new MemoryStream(this._cad);
                            this._Stream.Seek((long)(28 + index1 * 8), SeekOrigin.Begin);
                            BinaryWriter binaryWriter = new BinaryWriter((Stream)this._Stream);
                            BinaryReader binaryReader = new BinaryReader((Stream)this._Stream);
                            if (index1 == index)
                            {
                                this._Stream.Seek(4L, SeekOrigin.Current);
                                long num2 = (long)binaryReader.ReadUInt32();
                                this._Stream.Seek(-4L, SeekOrigin.Current);
                                binaryWriter.Write((int)num2 + num1);
                                this._Narcs.FATBEntry[index].Size += num1;
                            }
                            else
                            {
                                long num2 = (long)binaryReader.ReadUInt32();
                                this._Stream.Seek(-4L, SeekOrigin.Current);
                                binaryWriter.Write((int)num2 + num1);
                                long num3 = (long)binaryReader.ReadUInt32();
                                this._Stream.Seek(-4L, SeekOrigin.Current);
                                binaryWriter.Write((int)num3 + num1);
                                this._Narcs.FATBEntry[index1].Offset += num1;
                            }
                            _cad = Io.Utils.ReadToEnd(_Stream);
                            this._Stream.Close();
                        }
                    }
                    else if (num1 < 0)
                    {
                        for (int index1 = index + 1; index1 < this._Narcs.FATBheader.Count; ++index1)
                        {
                            this._Stream = new MemoryStream(this._cad);
                            this._Stream.Seek((long)this._Narcs.FATBEntry[index1].Offset, SeekOrigin.Begin);
                            BinaryReader binaryReader = new BinaryReader((Stream)this._Stream);
                            BinaryWriter binaryWriter = new BinaryWriter((Stream)this._Stream);
                            byte[] buffer = new byte[this._Narcs.FATBEntry[index1].Size];
                            binaryReader.Read(buffer, 0, this._Narcs.FATBEntry[index1].Size);
                            this._Stream.Seek((long)(-this._Narcs.FATBEntry[index1].Size + num1), SeekOrigin.Current);
                            binaryWriter.Write(buffer, 0, this._Narcs.FATBEntry[index1].Size);
                            _cad = Io.Utils.ReadToEnd(_Stream);
                            this._Stream.Close();
                        }

                        this._Stream = new MemoryStream(this._cad);
                        this._Stream.Seek((long)this._Narcs.FATBEntry[index].Offset, SeekOrigin.Begin);
                        new BinaryWriter((Stream)this._Stream).Write(replacement);
                        _cad = Io.Utils.ReadToEnd(_Stream);
                        this._Stream.Close();

                        for (int index1 = index; index1 < this._Narcs.FATBheader.Count; ++index1)
                        {
                            this._Stream = new MemoryStream(this._cad);
                            this._Stream.Seek((long)(28 + index1 * 8), SeekOrigin.Begin);
                            BinaryWriter binaryWriter = new BinaryWriter((Stream)this._Stream);
                            BinaryReader binaryReader = new BinaryReader((Stream)this._Stream);
                            if (index1 == index)
                            {
                                this._Stream.Seek(4L, SeekOrigin.Current);
                                long num2 = (long)binaryReader.ReadUInt32();
                                this._Stream.Seek(-4L, SeekOrigin.Current);
                                binaryWriter.Write((int)num2 + num1);
                                this._Narcs.FATBEntry[index].Size += num1;
                            }
                            else
                            {
                                long num2 = (long)binaryReader.ReadUInt32();
                                this._Stream.Seek(-4L, SeekOrigin.Current);
                                binaryWriter.Write((int)num2 + num1);
                                long num3 = (long)binaryReader.ReadUInt32();
                                this._Stream.Seek(-4L, SeekOrigin.Current);
                                binaryWriter.Write((int)num3 + num1);
                                this._Narcs.FATBEntry[index1].Offset += num1;
                            }
                            _cad = Io.Utils.ReadToEnd(_Stream);
                            this._Stream.Close();
                        }

                        this._Stream = new MemoryStream();
                        this._Stream.Write(this._cad, 0, this._cad.Length + num1);
                        _cad = Io.Utils.ReadToEnd(_Stream);
                        this._Stream.Close();
                    }
                    else
                    {
                        this._Stream = new MemoryStream(this._cad);
                        this._Stream.Seek((long)this._Narcs.FATBEntry[index].Offset, SeekOrigin.Begin);
                        new BinaryWriter((Stream)this._Stream).Write(replacement);
                        _cad = Io.Utils.ReadToEnd(_Stream);
                        this._Stream.Close();
                    }
                }
                catch
                {
                    _cad = cached;
                }
            }
            else
            {
                // Not Complete, but it will done shortly
            }
        }

        public byte[] getdataselected(int id)
        {
            if (mode == 0)
            {
                _Stream = new FileStream(_Paths,FileMode.Open);
                _Stream.Seek((long)this._Narcs.FATBEntry[id].Offset, SeekOrigin.Begin);
            }
            else
            {
                _Stream = new MemoryStream(_cad);
                _Stream.Seek((long)this._Narcs.FATBEntry[id].Offset, SeekOrigin.Begin);
            }

            BinaryReader binaryReader = new BinaryReader(this._Stream);

            byte[] buffer = new byte[this._Narcs.FATBEntry[id].Size];
            binaryReader.Read(buffer, 0, this._Narcs.FATBEntry[id].Size);
            binaryReader.Close();

            _Stream.Close();

            return buffer;
        }
    }
}
