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
	public class CharacterCharacteristicsInformations
	{
		public const short Id  = 8937;
		public virtual short TypeId => Id;
		public ulong experience { get; set; }
		public ulong experienceLevelFloor { get; set; }
		public ulong experienceNextLevelFloor { get; set; }
		public ulong experienceBonusLimit { get; set; }
		public ulong kamas { get; set; }
		public ActorExtendedAlignmentInformations alignmentInfos { get; set; }
		public ushort criticalHitWeapon { get; set; }
		public IEnumerable<CharacterCharacteristic> characteristics { get; set; }
		public IEnumerable<CharacterSpellModification> spellModifications { get; set; }
		public int probationTime { get; set; }

		public CharacterCharacteristicsInformations(ulong experience, ulong experienceLevelFloor, ulong experienceNextLevelFloor, ulong experienceBonusLimit, ulong kamas, ActorExtendedAlignmentInformations alignmentInfos, ushort criticalHitWeapon, IEnumerable<CharacterCharacteristic> characteristics, IEnumerable<CharacterSpellModification> spellModifications, int probationTime)
		{
			this.experience = experience;
			this.experienceLevelFloor = experienceLevelFloor;
			this.experienceNextLevelFloor = experienceNextLevelFloor;
			this.experienceBonusLimit = experienceBonusLimit;
			this.kamas = kamas;
			this.alignmentInfos = alignmentInfos;
			this.criticalHitWeapon = criticalHitWeapon;
			this.characteristics = characteristics;
			this.spellModifications = spellModifications;
			this.probationTime = probationTime;
		}

		public CharacterCharacteristicsInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(experience);
			writer.WriteVarULong(experienceLevelFloor);
			writer.WriteVarULong(experienceNextLevelFloor);
			writer.WriteVarULong(experienceBonusLimit);
			writer.WriteVarULong(kamas);
			alignmentInfos.Serialize(writer);
			writer.WriteVarUShort(criticalHitWeapon);
			writer.WriteShort((short)characteristics.Count());
			foreach (var objectToSend in characteristics)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)spellModifications.Count());
			foreach (var objectToSend in spellModifications)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteInt(probationTime);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			experience = reader.ReadVarULong();
			experienceLevelFloor = reader.ReadVarULong();
			experienceNextLevelFloor = reader.ReadVarULong();
			experienceBonusLimit = reader.ReadVarULong();
			kamas = reader.ReadVarULong();
			alignmentInfos = new ActorExtendedAlignmentInformations();
			alignmentInfos.Deserialize(reader);
			criticalHitWeapon = reader.ReadVarUShort();
			var characteristicsCount = reader.ReadUShort();
			var characteristics_ = new CharacterCharacteristic[characteristicsCount];
			for (var characteristicsIndex = 0; characteristicsIndex < characteristicsCount; characteristicsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<CharacterCharacteristic>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				characteristics_[characteristicsIndex] = objectToAdd;
			}
			characteristics = characteristics_;
			var spellModificationsCount = reader.ReadUShort();
			var spellModifications_ = new CharacterSpellModification[spellModificationsCount];
			for (var spellModificationsIndex = 0; spellModificationsIndex < spellModificationsCount; spellModificationsIndex++)
			{
				var objectToAdd = new CharacterSpellModification();
				objectToAdd.Deserialize(reader);
				spellModifications_[spellModificationsIndex] = objectToAdd;
			}
			spellModifications = spellModifications_;
			probationTime = reader.ReadInt();
		}

	}
}
