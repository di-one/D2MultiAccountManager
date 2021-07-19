namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayPlayerFightFriendlyAnswerMessage : NetworkMessage
	{
		public const uint Id = 3290;
		public override uint MessageId => Id;
		public ushort fightId { get; set; }
		public bool accept { get; set; }

		public GameRolePlayPlayerFightFriendlyAnswerMessage(ushort fightId, bool accept)
		{
			this.fightId = fightId;
			this.accept = accept;
		}

		public GameRolePlayPlayerFightFriendlyAnswerMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(fightId);
			writer.WriteBoolean(accept);
		}

		public override void Deserialize(IDataReader reader)
		{
			fightId = reader.ReadVarUShort();
			accept = reader.ReadBoolean();
		}

	}
}
