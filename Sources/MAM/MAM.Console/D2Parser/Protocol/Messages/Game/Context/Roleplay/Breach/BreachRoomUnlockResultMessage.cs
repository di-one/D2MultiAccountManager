namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BreachRoomUnlockResultMessage : NetworkMessage
	{
		public const uint Id = 485;
		public override uint MessageId => Id;
		public sbyte roomId { get; set; }
		public sbyte result { get; set; }

		public BreachRoomUnlockResultMessage(sbyte roomId, sbyte result)
		{
			this.roomId = roomId;
			this.result = result;
		}

		public BreachRoomUnlockResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(roomId);
			writer.WriteSByte(result);
		}

		public override void Deserialize(IDataReader reader)
		{
			roomId = reader.ReadSByte();
			result = reader.ReadSByte();
		}

	}
}
