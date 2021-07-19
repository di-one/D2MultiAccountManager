namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectGroundRemovedMessage : NetworkMessage
	{
		public const uint Id = 574;
		public override uint MessageId => Id;
		public ushort cell { get; set; }

		public ObjectGroundRemovedMessage(ushort cell)
		{
			this.cell = cell;
		}

		public ObjectGroundRemovedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(cell);
		}

		public override void Deserialize(IDataReader reader)
		{
			cell = reader.ReadVarUShort();
		}

	}
}
