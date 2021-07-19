namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayNpcWithQuestInformations : GameRolePlayNpcInformations
	{
		public new const short Id = 7842;
		public override short TypeId => Id;
		public GameRolePlayNpcQuestFlag questFlag { get; set; }

		public GameRolePlayNpcWithQuestInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, ushort npcId, bool sex, ushort specialArtworkId, GameRolePlayNpcQuestFlag questFlag)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.npcId = npcId;
			this.sex = sex;
			this.specialArtworkId = specialArtworkId;
			this.questFlag = questFlag;
		}

		public GameRolePlayNpcWithQuestInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			questFlag.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			questFlag = new GameRolePlayNpcQuestFlag();
			questFlag.Deserialize(reader);
		}

	}
}
