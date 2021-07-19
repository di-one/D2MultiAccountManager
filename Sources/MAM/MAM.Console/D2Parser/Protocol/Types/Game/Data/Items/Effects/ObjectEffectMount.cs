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
	public class ObjectEffectMount : ObjectEffect
	{
		public new const short Id = 5871;
		public override short TypeId => Id;
		public bool sex { get; set; }
		public bool isRideable { get; set; }
		public bool isFeconded { get; set; }
		public bool isFecondationReady { get; set; }
		public ulong objectId { get; set; }
		public ulong expirationDate { get; set; }
		public uint model { get; set; }
		public string name { get; set; }
		public string owner { get; set; }
		public sbyte level { get; set; }
		public int reproductionCount { get; set; }
		public uint reproductionCountMax { get; set; }
		public IEnumerable<ObjectEffectInteger> effects { get; set; }
		public IEnumerable<uint> capacities { get; set; }

		public ObjectEffectMount(ushort actionId, bool sex, bool isRideable, bool isFeconded, bool isFecondationReady, ulong objectId, ulong expirationDate, uint model, string name, string owner, sbyte level, int reproductionCount, uint reproductionCountMax, IEnumerable<ObjectEffectInteger> effects, IEnumerable<uint> capacities)
		{
			this.actionId = actionId;
			this.sex = sex;
			this.isRideable = isRideable;
			this.isFeconded = isFeconded;
			this.isFecondationReady = isFecondationReady;
			this.objectId = objectId;
			this.expirationDate = expirationDate;
			this.model = model;
			this.name = name;
			this.owner = owner;
			this.level = level;
			this.reproductionCount = reproductionCount;
			this.reproductionCountMax = reproductionCountMax;
			this.effects = effects;
			this.capacities = capacities;
		}

		public ObjectEffectMount() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, sex);
			flag = BooleanByteWrapper.SetFlag(flag, 1, isRideable);
			flag = BooleanByteWrapper.SetFlag(flag, 2, isFeconded);
			flag = BooleanByteWrapper.SetFlag(flag, 3, isFecondationReady);
			writer.WriteByte(flag);
			writer.WriteVarULong(objectId);
			writer.WriteVarULong(expirationDate);
			writer.WriteVarUInt(model);
			writer.WriteUTF(name);
			writer.WriteUTF(owner);
			writer.WriteSByte(level);
			writer.WriteVarInt(reproductionCount);
			writer.WriteVarUInt(reproductionCountMax);
			writer.WriteShort((short)effects.Count());
			foreach (var objectToSend in effects)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)capacities.Count());
			foreach (var objectToSend in capacities)
            {
				writer.WriteVarUInt(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var flag = reader.ReadByte();
			sex = BooleanByteWrapper.GetFlag(flag, 0);
			isRideable = BooleanByteWrapper.GetFlag(flag, 1);
			isFeconded = BooleanByteWrapper.GetFlag(flag, 2);
			isFecondationReady = BooleanByteWrapper.GetFlag(flag, 3);
			objectId = reader.ReadVarULong();
			expirationDate = reader.ReadVarULong();
			model = reader.ReadVarUInt();
			name = reader.ReadUTF();
			owner = reader.ReadUTF();
			level = reader.ReadSByte();
			reproductionCount = reader.ReadVarInt();
			reproductionCountMax = reader.ReadVarUInt();
			var effectsCount = reader.ReadUShort();
			var effects_ = new ObjectEffectInteger[effectsCount];
			for (var effectsIndex = 0; effectsIndex < effectsCount; effectsIndex++)
			{
				var objectToAdd = new ObjectEffectInteger();
				objectToAdd.Deserialize(reader);
				effects_[effectsIndex] = objectToAdd;
			}
			effects = effects_;
			var capacitiesCount = reader.ReadUShort();
			var capacities_ = new uint[capacitiesCount];
			for (var capacitiesIndex = 0; capacitiesIndex < capacitiesCount; capacitiesIndex++)
			{
				capacities_[capacitiesIndex] = reader.ReadVarUInt();
			}
			capacities = capacities_;
		}

	}
}
