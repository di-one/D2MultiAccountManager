namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildChangeMemberParametersMessage : NetworkMessage
	{
		public const uint Id = 1738;
		public override uint MessageId => Id;
		public ulong memberId { get; set; }
		public ushort rank { get; set; }
		public sbyte experienceGivenPercent { get; set; }
		public uint rights { get; set; }

		public GuildChangeMemberParametersMessage(ulong memberId, ushort rank, sbyte experienceGivenPercent, uint rights)
		{
			this.memberId = memberId;
			this.rank = rank;
			this.experienceGivenPercent = experienceGivenPercent;
			this.rights = rights;
		}

		public GuildChangeMemberParametersMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(memberId);
			writer.WriteVarUShort(rank);
			writer.WriteSByte(experienceGivenPercent);
			writer.WriteVarUInt(rights);
		}

		public override void Deserialize(IDataReader reader)
		{
			memberId = reader.ReadVarULong();
			rank = reader.ReadVarUShort();
			experienceGivenPercent = reader.ReadSByte();
			rights = reader.ReadVarUInt();
		}

	}
}
