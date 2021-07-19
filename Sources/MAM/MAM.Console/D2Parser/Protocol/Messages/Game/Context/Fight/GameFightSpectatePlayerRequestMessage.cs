namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightSpectatePlayerRequestMessage : NetworkMessage
	{
		public const uint Id = 4230;
		public override uint MessageId => Id;
		public ulong playerId { get; set; }

		public GameFightSpectatePlayerRequestMessage(ulong playerId)
		{
			this.playerId = playerId;
		}

		public GameFightSpectatePlayerRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(playerId);
		}

		public override void Deserialize(IDataReader reader)
		{
			playerId = reader.ReadVarULong();
		}

	}
}
