namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class DungeonKeyRingUpdateMessage : NetworkMessage
	{
		public const uint Id = 91;
		public override uint MessageId => Id;
		public ushort dungeonId { get; set; }
		public bool available { get; set; }

		public DungeonKeyRingUpdateMessage(ushort dungeonId, bool available)
		{
			this.dungeonId = dungeonId;
			this.available = available;
		}

		public DungeonKeyRingUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(dungeonId);
			writer.WriteBoolean(available);
		}

		public override void Deserialize(IDataReader reader)
		{
			dungeonId = reader.ReadVarUShort();
			available = reader.ReadBoolean();
		}

	}
}
