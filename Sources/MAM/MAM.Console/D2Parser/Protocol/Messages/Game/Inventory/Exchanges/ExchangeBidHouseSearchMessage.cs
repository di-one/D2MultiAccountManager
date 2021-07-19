namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeBidHouseSearchMessage : NetworkMessage
	{
		public const uint Id = 4493;
		public override uint MessageId => Id;
		public ushort genId { get; set; }
		public bool follow { get; set; }

		public ExchangeBidHouseSearchMessage(ushort genId, bool follow)
		{
			this.genId = genId;
			this.follow = follow;
		}

		public ExchangeBidHouseSearchMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(genId);
			writer.WriteBoolean(follow);
		}

		public override void Deserialize(IDataReader reader)
		{
			genId = reader.ReadVarUShort();
			follow = reader.ReadBoolean();
		}

	}
}
