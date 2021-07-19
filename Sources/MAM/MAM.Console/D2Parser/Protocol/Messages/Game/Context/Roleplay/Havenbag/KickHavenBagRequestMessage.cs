namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class KickHavenBagRequestMessage : NetworkMessage
	{
		public const uint Id = 4805;
		public override uint MessageId => Id;
		public ulong guestId { get; set; }

		public KickHavenBagRequestMessage(ulong guestId)
		{
			this.guestId = guestId;
		}

		public KickHavenBagRequestMessage() { }

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
