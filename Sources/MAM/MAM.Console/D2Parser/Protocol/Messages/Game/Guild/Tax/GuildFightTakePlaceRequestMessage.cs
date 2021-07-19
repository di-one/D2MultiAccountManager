namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildFightTakePlaceRequestMessage : GuildFightJoinRequestMessage
	{
		public new const uint Id = 388;
		public override uint MessageId => Id;
		public ulong replacedCharacterId { get; set; }

		public GuildFightTakePlaceRequestMessage(double taxCollectorId, ulong replacedCharacterId)
		{
			this.taxCollectorId = taxCollectorId;
			this.replacedCharacterId = replacedCharacterId;
		}

		public GuildFightTakePlaceRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(replacedCharacterId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			replacedCharacterId = reader.ReadVarULong();
		}

	}
}
