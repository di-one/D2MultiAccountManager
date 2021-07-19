namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildFightLeaveRequestMessage : NetworkMessage
	{
		public const uint Id = 5341;
		public override uint MessageId => Id;
		public double taxCollectorId { get; set; }
		public ulong characterId { get; set; }

		public GuildFightLeaveRequestMessage(double taxCollectorId, ulong characterId)
		{
			this.taxCollectorId = taxCollectorId;
			this.characterId = characterId;
		}

		public GuildFightLeaveRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(taxCollectorId);
			writer.WriteVarULong(characterId);
		}

		public override void Deserialize(IDataReader reader)
		{
			taxCollectorId = reader.ReadDouble();
			characterId = reader.ReadVarULong();
		}

	}
}
