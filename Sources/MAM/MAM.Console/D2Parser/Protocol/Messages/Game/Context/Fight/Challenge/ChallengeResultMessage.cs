namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChallengeResultMessage : NetworkMessage
	{
		public const uint Id = 2828;
		public override uint MessageId => Id;
		public ushort challengeId { get; set; }
		public bool success { get; set; }

		public ChallengeResultMessage(ushort challengeId, bool success)
		{
			this.challengeId = challengeId;
			this.success = success;
		}

		public ChallengeResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(challengeId);
			writer.WriteBoolean(success);
		}

		public override void Deserialize(IDataReader reader)
		{
			challengeId = reader.ReadVarUShort();
			success = reader.ReadBoolean();
		}

	}
}
