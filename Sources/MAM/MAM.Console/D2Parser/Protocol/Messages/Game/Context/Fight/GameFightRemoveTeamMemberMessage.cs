namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightRemoveTeamMemberMessage : NetworkMessage
	{
		public const uint Id = 8042;
		public override uint MessageId => Id;
		public ushort fightId { get; set; }
		public sbyte teamId { get; set; }
		public double charId { get; set; }

		public GameFightRemoveTeamMemberMessage(ushort fightId, sbyte teamId, double charId)
		{
			this.fightId = fightId;
			this.teamId = teamId;
			this.charId = charId;
		}

		public GameFightRemoveTeamMemberMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(fightId);
			writer.WriteSByte(teamId);
			writer.WriteDouble(charId);
		}

		public override void Deserialize(IDataReader reader)
		{
			fightId = reader.ReadVarUShort();
			teamId = reader.ReadSByte();
			charId = reader.ReadDouble();
		}

	}
}
