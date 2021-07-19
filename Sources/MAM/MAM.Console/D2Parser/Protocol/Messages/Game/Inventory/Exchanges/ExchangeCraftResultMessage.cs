namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeCraftResultMessage : NetworkMessage
	{
		public const uint Id = 908;
		public override uint MessageId => Id;
		public sbyte craftResult { get; set; }

		public ExchangeCraftResultMessage(sbyte craftResult)
		{
			this.craftResult = craftResult;
		}

		public ExchangeCraftResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(craftResult);
		}

		public override void Deserialize(IDataReader reader)
		{
			craftResult = reader.ReadSByte();
		}

	}
}
