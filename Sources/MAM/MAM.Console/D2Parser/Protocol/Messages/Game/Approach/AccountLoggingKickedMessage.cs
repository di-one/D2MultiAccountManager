namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AccountLoggingKickedMessage : NetworkMessage
	{
		public const uint Id = 9927;
		public override uint MessageId => Id;
		public ushort days { get; set; }
		public sbyte hours { get; set; }
		public sbyte minutes { get; set; }

		public AccountLoggingKickedMessage(ushort days, sbyte hours, sbyte minutes)
		{
			this.days = days;
			this.hours = hours;
			this.minutes = minutes;
		}

		public AccountLoggingKickedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(days);
			writer.WriteSByte(hours);
			writer.WriteSByte(minutes);
		}

		public override void Deserialize(IDataReader reader)
		{
			days = reader.ReadVarUShort();
			hours = reader.ReadSByte();
			minutes = reader.ReadSByte();
		}

	}
}
