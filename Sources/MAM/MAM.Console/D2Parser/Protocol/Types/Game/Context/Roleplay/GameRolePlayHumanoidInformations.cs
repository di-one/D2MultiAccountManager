namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayHumanoidInformations : GameRolePlayNamedActorInformations
	{
		public new const short Id = 1484;
		public override short TypeId => Id;
		public HumanInformations humanoidInfo { get; set; }
		public int accountId { get; set; }

		public GameRolePlayHumanoidInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, string name, HumanInformations humanoidInfo, int accountId)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.name = name;
			this.humanoidInfo = humanoidInfo;
			this.accountId = accountId;
		}

		public GameRolePlayHumanoidInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(humanoidInfo.TypeId);
			humanoidInfo.Serialize(writer);
			writer.WriteInt(accountId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			humanoidInfo = ProtocolTypeManager.GetInstance<HumanInformations>(reader.ReadShort());
			humanoidInfo.Deserialize(reader);
			accountId = reader.ReadInt();
		}

	}
}
