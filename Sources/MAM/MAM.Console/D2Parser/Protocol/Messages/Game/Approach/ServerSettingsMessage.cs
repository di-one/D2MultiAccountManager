namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ServerSettingsMessage : NetworkMessage
	{
		public const uint Id = 7281;
		public override uint MessageId => Id;
		public bool isMonoAccount { get; set; }
		public bool hasFreeAutopilot { get; set; }
		public string lang { get; set; }
		public sbyte community { get; set; }
		public sbyte gameType { get; set; }
		public ushort arenaLeaveBanTime { get; set; }
		public int itemMaxLevel { get; set; }

		public ServerSettingsMessage(bool isMonoAccount, bool hasFreeAutopilot, string lang, sbyte community, sbyte gameType, ushort arenaLeaveBanTime, int itemMaxLevel)
		{
			this.isMonoAccount = isMonoAccount;
			this.hasFreeAutopilot = hasFreeAutopilot;
			this.lang = lang;
			this.community = community;
			this.gameType = gameType;
			this.arenaLeaveBanTime = arenaLeaveBanTime;
			this.itemMaxLevel = itemMaxLevel;
		}

		public ServerSettingsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, isMonoAccount);
			flag = BooleanByteWrapper.SetFlag(flag, 1, hasFreeAutopilot);
			writer.WriteByte(flag);
			writer.WriteUTF(lang);
			writer.WriteSByte(community);
			writer.WriteSByte(gameType);
			writer.WriteVarUShort(arenaLeaveBanTime);
			writer.WriteInt(itemMaxLevel);
		}

		public override void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			isMonoAccount = BooleanByteWrapper.GetFlag(flag, 0);
			hasFreeAutopilot = BooleanByteWrapper.GetFlag(flag, 1);
			lang = reader.ReadUTF();
			community = reader.ReadSByte();
			gameType = reader.ReadSByte();
			arenaLeaveBanTime = reader.ReadVarUShort();
			itemMaxLevel = reader.ReadInt();
		}

	}
}
