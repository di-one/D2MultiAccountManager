namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightFighterTaxCollectorLightInformations : GameFightFighterLightInformations
	{
		public new const short Id = 4311;
		public override short TypeId => Id;
		public ushort firstNameId { get; set; }
		public ushort lastNameId { get; set; }

		public GameFightFighterTaxCollectorLightInformations(bool sex, bool alive, double objectId, sbyte wave, ushort level, sbyte breed, ushort firstNameId, ushort lastNameId)
		{
			this.sex = sex;
			this.alive = alive;
			this.objectId = objectId;
			this.wave = wave;
			this.level = level;
			this.breed = breed;
			this.firstNameId = firstNameId;
			this.lastNameId = lastNameId;
		}

		public GameFightFighterTaxCollectorLightInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(firstNameId);
			writer.WriteVarUShort(lastNameId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			firstNameId = reader.ReadVarUShort();
			lastNameId = reader.ReadVarUShort();
		}

	}
}
