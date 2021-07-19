namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayGroupMonsterWaveInformations : GameRolePlayGroupMonsterInformations
	{
		public new const short Id = 5020;
		public override short TypeId => Id;
		public sbyte nbWaves { get; set; }
		public IEnumerable<GroupMonsterStaticInformations> alternatives { get; set; }

		public GameRolePlayGroupMonsterWaveInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, bool keyRingBonus, bool hasHardcoreDrop, bool hasAVARewardToken, GroupMonsterStaticInformations staticInfos, sbyte lootShare, sbyte alignmentSide, sbyte nbWaves, IEnumerable<GroupMonsterStaticInformations> alternatives)
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
			this.nbWaves = nbWaves;
			this.alternatives = alternatives;
		}

		public GameRolePlayGroupMonsterWaveInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(nbWaves);
			writer.WriteShort((short)alternatives.Count());
			foreach (var objectToSend in alternatives)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			nbWaves = reader.ReadSByte();
			var alternativesCount = reader.ReadUShort();
			var alternatives_ = new GroupMonsterStaticInformations[alternativesCount];
			for (var alternativesIndex = 0; alternativesIndex < alternativesCount; alternativesIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<GroupMonsterStaticInformations>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				alternatives_[alternativesIndex] = objectToAdd;
			}
			alternatives = alternatives_;
		}

	}
}
