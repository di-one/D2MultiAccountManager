namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeStartOkCraftWithInformationMessage : ExchangeStartOkCraftMessage
	{
		public new const uint Id = 2301;
		public override uint MessageId => Id;
		public uint skillId { get; set; }

		public ExchangeStartOkCraftWithInformationMessage(uint skillId)
		{
			this.skillId = skillId;
		}

		public ExchangeStartOkCraftWithInformationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(skillId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			skillId = reader.ReadVarUInt();
		}

	}
}
