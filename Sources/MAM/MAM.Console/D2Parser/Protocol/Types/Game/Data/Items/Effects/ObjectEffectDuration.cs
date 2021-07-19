namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectEffectDuration : ObjectEffect
	{
		public new const short Id = 1342;
		public override short TypeId => Id;
		public ushort days { get; set; }
		public sbyte hours { get; set; }
		public sbyte minutes { get; set; }

		public ObjectEffectDuration(ushort actionId, ushort days, sbyte hours, sbyte minutes)
		{
			this.actionId = actionId;
			this.days = days;
			this.hours = hours;
			this.minutes = minutes;
		}

		public ObjectEffectDuration() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(days);
			writer.WriteSByte(hours);
			writer.WriteSByte(minutes);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			days = reader.ReadVarUShort();
			hours = reader.ReadSByte();
			minutes = reader.ReadSByte();
		}

	}
}
