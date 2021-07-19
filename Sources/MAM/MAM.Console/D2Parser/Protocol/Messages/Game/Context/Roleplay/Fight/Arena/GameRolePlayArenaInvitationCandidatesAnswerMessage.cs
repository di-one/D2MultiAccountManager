namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayArenaInvitationCandidatesAnswerMessage : NetworkMessage
	{
		public const uint Id = 3563;
		public override uint MessageId => Id;
		public IEnumerable<LeagueFriendInformations> candidates { get; set; }

		public GameRolePlayArenaInvitationCandidatesAnswerMessage(IEnumerable<LeagueFriendInformations> candidates)
		{
			this.candidates = candidates;
		}

		public GameRolePlayArenaInvitationCandidatesAnswerMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)candidates.Count());
			foreach (var objectToSend in candidates)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var candidatesCount = reader.ReadUShort();
			var candidates_ = new LeagueFriendInformations[candidatesCount];
			for (var candidatesIndex = 0; candidatesIndex < candidatesCount; candidatesIndex++)
			{
				var objectToAdd = new LeagueFriendInformations();
				objectToAdd.Deserialize(reader);
				candidates_[candidatesIndex] = objectToAdd;
			}
			candidates = candidates_;
		}

	}
}
