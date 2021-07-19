namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectEffectDate : ObjectEffect
	{
		public new const short Id = 6498;
		public override short TypeId => Id;
		public ushort year { get; set; }
		public sbyte month { get; set; }
		public sbyte day { get; set; }
		public sbyte hour { get; set; }
		public sbyte minute { get; set; }

		public ObjectEffectDate(ushort actionId, ushort year, sbyte month, sbyte day, sbyte hour, sbyte minute)
		{
			this.actionId = actionId;
			this.year = year;
			this.month = month;
			this.day = day;
			this.hour = hour;
			this.minute = minute;
		}

		public ObjectEffectDate() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(year);
			writer.WriteSByte(month);
			writer.WriteSByte(day);
			writer.WriteSByte(hour);
			writer.WriteSByte(minute);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			year = reader.ReadVarUShort();
			month = reader.ReadSByte();
			day = reader.ReadSByte();
			hour = reader.ReadSByte();
			minute = reader.ReadSByte();
		}

	}
}
