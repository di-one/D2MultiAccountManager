namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeCraftCountRequestMessage : NetworkMessage
	{
		public const uint Id = 6781;
		public override uint MessageId => Id;
		public int count { get; set; }

		public ExchangeCraftCountRequestMessage(int count)
		{
			this.count = count;
		}

		public ExchangeCraftCountRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarInt(count);
		}

		public override void Deserialize(IDataReader reader)
		{
			count = reader.ReadVarInt();
		}

	}
}
