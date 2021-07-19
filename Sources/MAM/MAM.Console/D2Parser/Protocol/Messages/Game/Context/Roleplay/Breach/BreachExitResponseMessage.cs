namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BreachExitResponseMessage : NetworkMessage
	{
		public const uint Id = 702;
		public override uint MessageId => Id;
		public bool exited { get; set; }

		public BreachExitResponseMessage(bool exited)
		{
			this.exited = exited;
		}

		public BreachExitResponseMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(exited);
		}

		public override void Deserialize(IDataReader reader)
		{
			exited = reader.ReadBoolean();
		}

	}
}
