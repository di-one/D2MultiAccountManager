namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HouseGuildNoneMessage : NetworkMessage
	{
		public const uint Id = 8085;
		public override uint MessageId => Id;
		public uint houseId { get; set; }
		public int instanceId { get; set; }
		public bool secondHand { get; set; }

		public HouseGuildNoneMessage(uint houseId, int instanceId, bool secondHand)
		{
			this.houseId = houseId;
			this.instanceId = instanceId;
			this.secondHand = secondHand;
		}

		public HouseGuildNoneMessage() { }

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
