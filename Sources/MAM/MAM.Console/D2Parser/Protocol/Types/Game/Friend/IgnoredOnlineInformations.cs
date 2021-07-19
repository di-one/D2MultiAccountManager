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
	public class IgnoredOnlineInformations : IgnoredInformations
	{
		public new const short Id = 2860;
		public override short TypeId => Id;
		public ulong playerId { get; set; }
		public string playerName { get; set; }
		public sbyte breed { get; set; }
		public bool sex { get; set; }

		public IgnoredOnlineInformations(int accountId, AccountTagInformation accountTag, ulong playerId, string playerName, sbyte breed, bool sex)
		{
			this.accountId = accountId;
			this.accountTag = accountTag;
			this.playerId = playerId;
			this.playerName = playerName;
			this.breed = breed;
			this.sex = sex;
		}

		public IgnoredOnlineInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(playerId);
			writer.WriteUTF(playerName);
			writer.WriteSByte(breed);
			writer.WriteBoolean(sex);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			playerId = reader.ReadVarULong();
			playerName = reader.ReadUTF();
			breed = reader.ReadSByte();
			sex = reader.ReadBoolean();
		}

	}
}
