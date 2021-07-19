namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HouseGuildShareRequestMessage : NetworkMessage
	{
		public const uint Id = 8772;
		public override uint MessageId => Id;
		public uint houseId { get; set; }
		public int instanceId { get; set; }
		public bool enable { get; set; }
		public uint rights { get; set; }

		public HouseGuildShareRequestMessage(uint houseId, int instanceId, bool enable, uint rights)
		{
			this.houseId = houseId;
			this.instanceId = instanceId;
			this.enable = enable;
			this.rights = rights;
		}

		public HouseGuildShareRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(houseId);
			writer.WriteInt(instanceId);
			writer.WriteBoolean(enable);
			writer.WriteVarUInt(rights);
		}

		public override void Deserialize(IDataReader reader)
		{
			houseId = reader.ReadVarUInt();
			instanceId = reader.ReadInt();
			enable = reader.ReadBoolean();
			rights = reader.ReadVarUInt();
		}

	}
}
