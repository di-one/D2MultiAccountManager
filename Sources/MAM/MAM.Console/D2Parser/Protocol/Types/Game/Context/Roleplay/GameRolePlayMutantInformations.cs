namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayMutantInformations : GameRolePlayHumanoidInformations
	{
		public new const short Id = 5654;
		public override short TypeId => Id;
		public ushort monsterId { get; set; }
		public sbyte powerLevel { get; set; }

		public GameRolePlayMutantInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, string name, HumanInformations humanoidInfo, int accountId, ushort monsterId, sbyte powerLevel)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.name = name;
			this.humanoidInfo = humanoidInfo;
			this.accountId = accountId;
			this.monsterId = monsterId;
			this.powerLevel = powerLevel;
		}

		public GameRolePlayMutantInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(monsterId);
			writer.WriteSByte(powerLevel);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			monsterId = reader.ReadVarUShort();
			powerLevel = reader.ReadSByte();
		}

	}
}
