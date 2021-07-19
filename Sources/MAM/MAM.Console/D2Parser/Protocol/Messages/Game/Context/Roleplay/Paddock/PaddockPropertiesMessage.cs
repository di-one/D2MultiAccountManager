namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PaddockPropertiesMessage : NetworkMessage
	{
		public const uint Id = 1173;
		public override uint MessageId => Id;
		public PaddockInstancesInformations properties { get; set; }

		public PaddockPropertiesMessage(PaddockInstancesInformations properties)
		{
			this.properties = properties;
		}

		public PaddockPropertiesMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			properties.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			properties = new PaddockInstancesInformations();
			properties.Deserialize(reader);
		}

	}
}
