namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HouseTeleportRequestMessage : NetworkMessage
	{
		public const uint Id = 353;
		public override uint MessageId => Id;
		public uint houseId { get; set; }
		public int houseInstanceId { get; set; }

		public HouseTeleportRequestMessage(uint houseId, int houseInstanceId)
		{
			this.houseId = houseId;
			this.houseInstanceId = houseInstanceId;
		}

		public HouseTeleportRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(houseId);
			writer.WriteInt(houseInstanceId);
		}

		public override void Deserialize(IDataReader reader)
		{
			houseId = reader.ReadVarUInt();
			houseInstanceId = reader.ReadInt();
		}

	}
}
