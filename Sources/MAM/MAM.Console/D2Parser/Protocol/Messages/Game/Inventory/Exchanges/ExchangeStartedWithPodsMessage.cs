namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeStartedWithPodsMessage : ExchangeStartedMessage
	{
		public new const uint Id = 5315;
		public override uint MessageId => Id;
		public double firstCharacterId { get; set; }
		public uint firstCharacterCurrentWeight { get; set; }
		public uint firstCharacterMaxWeight { get; set; }
		public double secondCharacterId { get; set; }
		public uint secondCharacterCurrentWeight { get; set; }
		public uint secondCharacterMaxWeight { get; set; }

		public ExchangeStartedWithPodsMessage(sbyte exchangeType, double firstCharacterId, uint firstCharacterCurrentWeight, uint firstCharacterMaxWeight, double secondCharacterId, uint secondCharacterCurrentWeight, uint secondCharacterMaxWeight)
		{
			this.exchangeType = exchangeType;
			this.firstCharacterId = firstCharacterId;
			this.firstCharacterCurrentWeight = firstCharacterCurrentWeight;
			this.firstCharacterMaxWeight = firstCharacterMaxWeight;
			this.secondCharacterId = secondCharacterId;
			this.secondCharacterCurrentWeight = secondCharacterCurrentWeight;
			this.secondCharacterMaxWeight = secondCharacterMaxWeight;
		}

		public ExchangeStartedWithPodsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(firstCharacterId);
			writer.WriteVarUInt(firstCharacterCurrentWeight);
			writer.WriteVarUInt(firstCharacterMaxWeight);
			writer.WriteDouble(secondCharacterId);
			writer.WriteVarUInt(secondCharacterCurrentWeight);
			writer.WriteVarUInt(secondCharacterMaxWeight);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			firstCharacterId = reader.ReadDouble();
			firstCharacterCurrentWeight = reader.ReadVarUInt();
			firstCharacterMaxWeight = reader.ReadVarUInt();
			secondCharacterId = reader.ReadDouble();
			secondCharacterCurrentWeight = reader.ReadVarUInt();
			secondCharacterMaxWeight = reader.ReadVarUInt();
		}

	}
}
