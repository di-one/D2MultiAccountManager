namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BreachSavedMessage : NetworkMessage
	{
		public const uint Id = 745;
		public override uint MessageId => Id;
		public bool saved { get; set; }

		public BreachSavedMessage(bool saved)
		{
			this.saved = saved;
		}

		public BreachSavedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(saved);
		}

		public override void Deserialize(IDataReader reader)
		{
			saved = reader.ReadBoolean();
		}

	}
}
