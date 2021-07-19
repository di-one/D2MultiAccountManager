namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangePlayerMultiCraftRequestMessage : ExchangeRequestMessage
	{
		public new const uint Id = 1395;
		public override uint MessageId => Id;
		public ulong target { get; set; }
		public uint skillId { get; set; }

		public ExchangePlayerMultiCraftRequestMessage(sbyte exchangeType, ulong target, uint skillId)
		{
			this.exchangeType = exchangeType;
			this.target = target;
			this.skillId = skillId;
		}

		public ExchangePlayerMultiCraftRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(target);
			writer.WriteVarUInt(skillId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			target = reader.ReadVarULong();
			skillId = reader.ReadVarUInt();
		}

	}
}
