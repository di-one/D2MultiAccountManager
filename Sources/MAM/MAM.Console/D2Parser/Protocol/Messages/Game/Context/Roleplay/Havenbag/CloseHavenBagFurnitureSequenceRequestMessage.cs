namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CloseHavenBagFurnitureSequenceRequestMessage : NetworkMessage
	{
		public const uint Id = 5763;
		public override uint MessageId => Id;

		public CloseHavenBagFurnitureSequenceRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
		}

		public override void Deserialize(IDataReader reader)
		{
		}

	}
}
