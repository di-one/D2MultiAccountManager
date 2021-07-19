namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayRemoveChallengeMessage : NetworkMessage
	{
		public const uint Id = 7713;
		public override uint MessageId => Id;
		public ushort fightId { get; set; }

		public GameRolePlayRemoveChallengeMessage(ushort fightId)
		{
			this.fightId = fightId;
		}

		public GameRolePlayRemoveChallengeMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(fightId);
		}

		public override void Deserialize(IDataReader reader)
		{
			fightId = reader.ReadVarUShort();
		}

	}
}
