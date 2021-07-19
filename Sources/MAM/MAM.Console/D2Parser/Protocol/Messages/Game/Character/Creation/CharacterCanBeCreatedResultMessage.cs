namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterCanBeCreatedResultMessage : NetworkMessage
	{
		public const uint Id = 9745;
		public override uint MessageId => Id;
		public bool yesYouCan { get; set; }

		public CharacterCanBeCreatedResultMessage(bool yesYouCan)
		{
			this.yesYouCan = yesYouCan;
		}

		public CharacterCanBeCreatedResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(yesYouCan);
		}

		public override void Deserialize(IDataReader reader)
		{
			yesYouCan = reader.ReadBoolean();
		}

	}
}
