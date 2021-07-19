namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterExperienceGainMessage : NetworkMessage
	{
		public const uint Id = 8597;
		public override uint MessageId => Id;
		public ulong experienceCharacter { get; set; }
		public ulong experienceMount { get; set; }
		public ulong experienceGuild { get; set; }
		public ulong experienceIncarnation { get; set; }

		public CharacterExperienceGainMessage(ulong experienceCharacter, ulong experienceMount, ulong experienceGuild, ulong experienceIncarnation)
		{
			this.experienceCharacter = experienceCharacter;
			this.experienceMount = experienceMount;
			this.experienceGuild = experienceGuild;
			this.experienceIncarnation = experienceIncarnation;
		}

		public CharacterExperienceGainMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(experienceCharacter);
			writer.WriteVarULong(experienceMount);
			writer.WriteVarULong(experienceGuild);
			writer.WriteVarULong(experienceIncarnation);
		}

		public override void Deserialize(IDataReader reader)
		{
			experienceCharacter = reader.ReadVarULong();
			experienceMount = reader.ReadVarULong();
			experienceGuild = reader.ReadVarULong();
			experienceIncarnation = reader.ReadVarULong();
		}

	}
}
