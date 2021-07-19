namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeStartOkMulticraftCrafterMessage : NetworkMessage
	{
		public const uint Id = 6031;
		public override uint MessageId => Id;
		public uint skillId { get; set; }

		public ExchangeStartOkMulticraftCrafterMessage(uint skillId)
		{
			this.skillId = skillId;
		}

		public ExchangeStartOkMulticraftCrafterMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(skillId);
		}

		public override void Deserialize(IDataReader reader)
		{
			skillId = reader.ReadVarUInt();
		}

	}
}
