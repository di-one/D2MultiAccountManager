using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AmaknaProxy.API.IO
{
    public class BigEndianReader : IDataReader, IDisposable
    {

        #region Properties

        private BinaryReader m_reader;

        /// <summary>
        ///   Gets availiable bytes number in the buffer
        /// </summary>
        public long BytesAvailable
        {
            get { return m_reader.BaseStream.Length - m_reader.BaseStream.Position; }
        }

        public long Position
        {
            get
            {
                return m_reader.BaseStream.Position;
            }
        }


        public Stream BaseStream
        {
            get
            {
                return m_reader.BaseStream;
            }
        }

        #endregion

        #region Initialisation

        /// <summary>
        ///   Initializes a new instance of the <see cref = "BigEndianReader" /> class.
        /// </summary>
        public BigEndianReader()
        {
            m_reader = new BinaryReader(new MemoryStream(), Encoding.UTF8);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "BigEndianReader" /> class.
        /// </summary>
        /// <param name = "stream">The stream.</param>
        public BigEndianReader(Stream stream)
        {
            m_reader = new BinaryReader(stream, Encoding.UTF8);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "BigEndianReader" /> class.
        /// </summary>
        /// <param name = "tab">Memory buffer.</param>
        public BigEndianReader(byte[] tab)
        {
            m_reader = new BinaryReader(new MemoryStream(tab), Encoding.UTF8);
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///   Read bytes in big endian format
        /// </summary>
        /// <param name = "count"></param>
        /// <returns></returns>
        private byte[] ReadBigEndianBytes(int count)
        {
            var bytes = new byte[count];
            int i;
            for (i = count - 1; i >= 0; i--)
                bytes[i] = (byte)BaseStream.ReadByte();
            return bytes;
        }

        #endregion

        #region Public Method

        /// <summary>
        ///   Read a Short from the Buffer
        /// </summary>
        /// <returns></returns>
        public short ReadShort()
        {
            return BitConverter.ToInt16(ReadBigEndianBytes(2), 0);
        }

        /// <summary>
        ///   Read a int from the Buffer
        /// </summary>
        /// <returns></returns>
        public int ReadInt()
        {
            return BitConverter.ToInt32(ReadBigEndianBytes(4), 0);
        }

        /// <summary>
        ///   Read a long from the Buffer
        /// </summary>
        /// <returns></returns>
        public Int64 ReadLong()
        {
            return BitConverter.ToInt64(ReadBigEndianBytes(8), 0);
        }

        /// <summary>
        ///   Read a Float from the Buffer
        /// </summary>
        /// <returns></returns>
        public float ReadFloat()
        {
            return BitConverter.ToSingle(ReadBigEndianBytes(4), 0);
        }

        /// <summary>
        ///   Read a UShort from the Buffer
        /// </summary>
        /// <returns></returns>
        public ushort ReadUShort()
        {
            return BitConverter.ToUInt16(ReadBigEndianBytes(2), 0);
        }

        /// <summary>
        ///   Read a int from the Buffer
        /// </summary>
        /// <returns></returns>
        public UInt32 ReadUInt()
        {
            return BitConverter.ToUInt32(ReadBigEndianBytes(4), 0);
        }

        /// <summary>
        ///   Read a long from the Buffer
        /// </summary>
        /// <returns></returns>
        public UInt64 ReadULong()
        {
            return BitConverter.ToUInt64(ReadBigEndianBytes(8), 0);
        }

        /// <summary>
        ///   Read a byte from the Buffer
        /// </summary>
        /// <returns></returns>
        public byte ReadByte()
        {
            return m_reader.ReadByte();
        }

        public sbyte ReadSByte()
        {
            return ReadSbyte();
        }

        public sbyte ReadSbyte()
        {
            return m_reader.ReadSByte();
        }

        public byte[] Data
        {
            get
            {
                long pos = BaseStream.Position;

                byte[] data = new byte[BaseStream.Length];
                BaseStream.Position = 0;
                BaseStream.Read(data, 0, (int)BaseStream.Length);

                BaseStream.Position = pos;

                return data;
            }
        }
        /// <summary>
        ///   Returns N bytes from the buffer
        /// </summary>
        /// <param name = "n">Number of read bytes.</param>
        /// <returns></returns>
        public byte[] ReadBytes(int n)
        {
            return m_reader.ReadBytes(n);
        }

        /// <summary>
        /// Returns N bytes from the buffer
        /// </summary>
        /// <param name = "n">Number of read bytes.</param>
        /// <returns></returns>
        public BigEndianReader ReadBytesInNewBigEndianReader(int n)
        {
            return new BigEndianReader(m_reader.ReadBytes(n));
        }

        /// <summary>
        ///   Read a Boolean from the Buffer
        /// </summary>
        /// <returns></returns>
        public Boolean ReadBoolean()
        {
            return m_reader.ReadByte() == 1;
        }

        /// <summary>
        ///   Read a Char from the Buffer
        /// </summary>
        /// <returns></returns>
        public Char ReadChar()
        {
            return (char)ReadUShort();
        }

        /// <summary>
        ///   Read a Double from the Buffer
        /// </summary>
        /// <returns></returns>
        public Double ReadDouble()
        {
            return BitConverter.ToDouble(ReadBigEndianBytes(8), 0);
        }

        /// <summary>
        ///   Read a Single from the Buffer
        /// </summary>
        /// <returns></returns>
        public Single ReadSingle()
        {
            return BitConverter.ToSingle(ReadBigEndianBytes(4), 0);
        }

        /// <summary>
        ///   Read a string from the Buffer
        /// </summary>
        /// <returns></returns>
        public string ReadUTF()
        {
            ushort length = ReadUShort();

            byte[] bytes = ReadBytes(length);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        ///   Read a string from the Buffer
        /// </summary>
        /// <returns></returns>
        public string ReadUTF7BitLength()
        {
            int length = ReadInt();

            byte[] bytes = ReadBytes(length);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        ///   Read a string from the Buffer
        /// </summary>
        /// <returns></returns>
        public string ReadUTFBytes(ushort len)
        {
            byte[] bytes = ReadBytes(len);

            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        ///   Skip bytes
        /// </summary>
        /// <param name = "n"></param>
        public void SkipBytes(int n)
        {
            int i;
            for (i = 0; i < n; i++)
            {
                m_reader.ReadByte();
            }
        }

        public void SetPosition(int Position)
        {
            Seek(Position, SeekOrigin.Begin);
        }

        public void Seek(int offset, SeekOrigin seekOrigin)
        {
            m_reader.BaseStream.Seek(offset, seekOrigin);
        }

        /// <summary>
        ///   Add a bytes array to the end of the buffer
        /// </summary>
        public void Add(byte[] data, int offset, int count)
        {
            long pos = m_reader.BaseStream.Position;

            m_reader.BaseStream.Position = m_reader.BaseStream.Length;
            m_reader.BaseStream.Write(data, offset, count);
            m_reader.BaseStream.Position = pos;
        }

        public void Close()
        {
            BaseStream.Close();
        }

        #endregion

        #region Alternatives Methods
        public short ReadInt16()
        {
            return ReadShort();
        }

        public int ReadInt32()
        {
            return ReadInt();
        }

        public long ReadInt64()
        {
            return ReadLong();
        }

        public ushort ReadUInt16()
        {
            return ReadUShort();
        }

        public uint ReadUInt32()
        {
            return ReadUInt();
        }

        public ulong ReadUInt64()
        {
            return ReadULong();
        }

        public string ReadString()
        {
            return ReadUTF();
        }
        #endregion

        #region Custom Methods

        private static int INT_SIZE = 32;

        private static int SHORT_SIZE = 16;

        private static int SHORT_MAX_VALUE = 32767;

        private static int UNSIGNED_SHORT_MAX_VALUE = 65536;

        private static int CHUNCK_BIT_SIZE = 7;

        private static int MAX_ENCODING_LENGTH = (int)Math.Ceiling((double)INT_SIZE / CHUNCK_BIT_SIZE);

        private static int MASK_10000000 = 128;

        private static int MASK_01111111 = 127;

        public int ReadVarInt()
        {
            int b = 0;
            int value = 0;
            int offset = 0;
            bool hasNext = false;
            while (offset < INT_SIZE)
            {
                b = ReadByte();
                hasNext = (b & MASK_10000000) == MASK_10000000;
                if (offset > 0)
                {
                    value = value + ((b & MASK_01111111) << offset);
                }
                else
                {
                    value = value + (b & MASK_01111111);
                }
                offset = offset + CHUNCK_BIT_SIZE;
                if (!hasNext)
                {
                    return value;
                }
            }
            throw new Exception("Too much data");
        }

        public uint ReadVarUInt()
        {
            int b = 0;
            uint value = 0;
            int offset = 0;
            bool hasNext = false;
            while (offset < INT_SIZE)
            {
                b = ReadByte();
                hasNext = (b & MASK_10000000) == MASK_10000000;
                if (offset > 0)
                {
                    value = (uint)(value + ((b & MASK_01111111) << offset));
                }
                else
                {
                    value = (uint)(value + (b & MASK_01111111));
                }
                offset = offset + CHUNCK_BIT_SIZE;
                if (!hasNext)
                {
                    return value;
                }
            }
            throw new Exception("Too much data");
        }

        public short ReadVarShort()
        {
            int b = 0;
            short value = 0;
            int offset = 0;
            bool hasNext = false;
            while (offset < SHORT_SIZE)
            {
                b = ReadByte();
                hasNext = (b & MASK_10000000) == MASK_10000000;
                if (offset > 0)
                {
                    value = (short)(value + ((b & MASK_01111111) << offset));
                }
                else
                {
                    value = (short)(value + (b & MASK_01111111));
                }
                offset = offset + CHUNCK_BIT_SIZE;
                if (!hasNext)
                {
                    if (value > SHORT_MAX_VALUE)
                    {
                        value = (short)(value - UNSIGNED_SHORT_MAX_VALUE);
                    }
                    return value;
                }
            }
            throw new Exception("Too much data");
        }

        public ushort ReadVarUShort()
        {
            int b = 0;
            ushort value = 0;
            int offset = 0;
            bool hasNext = false;
            while (offset < SHORT_SIZE)
            {
                b = ReadByte();
                hasNext = (b & MASK_10000000) == MASK_10000000;
                if (offset > 0)
                {
                    value = (ushort)(value + ((b & MASK_01111111) << offset));
                }
                else
                {
                    value = (ushort)(value + (b & MASK_01111111));
                }
                offset = offset + CHUNCK_BIT_SIZE;
                if (!hasNext)
                {
                    if (value > SHORT_MAX_VALUE)
                    {
                        value = (ushort)(value - UNSIGNED_SHORT_MAX_VALUE);
                    }
                    return value;
                }
            }
            throw new Exception("Too much data");
        }

        public long ReadVarLong()
        {
            return ReadVarInt64(this).ToNumber();
        }

        public ulong ReadVarULong()
        {
            return ReadVarUInt64(this).ToNumber();
        }

        private static FinalInt64 ReadVarInt64(IDataReader input)
        {
            uint b = 0;
            FinalInt64 result = new FinalInt64();
            int i = 0;
            while (true)
            {
                b = input.ReadByte();
                if (i == 28)
                {
                    break;
                }
                if (b >= 128)
                {
                    result.Low = result.Low | (b & 127) << i;
                    i = i + 7;
                    continue;
                }
                result.Low = result.Low | b << i;
                return result;
            }

            if (b >= 128)
            {
                b = b & 127;
                result.Low = result.Low | b << i;
                result.High = b >> 4;
                i = 3;
                while (true)
                {
                    b = input.ReadByte();
                    if (i < 32)
                    {
                        if (b >= 128)
                        {
                            result.High = (uint)(result.High | (b & 127) << i);
                        }
                        else
                        {
                            break;
                        }
                    }
                    i = i + 7;
                }

                result.High = (uint)(result.High | (b << i));
                return result;
            }
            result.Low = result.Low | b << i;
            result.High = b >> 4;
            return result;
        }

        private FinalUInt64 ReadVarUInt64(IDataReader input)
        {
            uint b = 0;
            var result = new FinalUInt64();
            int i = 0;
            while (true)
            {
                b = input.ReadByte();
                if (i == 28)
                {
                    break;
                }
                if (b >= 128)
                {
                    result.Low = result.Low | (b & 127) << i;
                    i = i + 7;
                    continue;
                }
                result.Low = result.Low | b << i;
                return result;
            }

            if (b >= 128)
            {
                b = b & 127;
                result.Low = result.Low | b << i;
                result.High = b >> 4;
                i = 3;
                while (true)
                {
                    b = input.ReadByte();
                    if (i < 32)
                    {
                        if (b >= 128)
                        {
                            result.High = result.High | (b & 127) << i;
                        }
                        else
                        {
                            break;
                        }
                    }
                    i = i + 7;
                }

                result.High = result.High | b << i;
                return result;
            }
            result.Low = result.Low | b << i;
            result.Low = b >> 4;
            return result;
        }

        #endregion

        #region Dispose

        /// <summary>
        ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            m_reader.Dispose();
            m_reader = null;
        }

        #endregion
    }
}