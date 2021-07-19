namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightFighterMonsterLightInformations : GameFightFighterLightInformations
	{
		public new const short Id = 7050;
		public override short TypeId => Id;
		public ushort creatureGenericId { get; set; }

		public GameFightFighterMonsterLightInformations(bool sex, bool alive, double objectId, sbyte wave, ushort level, sbyte breed, ushort creatureGenericId)
		{
			this.sex = sex;
			this.alive = alive;
			this.objectId = objectId;
			this.wave = wave;
			this.level = level;
			this.breed = breed;
			this.creatureGenericId = creatureGenericId;
		}

		public GameFightFighterMonsterLightInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(creatureGenericId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			creatureGenericId = reader.ReadVarUShort();
		}

	}
}
