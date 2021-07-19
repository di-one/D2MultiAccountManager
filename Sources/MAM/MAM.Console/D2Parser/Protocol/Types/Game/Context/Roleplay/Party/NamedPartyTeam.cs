namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class NamedPartyTeam
	{
		public const short Id  = 1971;
		public virtual short TypeId => Id;
		public sbyte teamId { get; set; }
		public string partyName { get; set; }

		public NamedPartyTeam(sbyte teamId, string partyName)
		{
			this.teamId = teamId;
			this.partyName = partyName;
		}

		public NamedPartyTeam() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(teamId);
			writer.WriteUTF(partyName);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			teamId = reader.ReadSByte();
			partyName = reader.ReadUTF();
		}

	}
}
