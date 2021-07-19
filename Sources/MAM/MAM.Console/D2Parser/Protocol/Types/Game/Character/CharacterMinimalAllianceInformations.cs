namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterMinimalAllianceInformations : CharacterMinimalGuildInformations
	{
		public new const short Id = 5854;
		public override short TypeId => Id;
		public BasicAllianceInformations alliance { get; set; }

		public CharacterMinimalAllianceInformations(ulong objectId, string name, ushort level, EntityLook entityLook, sbyte breed, BasicGuildInformations guild, BasicAllianceInformations alliance)
		{
			this.objectId = objectId;
			this.name = name;
			this.level = level;
			this.entityLook = entityLook;
			this.breed = breed;
			this.guild = guild;
			this.alliance = alliance;
		}

		public CharacterMinimalAllianceInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			alliance.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			alliance = new BasicAllianceInformations();
			alliance.Deserialize(reader);
		}

	}
}
