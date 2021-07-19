namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightFighterEntityLightInformation : GameFightFighterLightInformations
	{
		public new const short Id = 5084;
		public override short TypeId => Id;
		public sbyte entityModelId { get; set; }
		public double masterId { get; set; }

		public GameFightFighterEntityLightInformation(bool sex, bool alive, double objectId, sbyte wave, ushort level, sbyte breed, sbyte entityModelId, double masterId)
		{
			this.sex = sex;
			this.alive = alive;
			this.objectId = objectId;
			this.wave = wave;
			this.level = level;
			this.breed = breed;
			this.entityModelId = entityModelId;
			this.masterId = masterId;
		}

		public GameFightFighterEntityLightInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(entityModelId);
			writer.WriteDouble(masterId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			entityModelId = reader.ReadSByte();
			masterId = reader.ReadDouble();
		}

	}
}
