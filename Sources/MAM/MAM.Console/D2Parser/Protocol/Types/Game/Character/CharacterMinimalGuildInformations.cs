namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterMinimalGuildInformations : CharacterMinimalPlusLookInformations
	{
		public new const short Id = 2440;
		public override short TypeId => Id;
		public BasicGuildInformations guild { get; set; }

		public CharacterMinimalGuildInformations(ulong objectId, string name, ushort level, EntityLook entityLook, sbyte breed, BasicGuildInformations guild)
		{
			this.objectId = objectId;
			this.name = name;
			this.level = level;
			this.entityLook = entityLook;
			this.breed = breed;
			this.guild = guild;
		}

		public CharacterMinimalGuildInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			guild.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			guild = new BasicGuildInformations();
			guild.Deserialize(reader);
		}

	}
}
