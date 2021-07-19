namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayShowChallengeMessage : NetworkMessage
	{
		public const uint Id = 913;
		public override uint MessageId => Id;
		public FightCommonInformations commonsInfos { get; set; }

		public GameRolePlayShowChallengeMessage(FightCommonInformations commonsInfos)
		{
			this.commonsInfos = commonsInfos;
		}

		public GameRolePlayShowChallengeMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			commonsInfos.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			commonsInfos = new FightCommonInformations();
			commonsInfos.Deserialize(reader);
		}

	}
}
