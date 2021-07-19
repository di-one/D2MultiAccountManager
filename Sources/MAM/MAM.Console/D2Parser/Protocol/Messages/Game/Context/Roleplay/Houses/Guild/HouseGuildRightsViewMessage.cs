namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HouseGuildRightsViewMessage : NetworkMessage
	{
		public const uint Id = 6288;
		public override uint MessageId => Id;
		public uint houseId { get; set; }
		public int instanceId { get; set; }

		public HouseGuildRightsViewMessage(uint houseId, int instanceId)
		{
			this.houseId = houseId;
			this.instanceId = instanceId;
		}

		public HouseGuildRightsViewMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(houseId);
			writer.WriteInt(instanceId);
		}

		public override void Deserialize(IDataReader reader)
		{
			houseId = reader.ReadVarUInt();
			instanceId = reader.ReadInt();
		}

	}
}
