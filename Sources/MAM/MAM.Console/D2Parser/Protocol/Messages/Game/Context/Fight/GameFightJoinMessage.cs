namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightJoinMessage : NetworkMessage
	{
		public const uint Id = 1625;
		public override uint MessageId => Id;
		public bool isTeamPhase { get; set; }
		public bool canBeCancelled { get; set; }
		public bool canSayReady { get; set; }
		public bool isFightStarted { get; set; }
		public short timeMaxBeforeFightStart { get; set; }
		public sbyte fightType { get; set; }

		public GameFightJoinMessage(bool isTeamPhase, bool canBeCancelled, bool canSayReady, bool isFightStarted, short timeMaxBeforeFightStart, sbyte fightType)
		{
			this.isTeamPhase = isTeamPhase;
			this.canBeCancelled = canBeCancelled;
			this.canSayReady = canSayReady;
			this.isFightStarted = isFightStarted;
			this.timeMaxBeforeFightStart = timeMaxBeforeFightStart;
			this.fightType = fightType;
		}

		public GameFightJoinMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, isTeamPhase);
			flag = BooleanByteWrapper.SetFlag(flag, 1, canBeCancelled);
			flag = BooleanByteWrapper.SetFlag(flag, 2, canSayReady);
			flag = BooleanByteWrapper.SetFlag(flag, 3, isFightStarted);
			writer.WriteByte(flag);
			writer.WriteShort(timeMaxBeforeFightStart);
			writer.WriteSByte(fightType);
		}

		public override void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			isTeamPhase = BooleanByteWrapper.GetFlag(flag, 0);
			canBeCancelled = BooleanByteWrapper.GetFlag(flag, 1);
			canSayReady = BooleanByteWrapper.GetFlag(flag, 2);
			isFightStarted = BooleanByteWrapper.GetFlag(flag, 3);
			timeMaxBeforeFightStart = reader.ReadShort();
			fightType = reader.ReadSByte();
		}

	}
}
