namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChangeHavenBagRoomRequestMessage : NetworkMessage
	{
		public const uint Id = 3960;
		public override uint MessageId => Id;
		public sbyte roomId { get; set; }

		public ChangeHavenBagRoomRequestMessage(sbyte roomId)
		{
			this.roomId = roomId;
		}

		public ChangeHavenBagRoomRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(roomId);
		}

		public override void Deserialize(IDataReader reader)
		{
			roomId = reader.ReadSByte();
		}

	}
}
