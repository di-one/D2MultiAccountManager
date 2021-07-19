namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightJoinRequestMessage : NetworkMessage
	{
		public const uint Id = 2250;
		public override uint MessageId => Id;
		public double fighterId { get; set; }
		public ushort fightId { get; set; }

		public GameFightJoinRequestMessage(double fighterId, ushort fightId)
		{
			this.fighterId = fighterId;
			this.fightId = fightId;
		}

		public GameFightJoinRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(fighterId);
			writer.WriteVarUShort(fightId);
		}

		public override void Deserialize(IDataReader reader)
		{
			fighterId = reader.ReadDouble();
			fightId = reader.ReadVarUShort();
		}

	}
}
