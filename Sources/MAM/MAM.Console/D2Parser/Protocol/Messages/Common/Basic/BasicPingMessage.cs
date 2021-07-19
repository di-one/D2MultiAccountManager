namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BasicPingMessage : NetworkMessage
	{
		public const uint Id = 154;
		public override uint MessageId => Id;
		public bool quiet { get; set; }

		public BasicPingMessage(bool quiet)
		{
			this.quiet = quiet;
		}

		public BasicPingMessage() { }

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
