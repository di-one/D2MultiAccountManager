namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BasicWhoAmIRequestMessage : NetworkMessage
	{
		public const uint Id = 2167;
		public override uint MessageId => Id;
		public bool verbose { get; set; }

		public BasicWhoAmIRequestMessage(bool verbose)
		{
			this.verbose = verbose;
		}

		public BasicWhoAmIRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(verbose);
		}

		public override void Deserialize(IDataReader reader)
		{
			verbose = reader.ReadBoolean();
		}

	}
}
