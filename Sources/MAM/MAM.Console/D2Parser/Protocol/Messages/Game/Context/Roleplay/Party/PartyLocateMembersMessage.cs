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
	public class PartyLocateMembersMessage : AbstractPartyMessage
	{
		public new const uint Id = 5421;
		public override uint MessageId => Id;
		public IEnumerable<PartyMemberGeoPosition> geopositions { get; set; }

		public PartyLocateMembersMessage(uint partyId, IEnumerable<PartyMemberGeoPosition> geopositions)
		{
			this.partyId = partyId;
			this.geopositions = geopositions;
		}

		public PartyLocateMembersMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)geopositions.Count());
			foreach (var objectToSend in geopositions)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var geopositionsCount = reader.ReadUShort();
			var geopositions_ = new PartyMemberGeoPosition[geopositionsCount];
			for (var geopositionsIndex = 0; geopositionsIndex < geopositionsCount; geopositionsIndex++)
			{
				var objectToAdd = new PartyMemberGeoPosition();
				objectToAdd.Deserialize(reader);
				geopositions_[geopositionsIndex] = objectToAdd;
			}
			geopositions = geopositions_;
		}

	}
}
