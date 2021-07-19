namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AtlasPointInformationsMessage : NetworkMessage
	{
		public const uint Id = 9787;
		public override uint MessageId => Id;
		public AtlasPointsInformations type { get; set; }

		public AtlasPointInformationsMessage(AtlasPointsInformations type)
		{
			this.type = type;
		}

		public AtlasPointInformationsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			type.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			type = new AtlasPointsInformations();
			type.Deserialize(reader);
		}

	}
}
