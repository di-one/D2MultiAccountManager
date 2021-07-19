namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HouseKickRequestMessage : NetworkMessage
	{
		public const uint Id = 8457;
		public override uint MessageId => Id;
		public ulong objectId { get; set; }

		public HouseKickRequestMessage(ulong objectId)
		{
			this.objectId = objectId;
		}

		public HouseKickRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(objectId);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarULong();
		}

	}
}
