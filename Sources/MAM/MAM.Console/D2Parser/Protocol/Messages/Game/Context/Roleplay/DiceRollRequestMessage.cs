namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class DiceRollRequestMessage : NetworkMessage
	{
		public const uint Id = 2374;
		public override uint MessageId => Id;
		public uint dice { get; set; }
		public uint faces { get; set; }
		public sbyte channel { get; set; }

		public DiceRollRequestMessage(uint dice, uint faces, sbyte channel)
		{
			this.dice = dice;
			this.faces = faces;
			this.channel = channel;
		}

		public DiceRollRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(dice);
			writer.WriteVarUInt(faces);
			writer.WriteSByte(channel);
		}

		public override void Deserialize(IDataReader reader)
		{
			dice = reader.ReadVarUInt();
			faces = reader.ReadVarUInt();
			channel = reader.ReadSByte();
		}

	}
}
