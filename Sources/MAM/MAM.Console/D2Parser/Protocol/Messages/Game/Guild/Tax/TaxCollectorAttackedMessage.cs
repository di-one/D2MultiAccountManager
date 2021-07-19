namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TaxCollectorAttackedMessage : NetworkMessage
	{
		public const uint Id = 9866;
		public override uint MessageId => Id;
		public ushort firstNameId { get; set; }
		public ushort lastNameId { get; set; }
		public short worldX { get; set; }
		public short worldY { get; set; }
		public double mapId { get; set; }
		public ushort subAreaId { get; set; }
		public BasicGuildInformations guild { get; set; }

		public TaxCollectorAttackedMessage(ushort firstNameId, ushort lastNameId, short worldX, short worldY, double mapId, ushort subAreaId, BasicGuildInformations guild)
		{
			this.firstNameId = firstNameId;
			this.lastNameId = lastNameId;
			this.worldX = worldX;
			this.worldY = worldY;
			this.mapId = mapId;
			this.subAreaId = subAreaId;
			this.guild = guild;
		}

		public TaxCollectorAttackedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(firstNameId);
			writer.WriteVarUShort(lastNameId);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
			writer.WriteDouble(mapId);
			writer.WriteVarUShort(subAreaId);
			guild.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			firstNameId = reader.ReadVarUShort();
			lastNameId = reader.ReadVarUShort();
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
			mapId = reader.ReadDouble();
			subAreaId = reader.ReadVarUShort();
			guild = new BasicGuildInformations();
			guild.Deserialize(reader);
		}

	}
}
