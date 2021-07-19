namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class LivingObjectChangeSkinRequestMessage : NetworkMessage
	{
		public const uint Id = 9648;
		public override uint MessageId => Id;
		public uint livingUID { get; set; }
		public byte livingPosition { get; set; }
		public uint skinId { get; set; }

		public LivingObjectChangeSkinRequestMessage(uint livingUID, byte livingPosition, uint skinId)
		{
			this.livingUID = livingUID;
			this.livingPosition = livingPosition;
			this.skinId = skinId;
		}

		public LivingObjectChangeSkinRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(livingUID);
			writer.WriteByte(livingPosition);
			writer.WriteVarUInt(skinId);
		}

		public override void Deserialize(IDataReader reader)
		{
			livingUID = reader.ReadVarUInt();
			livingPosition = reader.ReadByte();
			skinId = reader.ReadVarUInt();
		}

	}
}
