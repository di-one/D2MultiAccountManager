namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HumanOptionEmote : HumanOption
	{
		public new const short Id = 5644;
		public override short TypeId => Id;
		public byte emoteId { get; set; }
		public double emoteStartTime { get; set; }

		public HumanOptionEmote(byte emoteId, double emoteStartTime)
		{
			this.emoteId = emoteId;
			this.emoteStartTime = emoteStartTime;
		}

		public HumanOptionEmote() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteByte(emoteId);
			writer.WriteDouble(emoteStartTime);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			emoteId = reader.ReadByte();
			emoteStartTime = reader.ReadDouble();
		}

	}
}
