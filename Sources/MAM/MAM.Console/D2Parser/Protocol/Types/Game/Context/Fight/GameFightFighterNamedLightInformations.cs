namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightFighterNamedLightInformations : GameFightFighterLightInformations
	{
		public new const short Id = 4418;
		public override short TypeId => Id;
		public string name { get; set; }

		public GameFightFighterNamedLightInformations(bool sex, bool alive, double objectId, sbyte wave, ushort level, sbyte breed, string name)
		{
			this.sex = sex;
			this.alive = alive;
			this.objectId = objectId;
			this.wave = wave;
			this.level = level;
			this.breed = breed;
			this.name = name;
		}

		public GameFightFighterNamedLightInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(name);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			name = reader.ReadUTF();
		}

	}
}
