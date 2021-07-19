namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeOkMultiCraftMessage : NetworkMessage
	{
		public const uint Id = 7294;
		public override uint MessageId => Id;
		public ulong initiatorId { get; set; }
		public ulong otherId { get; set; }
		public sbyte role { get; set; }

		public ExchangeOkMultiCraftMessage(ulong initiatorId, ulong otherId, sbyte role)
		{
			this.initiatorId = initiatorId;
			this.otherId = otherId;
			this.role = role;
		}

		public ExchangeOkMultiCraftMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(initiatorId);
			writer.WriteVarULong(otherId);
			writer.WriteSByte(role);
		}

		public override void Deserialize(IDataReader reader)
		{
			initiatorId = reader.ReadVarULong();
			otherId = reader.ReadVarULong();
			role = reader.ReadSByte();
		}

	}
}
