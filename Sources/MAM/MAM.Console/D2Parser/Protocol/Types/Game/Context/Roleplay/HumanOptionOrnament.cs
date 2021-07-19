namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HumanOptionOrnament : HumanOption
	{
		public new const short Id = 6314;
		public override short TypeId => Id;
		public ushort ornamentId { get; set; }
		public ushort level { get; set; }
		public short leagueId { get; set; }
		public int ladderPosition { get; set; }

		public HumanOptionOrnament(ushort ornamentId, ushort level, short leagueId, int ladderPosition)
		{
			this.ornamentId = ornamentId;
			this.level = level;
			this.leagueId = leagueId;
			this.ladderPosition = ladderPosition;
		}

		public HumanOptionOrnament() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(ornamentId);
			writer.WriteVarUShort(level);
			writer.WriteVarShort(leagueId);
			writer.WriteInt(ladderPosition);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			ornamentId = reader.ReadVarUShort();
			level = reader.ReadVarUShort();
			leagueId = reader.ReadVarShort();
			ladderPosition = reader.ReadInt();
		}

	}
}
