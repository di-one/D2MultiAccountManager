namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightFighterLightInformations
	{
		public const short Id  = 1156;
		public virtual short TypeId => Id;
		public bool sex { get; set; }
		public bool alive { get; set; }
		public double objectId { get; set; }
		public sbyte wave { get; set; }
		public ushort level { get; set; }
		public sbyte breed { get; set; }

		public GameFightFighterLightInformations(bool sex, bool alive, double objectId, sbyte wave, ushort level, sbyte breed)
		{
			this.sex = sex;
			this.alive = alive;
			this.objectId = objectId;
			this.wave = wave;
			this.level = level;
			this.breed = breed;
		}

		public GameFightFighterLightInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, sex);
			flag = BooleanByteWrapper.SetFlag(flag, 1, alive);
			writer.WriteByte(flag);
			writer.WriteDouble(objectId);
			writer.WriteSByte(wave);
			writer.WriteVarUShort(level);
			writer.WriteSByte(breed);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			sex = BooleanByteWrapper.GetFlag(flag, 0);
			alive = BooleanByteWrapper.GetFlag(flag, 1);
			objectId = reader.ReadDouble();
			wave = reader.ReadSByte();
			level = reader.ReadVarUShort();
			breed = reader.ReadSByte();
		}

	}
}
