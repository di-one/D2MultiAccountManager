namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TeleportHavenBagRequestMessage : NetworkMessage
	{
		public const uint Id = 4331;
		public override uint MessageId => Id;
		public ulong guestId { get; set; }

		public TeleportHavenBagRequestMessage(ulong guestId)
		{
			this.guestId = guestId;
		}

		public TeleportHavenBagRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(guestId);
		}

		public override void Deserialize(IDataReader reader)
		{
			guestId = reader.ReadVarULong();
		}

	}
}
