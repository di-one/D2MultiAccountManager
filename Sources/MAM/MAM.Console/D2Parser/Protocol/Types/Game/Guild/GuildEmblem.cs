namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildEmblem
	{
		public const short Id  = 150;
		public virtual short TypeId => Id;
		public ushort symbolShape { get; set; }
		public int symbolColor { get; set; }
		public sbyte backgroundShape { get; set; }
		public int backgroundColor { get; set; }

		public GuildEmblem(ushort symbolShape, int symbolColor, sbyte backgroundShape, int backgroundColor)
		{
			this.symbolShape = symbolShape;
			this.symbolColor = symbolColor;
			this.backgroundShape = backgroundShape;
			this.backgroundColor = backgroundColor;
		}

		public GuildEmblem() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(symbolShape);
			writer.WriteInt(symbolColor);
			writer.WriteSByte(backgroundShape);
			writer.WriteInt(backgroundColor);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			symbolShape = reader.ReadVarUShort();
			symbolColor = reader.ReadInt();
			backgroundShape = reader.ReadSByte();
			backgroundColor = reader.ReadInt();
		}

	}
}
