namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BreachRoomUnlockRequestMessage : NetworkMessage
	{
		public const uint Id = 1569;
		public override uint MessageId => Id;
		public sbyte roomId { get; set; }

		public BreachRoomUnlockRequestMessage(sbyte roomId)
		{
			this.roomId = roomId;
		}

		public BreachRoomUnlockRequestMessage() { }

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
