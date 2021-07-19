using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AmaknaProxy.API.IO
{
    public class BigEndianWriter : IDataWriter, IDisposable
    {
        #region Properties

        private BinaryWriter m_writer;

        public Stream BaseStream
        {
            get { return m_writer.BaseStream; }
        }

        /// <summary>
        ///   Gets available bytes number in the buffer
        /// </summary>
        public long BytesAvailable
        {
            get { return m_writer.BaseStream.Length - m_writer.BaseStream.Position; }
        }

        public long Position
        {
            get { return m_writer.BaseStream.Position; }
            set
            {
                m_writer.BaseStream.Position = value;
            }
        }

        public byte[] Data
        {
            get
            {
                var pos = m_writer.BaseStream.Position;

                var data = new byte[m_writer.BaseStream.Length];
                m_writer.BaseStream.Position = 0;
                m_writer.BaseStream.Read(data, 0, (int)m_writer.BaseStream.Length);

                m_writer.BaseStream.Position = pos;

                return data;
            }
        }

        #endregion

        #region Initialisation

        /// <summary>
        /// Initializes a new instance of the <see cref="BigEndianWriter"/> class.
        /// </summary>
        public BigEndianWriter()
        {
            m_writer = new BinaryWriter(new MemoryStream(), Encoding.UTF8);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BigEndianWriter"/> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public BigEndianWriter(Stream stream)
        {
            m_writer = new BinaryWriter(stream, Encoding.UTF8);
        }

        public BigEndianWriter(byte[] buffer)
        {
            m_writer = new BinaryWriter(new MemoryStream(buffer));
        }
        #endregion

        #region Private Methods

        /// <summary>
        ///   Reverse bytes and write them into the buffer
        /// </summary>
        private void WriteBigEndianBytes(byte[] endianBytes)
        {
            for (int i = endianBytes.Length - 1; i >= 0; i--)
            {
                m_writer.Write(endianBytes[i]);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///   Write a Short into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteShort(short @short)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@short));
        }

        /// <summary>
        ///   Write a int into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteInt(int @int)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@int));
        }

        /// <summary>
        ///   Write a long into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteLong(Int64 @long)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@long));
        }

        /// <summary>
        ///   Write a UShort into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteUShort(ushort @ushort)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@ushort));
        }

        /// <summary>
        ///   Write a int into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteUInt(UInt32 @uint)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@uint));
        }

        /// <summary>
        ///   Write a long into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteULong(UInt64 @ulong)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@ulong));
        }

        /// <summary>
        ///   Write a byte into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteByte(byte @byte)
        {
            m_writer.Write(@byte);
        }

        public void WriteSByte(sbyte @byte)
        {
            WriteSbyte(@byte);
        }

        public void WriteSbyte(sbyte @byte)
        {
            m_writer.Write(@byte);
        }
        /// <summary>
        ///   Write a Float into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteFloat(float @float)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@float));
        }

        /// <summary>
        ///   Write a Boolean into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteBoolean(Boolean @bool)
        {
            if (@bool)
            {
                m_writer.Write((byte)1);
            }
            else
            {
                m_writer.Write((byte)0);
            }
        }

        /// <summary>
        ///   Write a Char into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteChar(Char @char)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@char));
        }

        /// <summary>
        ///   Write a Double into the buffer
        /// </summary>
        public void WriteDouble(Double @double)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@double));
        }

        /// <summary>
        ///   Write a Single into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteSingle(Single @single)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@single));
        }

        /// <summary>
        ///   Write a string into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteUTF(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            var len = (ushort)bytes.Length;
            WriteUShort(len);

            int i;
            for (i = 0; i < len; i++)
                m_writer.Write(bytes[i]);
        }

        /// <summary>
        ///   Write a string into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteUTFBytes(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            var len = bytes.Length;
            int i;
            for (i = 0; i < len; i++)
                m_writer.Write(bytes[i]);
        }

        /// <summary>
        ///   Write a bytes array into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteBytes(byte[] data)
        {
            m_writer.Write(data);
        }

        /// <summary>
        ///   Write a bytes array into the buffer
        /// </summary>
        /// <returns></returns>
        public void WriteBytes(byte[] data, uint offset, uint length)
        {
            byte[] array = new byte[length];
            Array.Copy(data, offset, array, 0, length);
            m_writer.Write(array);
        }


        public void Seek(int offset, SeekOrigin seekOrigin)
        {
            m_writer.BaseStream.Seek(offset, seekOrigin);
        }


        public void Clear()
        {
            m_writer = new BinaryWriter(new MemoryStream(), Encoding.UTF8);
        }

        #endregion

        #region Custom Methods

        private static int INT_SIZE = 32;

        private static int SHORT_MIN_VALUE = -32768;

        private static int SHORT_MAX_VALUE = 32767;

        private static int UNSIGNED_SHORT_MAX_VALUE = 65536;

        private static int CHUNCK_BIT_SIZE = 7;

        private static int MAX_ENCODING_LENGTH = (int)Math.Ceiling((double)INT_SIZE / CHUNCK_BIT_SIZE);

        private static int MASK_10000000 = 128;

        private static int MASK_01111111 = 127;

        public void WriteVarInt(int value)
        {
            if (value >= 0 && value <= MASK_01111111)
            {
                WriteByte((byte)value);
                return;
            }
            int b = 0;
            int c = value;
            while (c != 0 && c != -1)
            {
                b = c & MASK_01111111;
                c = c >> CHUNCK_BIT_SIZE;
                if (c > 0)
                {
                    b = b | MASK_10000000;
                }
                WriteByte((byte)b);
            }
        }

        public void WriteVarUInt(uint value)
        {
            if (value <= MASK_01111111)
            {
                WriteByte((byte)value);
                return;
            }
            uint b = 0;
            uint c = value;
            while (c != 0)
            {
                b = (uint)(c & MASK_01111111);
                c = c >> CHUNCK_BIT_SIZE;
                if (c > 0)
                {
                    b = b | (uint)MASK_10000000;
                }
                WriteByte((byte)b);
            }
        }

        public void WriteVarShort(short value)
        {
            if (value > SHORT_MAX_VALUE || value < SHORT_MIN_VALUE)
            {
                throw new Exception("Forbidden value");
            }
            else
            {
                var b = 0;
                if ((value >= 0) && (value <= MASK_01111111))
                {
                    WriteByte((byte)value);
                    return;
                }
                var c = value & 65535;
                while (c != 0 && c != -1)
                {
                    b = (c & MASK_01111111);
                    c = c >> CHUNCK_BIT_SIZE;
                    if (c > 0)
                    {
                        b = b | MASK_10000000;
                    }
                    WriteByte((byte)b);
                }
            }
        }

        public void WriteVarUShort(ushort value)
        {
            if (value > UNSIGNED_SHORT_MAX_VALUE || value < SHORT_MIN_VALUE)
            {
                throw new Exception("Forbidden value");
            }
            else
            {
                var b = 0;
                if ((value >= 0) && (value <= MASK_01111111))
                {
                    WriteByte((byte)value);
                    return;
                }
                var c = value & 65535;
                while (c != 0)
                {
                    b = (c & MASK_01111111);
                    c = c >> CHUNCK_BIT_SIZE;
                    if (c > 0)
                    {
                        b = b | MASK_10000000;
                    }
                    WriteByte((byte)b);
                }
            }
        }

        public void WriteVarLong(long value)
        {
            uint i = 0;
            var val = FinalInt64.FromNumber(value);
            if (val.High == 0)
            {
                WriteInt32(val.Low);
            }
            else
            {
                i = 0;
                while (i < 4)
                {
                    WriteByte((byte)(val.Low & 127 | 128));
                    val.Low = val.Low >> 7;
                    i++;
                }
                if ((val.High & 268435455 << 3) == 0)
                {
                    WriteByte((byte)(val.High << 4 | val.Low));
                }
                else
                {
                    WriteByte((byte)(((val.High << 4) | val.Low) & 127 | 128));
                    WriteInt32(val.High >> 3);
                }
            }
        }

        public void WriteVarULong(ulong value)
        {
            WriteVarLong((long)value);
        }

        public void WriteInt32(uint param1)
        {
            while(param1 >= 128)
            {
                WriteByte((byte)(param1 & 127 | 128));
                param1 = param1 >> 7;
            }
            WriteByte((byte)param1);
        }


        #endregion

        #region Dispose

        public void Dispose()
        {
            m_writer.Dispose();
            m_writer = null;
        }

        #endregion
    }
}
