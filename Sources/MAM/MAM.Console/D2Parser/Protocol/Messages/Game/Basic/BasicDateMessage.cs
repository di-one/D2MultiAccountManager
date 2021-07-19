namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BasicDateMessage : NetworkMessage
	{
		public const uint Id = 5022;
		public override uint MessageId => Id;
		public sbyte day { get; set; }
		public sbyte month { get; set; }
		public short year { get; set; }

		public BasicDateMessage(sbyte day, sbyte month, short year)
		{
			this.day = day;
			this.month = month;
			this.year = year;
		}

		public BasicDateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(day);
			writer.WriteSByte(month);
			writer.WriteShort(year);
		}

		public override void Deserialize(IDataReader reader)
		{
			day = reader.ReadSByte();
			month = reader.ReadSByte();
			year = reader.ReadShort();
		}

	}
}
