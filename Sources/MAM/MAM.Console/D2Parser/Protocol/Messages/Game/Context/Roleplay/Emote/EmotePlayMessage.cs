namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class EmotePlayMessage : EmotePlayAbstractMessage
	{
		public new const uint Id = 8706;
		public override uint MessageId => Id;
		public double actorId { get; set; }
		public int accountId { get; set; }

		public EmotePlayMessage(byte emoteId, double emoteStartTime, double actorId, int accountId)
		{
			this.emoteId = emoteId;
			this.emoteStartTime = emoteStartTime;
			this.actorId = actorId;
			this.accountId = accountId;
		}

		public EmotePlayMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(actorId);
			writer.WriteInt(accountId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			actorId = reader.ReadDouble();
			accountId = reader.ReadInt();
		}

	}
}
