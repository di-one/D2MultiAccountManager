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
	public class AllianceVersatileInfoListMessage : NetworkMessage
	{
		public const uint Id = 6958;
		public override uint MessageId => Id;
		public IEnumerable<AllianceVersatileInformations> alliances { get; set; }

		public AllianceVersatileInfoListMessage(IEnumerable<AllianceVersatileInformations> alliances)
		{
			this.alliances = alliances;
		}

		public AllianceVersatileInfoListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)alliances.Count());
			foreach (var objectToSend in alliances)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var alliancesCount = reader.ReadUShort();
			var alliances_ = new AllianceVersatileInformations[alliancesCount];
			for (var alliancesIndex = 0; alliancesIndex < alliancesCount; alliancesIndex++)
			{
				var objectToAdd = new AllianceVersatileInformations();
				objectToAdd.Deserialize(reader);
				alliances_[alliancesIndex] = objectToAdd;
			}
			alliances = alliances_;
		}

	}
}
