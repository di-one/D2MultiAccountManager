namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class LoginQueueStatusMessage : NetworkMessage
	{
		public const uint Id = 2553;
		public override uint MessageId => Id;
		public ushort position { get; set; }
		public ushort total { get; set; }

		public LoginQueueStatusMessage(ushort position, ushort total)
		{
			this.position = position;
			this.total = total;
		}

		public LoginQueueStatusMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUShort(position);
			writer.WriteUShort(total);
		}

		public override void Deserialize(IDataReader reader)
		{
			position = reader.ReadUShort();
			total = reader.ReadUShort();
		}

	}
}
