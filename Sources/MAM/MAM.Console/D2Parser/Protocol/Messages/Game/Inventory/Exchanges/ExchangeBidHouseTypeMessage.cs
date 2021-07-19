namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeBidHouseTypeMessage : NetworkMessage
	{
		public const uint Id = 1080;
		public override uint MessageId => Id;
		public uint type { get; set; }
		public bool follow { get; set; }

		public ExchangeBidHouseTypeMessage(uint type, bool follow)
		{
			this.type = type;
			this.follow = follow;
		}

		public ExchangeBidHouseTypeMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(type);
			writer.WriteBoolean(follow);
		}

		public override void Deserialize(IDataReader reader)
		{
			type = reader.ReadVarUInt();
			follow = reader.ReadBoolean();
		}

	}
}
