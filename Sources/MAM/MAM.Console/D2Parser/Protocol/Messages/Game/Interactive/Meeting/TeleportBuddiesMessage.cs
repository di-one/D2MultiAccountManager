namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TeleportBuddiesMessage : NetworkMessage
	{
		public const uint Id = 172;
		public override uint MessageId => Id;
		public ushort dungeonId { get; set; }

		public TeleportBuddiesMessage(ushort dungeonId)
		{
			this.dungeonId = dungeonId;
		}

		public TeleportBuddiesMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(dungeonId);
		}

		public override void Deserialize(IDataReader reader)
		{
			dungeonId = reader.ReadVarUShort();
		}

	}
}
