namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceVersatileInformations
	{
		public const short Id  = 2549;
		public virtual short TypeId => Id;
		public uint allianceId { get; set; }
		public ushort nbGuilds { get; set; }
		public ushort nbMembers { get; set; }
		public ushort nbSubarea { get; set; }

		public AllianceVersatileInformations(uint allianceId, ushort nbGuilds, ushort nbMembers, ushort nbSubarea)
		{
			this.allianceId = allianceId;
			this.nbGuilds = nbGuilds;
			this.nbMembers = nbMembers;
			this.nbSubarea = nbSubarea;
		}

		public AllianceVersatileInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(allianceId);
			writer.WriteVarUShort(nbGuilds);
			writer.WriteVarUShort(nbMembers);
			writer.WriteVarUShort(nbSubarea);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			allianceId = reader.ReadVarUInt();
			nbGuilds = reader.ReadVarUShort();
			nbMembers = reader.ReadVarUShort();
			nbSubarea = reader.ReadVarUShort();
		}

	}
}
