namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AcquaintanceOnlineInformation : AcquaintanceInformation
	{
		public new const short Id = 6947;
		public override short TypeId => Id;
		public ulong playerId { get; set; }
		public string playerName { get; set; }
		public ushort moodSmileyId { get; set; }
		public PlayerStatus status { get; set; }

		public AcquaintanceOnlineInformation(int accountId, AccountTagInformation accountTag, sbyte playerState, ulong playerId, string playerName, ushort moodSmileyId, PlayerStatus status)
		{
			this.accountId = accountId;
			this.accountTag = accountTag;
			this.playerState = playerState;
			this.playerId = playerId;
			this.playerName = playerName;
			this.moodSmileyId = moodSmileyId;
			this.status = status;
		}

		public AcquaintanceOnlineInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(playerId);
			writer.WriteUTF(playerName);
			writer.WriteVarUShort(moodSmileyId);
			writer.WriteShort(status.TypeId);
			status.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			playerId = reader.ReadVarULong();
			playerName = reader.ReadUTF();
			moodSmileyId = reader.ReadVarUShort();
			status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
			status.Deserialize(reader);
		}

	}
}
