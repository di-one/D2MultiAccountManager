namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AlmanachCalendarDateMessage : NetworkMessage
	{
		public const uint Id = 1654;
		public override uint MessageId => Id;
		public int date { get; set; }

		public AlmanachCalendarDateMessage(int date)
		{
			this.date = date;
		}

		public AlmanachCalendarDateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(date);
		}

		public override void Deserialize(IDataReader reader)
		{
			date = reader.ReadInt();
		}

	}
}
