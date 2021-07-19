namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeCraftCountModifiedMessage : NetworkMessage
	{
		public const uint Id = 2936;
		public override uint MessageId => Id;
		public int count { get; set; }

		public ExchangeCraftCountModifiedMessage(int count)
		{
			this.count = count;
		}

		public ExchangeCraftCountModifiedMessage() { }

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
