namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class OrnamentLostMessage : NetworkMessage
	{
		public const uint Id = 7044;
		public override uint MessageId => Id;
		public short ornamentId { get; set; }

		public OrnamentLostMessage(short ornamentId)
		{
			this.ornamentId = ornamentId;
		}

		public OrnamentLostMessage() { }

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
