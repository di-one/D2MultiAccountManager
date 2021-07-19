namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayGroupMonsterInformations : GameRolePlayActorInformations
	{
		public new const short Id = 475;
		public override short TypeId => Id;
		public bool keyRingBonus { get; set; }
		public bool hasHardcoreDrop { get; set; }
		public bool hasAVARewardToken { get; set; }
		public GroupMonsterStaticInformations staticInfos { get; set; }
		public sbyte lootShare { get; set; }
		public sbyte alignmentSide { get; set; }

		public GameRolePlayGroupMonsterInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, bool keyRingBonus, bool hasHardcoreDrop, bool hasAVARewardToken, GroupMonsterStaticInformations staticInfos, sbyte lootShare, sbyte alignmentSide)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.keyRingBonus = keyRingBonus;
			this.hasHardcoreDrop = hasHardcoreDrop;
			this.hasAVARewardToken = hasAVARewardToken;
			this.staticInfos = staticInfos;
			this.lootShare = lootShare;
			this.alignmentSide = alignmentSide;
		}

		public GameRolePlayGroupMonsterInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, keyRingBonus);
			flag = BooleanByteWrapper.SetFlag(flag, 1, hasHardcoreDrop);
			flag = BooleanByteWrapper.SetFlag(flag, 2, hasAVARewardToken);
			writer.WriteByte(flag);
			writer.WriteShort(staticInfos.TypeId);
			staticInfos.Serialize(writer);
			writer.WriteSByte(lootShare);
			writer.WriteSByte(alignmentSide);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var flag = reader.ReadByte();
			keyRingBonus = BooleanByteWrapper.GetFlag(flag, 0);
			hasHardcoreDrop = BooleanByteWrapper.GetFlag(flag, 1);
			hasAVARewardToken = BooleanByteWrapper.GetFlag(flag, 2);
			staticInfos = ProtocolTypeManager.GetInstance<GroupMonsterStaticInformations>(reader.ReadShort());
			staticInfos.Deserialize(reader);
			lootShare = reader.ReadSByte();
			alignmentSide = reader.ReadSByte();
		}

	}
}
