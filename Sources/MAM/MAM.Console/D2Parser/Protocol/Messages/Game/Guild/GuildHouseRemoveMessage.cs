namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildHouseRemoveMessage : NetworkMessage
	{
		public const uint Id = 9595;
		public override uint MessageId => Id;
		public uint houseId { get; set; }
		public int instanceId { get; set; }
		public bool secondHand { get; set; }

		public GuildHouseRemoveMessage(uint houseId, int instanceId, bool secondHand)
		{
			this.houseId = houseId;
			this.instanceId = instanceId;
			this.secondHand = secondHand;
		}

		public GuildHouseRemoveMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(houseId);
			writer.WriteInt(instanceId);
			writer.WriteBoolean(secondHand);
		}

		public override void Deserialize(IDataReader reader)
		{
			houseId = reader.ReadVarUInt();
			instanceId = reader.ReadInt();
			secondHand = reader.ReadBoolean();
		}

	}
}
