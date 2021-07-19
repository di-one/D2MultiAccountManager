namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class OrnamentGainedMessage : NetworkMessage
	{
		public const uint Id = 1986;
		public override uint MessageId => Id;
		public short ornamentId { get; set; }

		public OrnamentGainedMessage(short ornamentId)
		{
			this.ornamentId = ornamentId;
		}

		public OrnamentGainedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(ornamentId);
		}

		public override void Deserialize(IDataReader reader)
		{
			ornamentId = reader.ReadShort();
		}

	}
}
