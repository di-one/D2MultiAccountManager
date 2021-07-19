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
	public class MountClientData
	{
		public const short Id  = 3763;
		public virtual short TypeId => Id;
		public bool sex { get; set; }
		public bool isRideable { get; set; }
		public bool isWild { get; set; }
		public bool isFecondationReady { get; set; }
		public bool useHarnessColors { get; set; }
		public double objectId { get; set; }
		public uint model { get; set; }
		public IEnumerable<int> ancestor { get; set; }
		public IEnumerable<int> behaviors { get; set; }
		public string name { get; set; }
		public int ownerId { get; set; }
		public ulong experience { get; set; }
		public ulong experienceForLevel { get; set; }
		public double experienceForNextLevel { get; set; }
		public sbyte level { get; set; }
		public uint maxPods { get; set; }
		public uint stamina { get; set; }
		public uint staminaMax { get; set; }
		public uint maturity { get; set; }
		public uint maturityForAdult { get; set; }
		public uint energy { get; set; }
		public uint energyMax { get; set; }
		public int serenity { get; set; }
		public int aggressivityMax { get; set; }
		public uint serenityMax { get; set; }
		public uint love { get; set; }
		public uint loveMax { get; set; }
		public int fecondationTime { get; set; }
		public int boostLimiter { get; set; }
		public double boostMax { get; set; }
		public int reproductionCount { get; set; }
		public uint reproductionCountMax { get; set; }
		public ushort harnessGID { get; set; }
		public IEnumerable<ObjectEffectInteger> effectList { get; set; }

		public MountClientData(bool sex, bool isRideable, bool isWild, bool isFecondationReady, bool useHarnessColors, double objectId, uint model, IEnumerable<int> ancestor, IEnumerable<int> behaviors, string name, int ownerId, ulong experience, ulong experienceForLevel, double experienceForNextLevel, sbyte level, uint maxPods, uint stamina, uint staminaMax, uint maturity, uint maturityForAdult, uint energy, uint energyMax, int serenity, int aggressivityMax, uint serenityMax, uint love, uint loveMax, int fecondationTime, int boostLimiter, double boostMax, int reproductionCount, uint reproductionCountMax, ushort harnessGID, IEnumerable<ObjectEffectInteger> effectList)
		{
			this.sex = sex;
			this.isRideable = isRideable;
			this.isWild = isWild;
			this.isFecondationReady = isFecondationReady;
			this.useHarnessColors = useHarnessColors;
			this.objectId = objectId;
			this.model = model;
			this.ancestor = ancestor;
			this.behaviors = behaviors;
			this.name = name;
			this.ownerId = ownerId;
			this.experience = experience;
			this.experienceForLevel = experienceForLevel;
			this.experienceForNextLevel = experienceForNextLevel;
			this.level = level;
			this.maxPods = maxPods;
			this.stamina = stamina;
			this.staminaMax = staminaMax;
			this.maturity = maturity;
			this.maturityForAdult = maturityForAdult;
			this.energy = energy;
			this.energyMax = energyMax;
			this.serenity = serenity;
			this.aggressivityMax = aggressivityMax;
			this.serenityMax = serenityMax;
			this.love = love;
			this.loveMax = loveMax;
			this.fecondationTime = fecondationTime;
			this.boostLimiter = boostLimiter;
			this.boostMax = boostMax;
			this.reproductionCount = reproductionCount;
			this.reproductionCountMax = reproductionCountMax;
			this.harnessGID = harnessGID;
			this.effectList = effectList;
		}

		public MountClientData() { }

		public virtual void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, sex);
			flag = BooleanByteWrapper.SetFlag(flag, 1, isRideable);
			flag = BooleanByteWrapper.SetFlag(flag, 2, isWild);
			flag = BooleanByteWrapper.SetFlag(flag, 3, isFecondationReady);
			flag = BooleanByteWrapper.SetFlag(flag, 4, useHarnessColors);
			writer.WriteByte(flag);
			writer.WriteDouble(objectId);
			writer.WriteVarUInt(model);
			writer.WriteShort((short)ancestor.Count());
			foreach (var objectToSend in ancestor)
            {
				writer.WriteInt(objectToSend);
			}
			writer.WriteShort((short)behaviors.Count());
			foreach (var objectToSend in behaviors)
            {
				writer.WriteInt(objectToSend);
			}
			writer.WriteUTF(name);
			writer.WriteInt(ownerId);
			writer.WriteVarULong(experience);
			writer.WriteVarULong(experienceForLevel);
			writer.WriteDouble(experienceForNextLevel);
			writer.WriteSByte(level);
			writer.WriteVarUInt(maxPods);
			writer.WriteVarUInt(stamina);
			writer.WriteVarUInt(staminaMax);
			writer.WriteVarUInt(maturity);
			writer.WriteVarUInt(maturityForAdult);
			writer.WriteVarUInt(energy);
			writer.WriteVarUInt(energyMax);
			writer.WriteInt(serenity);
			writer.WriteInt(aggressivityMax);
			writer.WriteVarUInt(serenityMax);
			writer.WriteVarUInt(love);
			writer.WriteVarUInt(loveMax);
			writer.WriteInt(fecondationTime);
			writer.WriteInt(boostLimiter);
			writer.WriteDouble(boostMax);
			writer.WriteInt(reproductionCount);
			writer.WriteVarUInt(reproductionCountMax);
			writer.WriteVarUShort(harnessGID);
			writer.WriteShort((short)effectList.Count());
			foreach (var objectToSend in effectList)
            {
				objectToSend.Serialize(writer);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			sex = BooleanByteWrapper.GetFlag(flag, 0);
			isRideable = BooleanByteWrapper.GetFlag(flag, 1);
			isWild = BooleanByteWrapper.GetFlag(flag, 2);
			isFecondationReady = BooleanByteWrapper.GetFlag(flag, 3);
			useHarnessColors = BooleanByteWrapper.GetFlag(flag, 4);
			objectId = reader.ReadDouble();
			model = reader.ReadVarUInt();
			var ancestorCount = reader.ReadUShort();
			var ancestor_ = new int[ancestorCount];
			for (var ancestorIndex = 0; ancestorIndex < ancestorCount; ancestorIndex++)
			{
				ancestor_[ancestorIndex] = reader.ReadInt();
			}
			ancestor = ancestor_;
			var behaviorsCount = reader.ReadUShort();
			var behaviors_ = new int[behaviorsCount];
			for (var behaviorsIndex = 0; behaviorsIndex < behaviorsCount; behaviorsIndex++)
			{
				behaviors_[behaviorsIndex] = reader.ReadInt();
			}
			behaviors = behaviors_;
			name = reader.ReadUTF();
			ownerId = reader.ReadInt();
			experience = reader.ReadVarULong();
			experienceForLevel = reader.ReadVarULong();
			experienceForNextLevel = reader.ReadDouble();
			level = reader.ReadSByte();
			maxPods = reader.ReadVarUInt();
			stamina = reader.ReadVarUInt();
			staminaMax = reader.ReadVarUInt();
			maturity = reader.ReadVarUInt();
			maturityForAdult = reader.ReadVarUInt();
			energy = reader.ReadVarUInt();
			energyMax = reader.ReadVarUInt();
			serenity = reader.ReadInt();
			aggressivityMax = reader.ReadInt();
			serenityMax = reader.ReadVarUInt();
			love = reader.ReadVarUInt();
			loveMax = reader.ReadVarUInt();
			fecondationTime = reader.ReadInt();
			boostLimiter = reader.ReadInt();
			boostMax = reader.ReadDouble();
			reproductionCount = reader.ReadInt();
			reproductionCountMax = reader.ReadVarUInt();
			harnessGID = reader.ReadVarUShort();
			var effectListCount = reader.ReadUShort();
			var effectList_ = new ObjectEffectInteger[effectListCount];
			for (var effectListIndex = 0; effectListIndex < effectListCount; effectListIndex++)
			{
				var objectToAdd = new ObjectEffectInteger();
				objectToAdd.Deserialize(reader);
				effectList_[effectListIndex] = objectToAdd;
			}
			effectList = effectList_;
		}

	}
}
