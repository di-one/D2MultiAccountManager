namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChallengeInfoMessage : NetworkMessage
	{
		public const uint Id = 3238;
		public override uint MessageId => Id;
		public ushort challengeId { get; set; }
		public double targetId { get; set; }
		public uint xpBonus { get; set; }
		public uint dropBonus { get; set; }

		public ChallengeInfoMessage(ushort challengeId, double targetId, uint xpBonus, uint dropBonus)
		{
			this.challengeId = challengeId;
			this.targetId = targetId;
			this.xpBonus = xpBonus;
			this.dropBonus = dropBonus;
		}

		public ChallengeInfoMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(challengeId);
			writer.WriteDouble(targetId);
			writer.WriteVarUInt(xpBonus);
			writer.WriteVarUInt(dropBonus);
		}

		public override void Deserialize(IDataReader reader)
		{
			challengeId = reader.ReadVarUShort();
			targetId = reader.ReadDouble();
			xpBonus = reader.ReadVarUInt();
			dropBonus = reader.ReadVarUInt();
		}

	}
}
