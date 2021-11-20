using System;
using System.Buffers.Binary;
using System.IO;
using System.Text;

namespace MeshSharp.IO
{
	internal class EndianWriter : BinaryWriter
	{
		public EndianWriter(Stream output) : base(output) { }
		public EndianWriter(Stream output, Encoding encoding) : base(output, encoding) { }
		public EndianWriter(Stream output, Encoding encoding, bool leaveOpen) : base(output, encoding, leaveOpen) { }
		protected EndianWriter() { }

		private bool isBigEndian = false;
		public bool IsBigEndian
		{
			get => isBigEndian;
			set => isBigEndian = value;
		}

		public override void Write(short value)
		{
			if (isBigEndian)
			{
				byte[] bytes = new byte[2];
				BinaryPrimitives.WriteInt16BigEndian(bytes, value);
				base.Write(bytes);
			}
			else
			{
				base.Write(value);
			}
		}

		public override void Write(ushort value)
		{
			if (isBigEndian)
			{
				byte[] bytes = new byte[2];
				BinaryPrimitives.WriteUInt16BigEndian(bytes, value);
				base.Write(bytes);
			}
			else
			{
				base.Write(value);
			}
		}

		public override void Write(int value)
		{
			if (isBigEndian)
			{
				byte[] bytes = new byte[4];
				BinaryPrimitives.WriteInt32BigEndian(bytes, value);
				base.Write(bytes);
			}
			else
			{
				base.Write(value);
			}
		}

		public override void Write(uint value)
		{
			if (isBigEndian)
			{
				byte[] bytes = new byte[4];
				BinaryPrimitives.WriteUInt32BigEndian(bytes, value);
				base.Write(bytes);
			}
			else
			{
				base.Write(value);
			}
		}

		public override void Write(long value)
		{
			if (isBigEndian)
			{
				byte[] bytes = new byte[8];
				BinaryPrimitives.WriteInt64BigEndian(bytes, value);
				base.Write(bytes);
			}
			else
			{
				base.Write(value);
			}
		}

		public override void Write(ulong value)
		{
			if (isBigEndian)
			{
				byte[] bytes = new byte[8];
				BinaryPrimitives.WriteUInt64BigEndian(bytes, value);
				base.Write(bytes);
			}
			else
			{
				base.Write(value);
			}
		}

		public override void Write(Half value)
		{
			if (isBigEndian)
			{
				byte[] bytes = new byte[2];
				BinaryPrimitives.WriteHalfBigEndian(bytes, value);
				base.Write(bytes);
			}
			else
			{
				base.Write(value);
			}
		}

		public override void Write(float value)
		{
			if (isBigEndian)
			{
				byte[] bytes = new byte[4];
				BinaryPrimitives.WriteSingleBigEndian(bytes, value);
				base.Write(bytes);
			}
			else
			{
				base.Write(value);
			}
		}

		public override void Write(double value)
		{
			if (isBigEndian)
			{
				byte[] bytes = new byte[8];
				BinaryPrimitives.WriteDoubleBigEndian(bytes, value);
				base.Write(bytes);
			}
			else
			{
				base.Write(value);
			}
		}

		public override void Write(decimal value)
		{
			if (isBigEndian)
			{
				throw new NotSupportedException();
			}
			else
			{
				base.Write(value);
			}
		}
	}
}
