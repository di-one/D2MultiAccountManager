namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightStartingMessage : NetworkMessage
	{
		public const uint Id = 7976;
		public override uint MessageId => Id;
		public sbyte fightType { get; set; }
		public ushort fightId { get; set; }
		public double attackerId { get; set; }
		public double defenderId { get; set; }
		public bool containsBoss { get; set; }

		public GameFightStartingMessage(sbyte fightType, ushort fightId, double attackerId, double defenderId, bool containsBoss)
		{
			this.fightType = fightType;
			this.fightId = fightId;
			this.attackerId = attackerId;
			this.defenderId = defenderId;
			this.containsBoss = containsBoss;
		}

		public GameFightStartingMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(fightType);
			writer.WriteVarUShort(fightId);
			writer.WriteDouble(attackerId);
			writer.WriteDouble(defenderId);
			writer.WriteBoolean(containsBoss);
		}

		public override void Deserialize(IDataReader reader)
		{
			fightType = reader.ReadSByte();
			fightId = reader.ReadVarUShort();
			attackerId = reader.ReadDouble();
			defenderId = reader.ReadDouble();
			containsBoss = reader.ReadBoolean();
		}

	}
}
