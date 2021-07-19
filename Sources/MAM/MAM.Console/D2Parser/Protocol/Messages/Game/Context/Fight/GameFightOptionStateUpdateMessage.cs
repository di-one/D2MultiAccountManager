namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightOptionStateUpdateMessage : NetworkMessage
	{
		public const uint Id = 4364;
		public override uint MessageId => Id;
		public ushort fightId { get; set; }
		public sbyte teamId { get; set; }
		public sbyte option { get; set; }
		public bool state { get; set; }

		public GameFightOptionStateUpdateMessage(ushort fightId, sbyte teamId, sbyte option, bool state)
		{
			this.fightId = fightId;
			this.teamId = teamId;
			this.option = option;
			this.state = state;
		}

		public GameFightOptionStateUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(fightId);
			writer.WriteSByte(teamId);
			writer.WriteSByte(option);
			writer.WriteBoolean(state);
		}

		public override void Deserialize(IDataReader reader)
		{
			fightId = reader.ReadVarUShort();
			teamId = reader.ReadSByte();
			option = reader.ReadSByte();
			state = reader.ReadBoolean();
		}

	}
}
