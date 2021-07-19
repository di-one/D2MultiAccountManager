namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PaddockInformationsForSell
	{
		public const short Id  = 6938;
		public virtual short TypeId => Id;
		public string guildOwner { get; set; }
		public short worldX { get; set; }
		public short worldY { get; set; }
		public ushort subAreaId { get; set; }
		public sbyte nbMount { get; set; }
		public sbyte nbObject { get; set; }
		public ulong price { get; set; }

		public PaddockInformationsForSell(string guildOwner, short worldX, short worldY, ushort subAreaId, sbyte nbMount, sbyte nbObject, ulong price)
		{
			this.guildOwner = guildOwner;
			this.worldX = worldX;
			this.worldY = worldY;
			this.subAreaId = subAreaId;
			this.nbMount = nbMount;
			this.nbObject = nbObject;
			this.price = price;
		}

		public PaddockInformationsForSell() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(guildOwner);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
			writer.WriteVarUShort(subAreaId);
			writer.WriteSByte(nbMount);
			writer.WriteSByte(nbObject);
			writer.WriteVarULong(price);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			guildOwner = reader.ReadUTF();
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
			subAreaId = reader.ReadVarUShort();
			nbMount = reader.ReadSByte();
			nbObject = reader.ReadSByte();
			price = reader.ReadVarULong();
		}

	}
}
