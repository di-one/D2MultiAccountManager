namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Protocol.Enums;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class DungeonPartyFinderPlayer
	{
		public const short Id  = 7370;
		public virtual short TypeId => Id;
		public ulong playerId { get; set; }
		public string playerName { get; set; }
		public sbyte breed { get; set; }
		public bool sex { get; set; }
		public ushort level { get; set; }

		public DungeonPartyFinderPlayer(ulong playerId, string playerName, sbyte breed, bool sex, ushort level)
		{
			this.playerId = playerId;
			this.playerName = playerName;
			this.breed = breed;
			this.sex = sex;
			this.level = level;
		}

		public DungeonPartyFinderPlayer() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(playerId);
			writer.WriteUTF(playerName);
			writer.WriteSByte(breed);
			writer.WriteBoolean(sex);
			writer.WriteVarUShort(level);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			playerId = reader.ReadVarULong();
			playerName = reader.ReadUTF();
			breed = reader.ReadSByte();
			sex = reader.ReadBoolean();
			level = reader.ReadVarUShort();
		}

	}
}
