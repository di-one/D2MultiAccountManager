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
	public class AlliancePartialListMessage : AllianceListMessage
	{
		public new const uint Id = 1670;
		public override uint MessageId => Id;

		public AlliancePartialListMessage(IEnumerable<AllianceFactSheetInformations> alliances)
		{
			this.alliances = alliances;
		}

		public AlliancePartialListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
		}

	}
}
