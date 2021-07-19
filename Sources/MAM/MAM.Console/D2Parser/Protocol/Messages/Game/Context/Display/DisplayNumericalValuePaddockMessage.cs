namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class DisplayNumericalValuePaddockMessage : NetworkMessage
	{
		public const uint Id = 3417;
		public override uint MessageId => Id;
		public int rideId { get; set; }
		public int value { get; set; }
		public sbyte type { get; set; }

		public DisplayNumericalValuePaddockMessage(int rideId, int value, sbyte type)
		{
			this.rideId = rideId;
			this.value = value;
			this.type = type;
		}

		public DisplayNumericalValuePaddockMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(rideId);
			writer.WriteInt(value);
			writer.WriteSByte(type);
		}

		public override void Deserialize(IDataReader reader)
		{
			rideId = reader.ReadInt();
			value = reader.ReadInt();
			type = reader.ReadSByte();
		}

	}
}
