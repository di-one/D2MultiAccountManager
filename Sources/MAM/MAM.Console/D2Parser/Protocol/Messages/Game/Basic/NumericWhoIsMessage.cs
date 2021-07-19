namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class NumericWhoIsMessage : NetworkMessage
	{
		public const uint Id = 5847;
		public override uint MessageId => Id;
		public ulong playerId { get; set; }
		public int accountId { get; set; }

		public NumericWhoIsMessage(ulong playerId, int accountId)
		{
			this.playerId = playerId;
			this.accountId = accountId;
		}

		public NumericWhoIsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(playerId);
			writer.WriteInt(accountId);
		}

		public override void Deserialize(IDataReader reader)
		{
			playerId = reader.ReadVarULong();
			accountId = reader.ReadInt();
		}

	}
}
