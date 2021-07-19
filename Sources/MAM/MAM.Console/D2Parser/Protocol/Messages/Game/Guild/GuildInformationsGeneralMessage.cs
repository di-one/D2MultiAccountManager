namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildInformationsGeneralMessage : NetworkMessage
	{
		public const uint Id = 3011;
		public override uint MessageId => Id;
		public bool abandonnedPaddock { get; set; }
		public byte level { get; set; }
		public ulong expLevelFloor { get; set; }
		public ulong experience { get; set; }
		public ulong expNextLevelFloor { get; set; }
		public int creationDate { get; set; }
		public ushort nbTotalMembers { get; set; }
		public ushort nbConnectedMembers { get; set; }

		public GuildInformationsGeneralMessage(bool abandonnedPaddock, byte level, ulong expLevelFloor, ulong experience, ulong expNextLevelFloor, int creationDate, ushort nbTotalMembers, ushort nbConnectedMembers)
		{
			this.abandonnedPaddock = abandonnedPaddock;
			this.level = level;
			this.expLevelFloor = expLevelFloor;
			this.experience = experience;
			this.expNextLevelFloor = expNextLevelFloor;
			this.creationDate = creationDate;
			this.nbTotalMembers = nbTotalMembers;
			this.nbConnectedMembers = nbConnectedMembers;
		}

		public GuildInformationsGeneralMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(abandonnedPaddock);
			writer.WriteByte(level);
			writer.WriteVarULong(expLevelFloor);
			writer.WriteVarULong(experience);
			writer.WriteVarULong(expNextLevelFloor);
			writer.WriteInt(creationDate);
			writer.WriteVarUShort(nbTotalMembers);
			writer.WriteVarUShort(nbConnectedMembers);
		}

		public override void Deserialize(IDataReader reader)
		{
			abandonnedPaddock = reader.ReadBoolean();
			level = reader.ReadByte();
			expLevelFloor = reader.ReadVarULong();
			experience = reader.ReadVarULong();
			expNextLevelFloor = reader.ReadVarULong();
			creationDate = reader.ReadInt();
			nbTotalMembers = reader.ReadVarUShort();
			nbConnectedMembers = reader.ReadVarUShort();
		}

	}
}
