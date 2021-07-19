namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayCharacterInformations : GameRolePlayHumanoidInformations
	{
		public new const short Id = 8148;
		public override short TypeId => Id;
		public ActorAlignmentInformations alignmentInfos { get; set; }

		public GameRolePlayCharacterInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, string name, HumanInformations humanoidInfo, int accountId, ActorAlignmentInformations alignmentInfos)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.name = name;
			this.humanoidInfo = humanoidInfo;
			this.accountId = accountId;
			this.alignmentInfos = alignmentInfos;
		}

		public GameRolePlayCharacterInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			alignmentInfos.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			alignmentInfos = new ActorAlignmentInformations();
			alignmentInfos.Deserialize(reader);
		}

	}
}
