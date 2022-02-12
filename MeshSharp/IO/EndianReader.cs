using System;
using System.Buffers.Binary;
using System.IO;
using System.Text;

namespace AssetRipper.MeshSharp.IO
{
	internal class EndianReader : BinaryReader
	{
		public EndianReader(Stream input) : base(input) { }
		public EndianReader(Stream input, Encoding encoding) : base(input, encoding) { }
		public EndianReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen) { }

		private bool isBigEndian = false;
		public bool IsBigEndian
		{
			get => isBigEndian;
			set => isBigEndian = value;
		}

		public override short ReadInt16()
		{
			if (isBigEndian)
				return BinaryPrimitives.ReadInt16BigEndian(base.ReadBytes(2));
			else
				return base.ReadInt16();
		}

		public override ushort ReadUInt16()
		{
			if (isBigEndian)
				return BinaryPrimitives.ReadUInt16BigEndian(base.ReadBytes(2));
			else
				return base.ReadUInt16();
		}

		public override int ReadInt32()
		{
			if (isBigEndian)
				return BinaryPrimitives.ReadInt32BigEndian(base.ReadBytes(4));
			else
				return base.ReadInt32();
		}

		public override uint ReadUInt32()
		{
			if (isBigEndian)
				return BinaryPrimitives.ReadUInt32BigEndian(base.ReadBytes(4));
			else
				return base.ReadUInt32();
		}

		public override long ReadInt64()
		{
			if (isBigEndian)
				return BinaryPrimitives.ReadInt64BigEndian(base.ReadBytes(8));
			else
				return base.ReadInt64();
		}

		public override ulong ReadUInt64()
		{
			if (isBigEndian)
				return BinaryPrimitives.ReadUInt64BigEndian(base.ReadBytes(8));
			else
				return base.ReadUInt64();
		}

		public override Half ReadHalf()
		{
			if (isBigEndian)
				return BinaryPrimitives.ReadHalfBigEndian(base.ReadBytes(2));
			else
				return base.ReadHalf();
		}

		public override float ReadSingle()
		{
			if (isBigEndian)
				return BinaryPrimitives.ReadSingleBigEndian(base.ReadBytes(4));
			else
				return base.ReadSingle();
		}

		public override double ReadDouble()
		{
			if (isBigEndian)
				return BinaryPrimitives.ReadDoubleBigEndian(base.ReadBytes(8));
			else
				return base.ReadDouble();
		}

		public override decimal ReadDecimal()
		{
			if (isBigEndian)
				throw new NotSupportedException();
			else
				return base.ReadDecimal();
		}
	}
}
