namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildHousesInformationMessage : NetworkMessage
	{
		public const uint Id = 843;
		public override uint MessageId => Id;
		public IEnumerable<HouseInformationsForGuild> housesInformations { get; set; }

		public GuildHousesInformationMessage(IEnumerable<HouseInformationsForGuild> housesInformations)
		{
			this.housesInformations = housesInformations;
		}

		public GuildHousesInformationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)housesInformations.Count());
			foreach (var objectToSend in housesInformations)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var housesInformationsCount = reader.ReadUShort();
			var housesInformations_ = new HouseInformationsForGuild[housesInformationsCount];
			for (var housesInformationsIndex = 0; housesInformationsIndex < housesInformationsCount; housesInformationsIndex++)
			{
				var objectToAdd = new HouseInformationsForGuild();
				objectToAdd.Deserialize(reader);
				housesInformations_[housesInformationsIndex] = objectToAdd;
			}
			housesInformations = housesInformations_;
		}

	}
}
