namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChallengeTargetUpdateMessage : NetworkMessage
	{
		public const uint Id = 8121;
		public override uint MessageId => Id;
		public ushort challengeId { get; set; }
		public double targetId { get; set; }

		public ChallengeTargetUpdateMessage(ushort challengeId, double targetId)
		{
			this.challengeId = challengeId;
			this.targetId = targetId;
		}

		public ChallengeTargetUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(challengeId);
			writer.WriteDouble(targetId);
		}

		public override void Deserialize(IDataReader reader)
		{
			challengeId = reader.ReadVarUShort();
			targetId = reader.ReadDouble();
		}

	}
}
