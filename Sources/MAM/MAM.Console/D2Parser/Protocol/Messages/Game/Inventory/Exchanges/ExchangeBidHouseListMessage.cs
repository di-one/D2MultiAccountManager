namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeBidHouseListMessage : NetworkMessage
	{
		public const uint Id = 2870;
		public override uint MessageId => Id;
		public ushort objectId { get; set; }
		public bool follow { get; set; }

		public ExchangeBidHouseListMessage(ushort objectId, bool follow)
		{
			this.objectId = objectId;
			this.follow = follow;
		}

		public ExchangeBidHouseListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(objectId);
			writer.WriteBoolean(follow);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarUShort();
			follow = reader.ReadBoolean();
		}

	}
}
