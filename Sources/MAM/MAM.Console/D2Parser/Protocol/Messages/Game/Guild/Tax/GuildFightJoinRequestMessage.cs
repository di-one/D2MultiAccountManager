namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildFightJoinRequestMessage : NetworkMessage
	{
		public const uint Id = 3900;
		public override uint MessageId => Id;
		public double taxCollectorId { get; set; }

		public GuildFightJoinRequestMessage(double taxCollectorId)
		{
			this.taxCollectorId = taxCollectorId;
		}

		public GuildFightJoinRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(taxCollectorId);
		}

		public override void Deserialize(IDataReader reader)
		{
			taxCollectorId = reader.ReadDouble();
		}

	}
}
