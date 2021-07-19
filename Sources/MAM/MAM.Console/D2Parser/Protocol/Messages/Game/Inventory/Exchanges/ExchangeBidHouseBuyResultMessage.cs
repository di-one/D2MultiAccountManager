namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeBidHouseBuyResultMessage : NetworkMessage
	{
		public const uint Id = 5558;
		public override uint MessageId => Id;
		public uint uid { get; set; }
		public bool bought { get; set; }

		public ExchangeBidHouseBuyResultMessage(uint uid, bool bought)
		{
			this.uid = uid;
			this.bought = bought;
		}

		public ExchangeBidHouseBuyResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(uid);
			writer.WriteBoolean(bought);
		}

		public override void Deserialize(IDataReader reader)
		{
			uid = reader.ReadVarUInt();
			bought = reader.ReadBoolean();
		}

	}
}
