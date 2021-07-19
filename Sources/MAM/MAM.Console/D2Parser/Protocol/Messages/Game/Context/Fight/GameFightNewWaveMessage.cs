namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightNewWaveMessage : NetworkMessage
	{
		public const uint Id = 3548;
		public override uint MessageId => Id;
		public sbyte objectId { get; set; }
		public sbyte teamId { get; set; }
		public short nbTurnBeforeNextWave { get; set; }

		public GameFightNewWaveMessage(sbyte objectId, sbyte teamId, short nbTurnBeforeNextWave)
		{
			this.objectId = objectId;
			this.teamId = teamId;
			this.nbTurnBeforeNextWave = nbTurnBeforeNextWave;
		}

		public GameFightNewWaveMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(objectId);
			writer.WriteSByte(teamId);
			writer.WriteShort(nbTurnBeforeNextWave);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadSByte();
			teamId = reader.ReadSByte();
			nbTurnBeforeNextWave = reader.ReadShort();
		}

	}
}
