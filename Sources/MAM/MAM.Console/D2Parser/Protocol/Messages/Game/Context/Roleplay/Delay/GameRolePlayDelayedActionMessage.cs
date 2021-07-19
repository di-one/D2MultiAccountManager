namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayDelayedActionMessage : NetworkMessage
	{
		public const uint Id = 6;
		public override uint MessageId => Id;
		public double delayedCharacterId { get; set; }
		public sbyte delayTypeId { get; set; }
		public double delayEndTime { get; set; }

		public GameRolePlayDelayedActionMessage(double delayedCharacterId, sbyte delayTypeId, double delayEndTime)
		{
			this.delayedCharacterId = delayedCharacterId;
			this.delayTypeId = delayTypeId;
			this.delayEndTime = delayEndTime;
		}

		public GameRolePlayDelayedActionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(delayedCharacterId);
			writer.WriteSByte(delayTypeId);
			writer.WriteDouble(delayEndTime);
		}

		public override void Deserialize(IDataReader reader)
		{
			delayedCharacterId = reader.ReadDouble();
			delayTypeId = reader.ReadSByte();
			delayEndTime = reader.ReadDouble();
		}

	}
}
