namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeStartOkMulticraftCustomerMessage : NetworkMessage
	{
		public const uint Id = 9290;
		public override uint MessageId => Id;
		public uint skillId { get; set; }
		public byte crafterJobLevel { get; set; }

		public ExchangeStartOkMulticraftCustomerMessage(uint skillId, byte crafterJobLevel)
		{
			this.skillId = skillId;
			this.crafterJobLevel = crafterJobLevel;
		}

		public ExchangeStartOkMulticraftCustomerMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(skillId);
			writer.WriteByte(crafterJobLevel);
		}

		public override void Deserialize(IDataReader reader)
		{
			skillId = reader.ReadVarUInt();
			crafterJobLevel = reader.ReadByte();
		}

	}
}
