namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class OrnamentSelectRequestMessage : NetworkMessage
	{
		public const uint Id = 5696;
		public override uint MessageId => Id;
		public ushort ornamentId { get; set; }

		public OrnamentSelectRequestMessage(ushort ornamentId)
		{
			this.ornamentId = ornamentId;
		}

		public OrnamentSelectRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(ornamentId);
		}

		public override void Deserialize(IDataReader reader)
		{
			ornamentId = reader.ReadVarUShort();
		}

	}
}
