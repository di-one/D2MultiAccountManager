namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HouseGuildRightsMessage : NetworkMessage
	{
		public const uint Id = 5242;
		public override uint MessageId => Id;
		public uint houseId { get; set; }
		public int instanceId { get; set; }
		public bool secondHand { get; set; }
		public GuildInformations guildInfo { get; set; }
		public uint rights { get; set; }

		public HouseGuildRightsMessage(uint houseId, int instanceId, bool secondHand, GuildInformations guildInfo, uint rights)
		{
			this.houseId = houseId;
			this.instanceId = instanceId;
			this.secondHand = secondHand;
			this.guildInfo = guildInfo;
			this.rights = rights;
		}

		public HouseGuildRightsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(houseId);
			writer.WriteInt(instanceId);
			writer.WriteBoolean(secondHand);
			guildInfo.Serialize(writer);
			writer.WriteVarUInt(rights);
		}

		public override void Deserialize(IDataReader reader)
		{
			houseId = reader.ReadVarUInt();
			instanceId = reader.ReadInt();
			secondHand = reader.ReadBoolean();
			guildInfo = new GuildInformations();
			guildInfo.Deserialize(reader);
			rights = reader.ReadVarUInt();
		}

	}
}
