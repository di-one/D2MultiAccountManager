namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SpouseStatusMessage : NetworkMessage
	{
		public const uint Id = 7078;
		public override uint MessageId => Id;
		public bool hasSpouse { get; set; }

		public SpouseStatusMessage(bool hasSpouse)
		{
			this.hasSpouse = hasSpouse;
		}

		public SpouseStatusMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(hasSpouse);
		}

		public override void Deserialize(IDataReader reader)
		{
			hasSpouse = reader.ReadBoolean();
		}

	}
}
