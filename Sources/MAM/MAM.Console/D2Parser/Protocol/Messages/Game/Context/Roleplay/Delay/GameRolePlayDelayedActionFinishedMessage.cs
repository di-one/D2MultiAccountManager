namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayDelayedActionFinishedMessage : NetworkMessage
	{
		public const uint Id = 8226;
		public override uint MessageId => Id;
		public double delayedCharacterId { get; set; }
		public sbyte delayTypeId { get; set; }

		public GameRolePlayDelayedActionFinishedMessage(double delayedCharacterId, sbyte delayTypeId)
		{
			this.delayedCharacterId = delayedCharacterId;
			this.delayTypeId = delayTypeId;
		}

		public GameRolePlayDelayedActionFinishedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(delayedCharacterId);
			writer.WriteSByte(delayTypeId);
		}

		public override void Deserialize(IDataReader reader)
		{
			delayedCharacterId = reader.ReadDouble();
			delayTypeId = reader.ReadSByte();
		}

	}
}
