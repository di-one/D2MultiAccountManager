namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BasicPongMessage : NetworkMessage
	{
		public const uint Id = 8578;
		public override uint MessageId => Id;
		public bool quiet { get; set; }

		public BasicPongMessage(bool quiet)
		{
			this.quiet = quiet;
		}

		public BasicPongMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(quiet);
		}

		public override void Deserialize(IDataReader reader)
		{
			quiet = reader.ReadBoolean();
		}

	}
}
