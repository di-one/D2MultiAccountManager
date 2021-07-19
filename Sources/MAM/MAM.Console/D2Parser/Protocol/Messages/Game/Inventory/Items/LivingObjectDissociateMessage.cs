namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class LivingObjectDissociateMessage : NetworkMessage
	{
		public const uint Id = 5480;
		public override uint MessageId => Id;
		public uint livingUID { get; set; }
		public byte livingPosition { get; set; }

		public LivingObjectDissociateMessage(uint livingUID, byte livingPosition)
		{
			this.livingUID = livingUID;
			this.livingPosition = livingPosition;
		}

		public LivingObjectDissociateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(livingUID);
			writer.WriteByte(livingPosition);
		}

		public override void Deserialize(IDataReader reader)
		{
			livingUID = reader.ReadVarUInt();
			livingPosition = reader.ReadByte();
		}

	}
}
