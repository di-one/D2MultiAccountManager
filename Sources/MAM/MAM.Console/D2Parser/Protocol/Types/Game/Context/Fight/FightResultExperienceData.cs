namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightResultExperienceData : FightResultAdditionalData
	{
		public new const short Id = 9775;
		public override short TypeId => Id;
		public bool showExperience { get; set; }
		public bool showExperienceLevelFloor { get; set; }
		public bool showExperienceNextLevelFloor { get; set; }
		public bool showExperienceFightDelta { get; set; }
		public bool showExperienceForGuild { get; set; }
		public bool showExperienceForMount { get; set; }
		public bool isIncarnationExperience { get; set; }
		public ulong experience { get; set; }
		public ulong experienceLevelFloor { get; set; }
		public ulong experienceNextLevelFloor { get; set; }
		public ulong experienceFightDelta { get; set; }
		public ulong experienceForGuild { get; set; }
		public ulong experienceForMount { get; set; }
		public sbyte rerollExperienceMul { get; set; }

		public FightResultExperienceData(bool showExperience, bool showExperienceLevelFloor, bool showExperienceNextLevelFloor, bool showExperienceFightDelta, bool showExperienceForGuild, bool showExperienceForMount, bool isIncarnationExperience, ulong experience, ulong experienceLevelFloor, ulong experienceNextLevelFloor, ulong experienceFightDelta, ulong experienceForGuild, ulong experienceForMount, sbyte rerollExperienceMul)
		{
			this.showExperience = showExperience;
			this.showExperienceLevelFloor = showExperienceLevelFloor;
			this.showExperienceNextLevelFloor = showExperienceNextLevelFloor;
			this.showExperienceFightDelta = showExperienceFightDelta;
			this.showExperienceForGuild = showExperienceForGuild;
			this.showExperienceForMount = showExperienceForMount;
			this.isIncarnationExperience = isIncarnationExperience;
			this.experience = experience;
			this.experienceLevelFloor = experienceLevelFloor;
			this.experienceNextLevelFloor = experienceNextLevelFloor;
			this.experienceFightDelta = experienceFightDelta;
			this.experienceForGuild = experienceForGuild;
			this.experienceForMount = experienceForMount;
			this.rerollExperienceMul = rerollExperienceMul;
		}

		public FightResultExperienceData() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, showExperience);
			flag = BooleanByteWrapper.SetFlag(flag, 1, showExperienceLevelFloor);
			flag = BooleanByteWrapper.SetFlag(flag, 2, showExperienceNextLevelFloor);
			flag = BooleanByteWrapper.SetFlag(flag, 3, showExperienceFightDelta);
			flag = BooleanByteWrapper.SetFlag(flag, 4, showExperienceForGuild);
			flag = BooleanByteWrapper.SetFlag(flag, 5, showExperienceForMount);
			flag = BooleanByteWrapper.SetFlag(flag, 6, isIncarnationExperience);
			writer.WriteByte(flag);
			writer.WriteVarULong(experience);
			writer.WriteVarULong(experienceLevelFloor);
			writer.WriteVarULong(experienceNextLevelFloor);
			writer.WriteVarULong(experienceFightDelta);
			writer.WriteVarULong(experienceForGuild);
			writer.WriteVarULong(experienceForMount);
			writer.WriteSByte(rerollExperienceMul);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var flag = reader.ReadByte();
			showExperience = BooleanByteWrapper.GetFlag(flag, 0);
			showExperienceLevelFloor = BooleanByteWrapper.GetFlag(flag, 1);
			showExperienceNextLevelFloor = BooleanByteWrapper.GetFlag(flag, 2);
			showExperienceFightDelta = BooleanByteWrapper.GetFlag(flag, 3);
			showExperienceForGuild = BooleanByteWrapper.GetFlag(flag, 4);
			showExperienceForMount = BooleanByteWrapper.GetFlag(flag, 5);
			isIncarnationExperience = BooleanByteWrapper.GetFlag(flag, 6);
			experience = reader.ReadVarULong();
			experienceLevelFloor = reader.ReadVarULong();
			experienceNextLevelFloor = reader.ReadVarULong();
			experienceFightDelta = reader.ReadVarULong();
			experienceForGuild = reader.ReadVarULong();
			experienceForMount = reader.ReadVarULong();
			rerollExperienceMul = reader.ReadSByte();
		}

	}
}
