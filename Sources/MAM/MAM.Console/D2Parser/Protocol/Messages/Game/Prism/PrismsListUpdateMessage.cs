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
	public class PrismsListUpdateMessage : PrismsListMessage
	{
		public new const uint Id = 101;
		public override uint MessageId => Id;

		public PrismsListUpdateMessage(IEnumerable<PrismSubareaEmptyInfo> prisms)
		{
			this.prisms = prisms;
		}

		public PrismsListUpdateMessage() { }

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
