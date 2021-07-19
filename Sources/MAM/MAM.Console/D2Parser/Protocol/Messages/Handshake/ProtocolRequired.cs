namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ProtocolRequired : NetworkMessage
	{
		public const uint Id = 9546;
		public override uint MessageId => Id;
		public string version { get; set; }

		public ProtocolRequired(string version)
		{
			this.version = version;
		}

		public ProtocolRequired() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(version);
		}

		public override void Deserialize(IDataReader reader)
		{
			version = reader.ReadUTF();
		}

	}
}
