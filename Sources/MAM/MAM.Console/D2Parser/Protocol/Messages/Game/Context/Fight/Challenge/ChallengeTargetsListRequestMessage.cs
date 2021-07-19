namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChallengeTargetsListRequestMessage : NetworkMessage
	{
		public const uint Id = 1589;
		public override uint MessageId => Id;
		public ushort challengeId { get; set; }

		public ChallengeTargetsListRequestMessage(ushort challengeId)
		{
			this.challengeId = challengeId;
		}

		public ChallengeTargetsListRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(challengeId);
		}

		public override void Deserialize(IDataReader reader)
		{
			challengeId = reader.ReadVarUShort();
		}

	}
}
