namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class NumericWhoIsRequestMessage : NetworkMessage
	{
		public const uint Id = 7502;
		public override uint MessageId => Id;
		public ulong playerId { get; set; }

		public NumericWhoIsRequestMessage(ulong playerId)
		{
			this.playerId = playerId;
		}

		public NumericWhoIsRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(playerId);
		}

		public override void Deserialize(IDataReader reader)
		{
			playerId = reader.ReadVarULong();
		}

	}
}
