namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightNewRoundMessage : NetworkMessage
	{
		public const uint Id = 1563;
		public override uint MessageId => Id;
		public uint roundNumber { get; set; }

		public GameFightNewRoundMessage(uint roundNumber)
		{
			this.roundNumber = roundNumber;
		}

		public GameFightNewRoundMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(roundNumber);
		}

		public override void Deserialize(IDataReader reader)
		{
			roundNumber = reader.ReadVarUInt();
		}

	}
}
