namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TeleportHavenBagAnswerMessage : NetworkMessage
	{
		public const uint Id = 5956;
		public override uint MessageId => Id;
		public bool accept { get; set; }

		public TeleportHavenBagAnswerMessage(bool accept)
		{
			this.accept = accept;
		}

		public TeleportHavenBagAnswerMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(accept);
		}

		public override void Deserialize(IDataReader reader)
		{
			accept = reader.ReadBoolean();
		}

	}
}
