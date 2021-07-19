namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildHouseUpdateInformationMessage : NetworkMessage
	{
		public const uint Id = 952;
		public override uint MessageId => Id;
		public HouseInformationsForGuild housesInformations { get; set; }

		public GuildHouseUpdateInformationMessage(HouseInformationsForGuild housesInformations)
		{
			this.housesInformations = housesInformations;
		}

		public GuildHouseUpdateInformationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			housesInformations.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			housesInformations = new HouseInformationsForGuild();
			housesInformations.Deserialize(reader);
		}

	}
}
