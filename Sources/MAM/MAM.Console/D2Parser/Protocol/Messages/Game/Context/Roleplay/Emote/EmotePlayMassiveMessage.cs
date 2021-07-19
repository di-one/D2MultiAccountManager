namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class EmotePlayMassiveMessage : EmotePlayAbstractMessage
	{
		public new const uint Id = 2897;
		public override uint MessageId => Id;
		public IEnumerable<double> actorIds { get; set; }

		public EmotePlayMassiveMessage(byte emoteId, double emoteStartTime, IEnumerable<double> actorIds)
		{
			this.emoteId = emoteId;
			this.emoteStartTime = emoteStartTime;
			this.actorIds = actorIds;
		}

		public EmotePlayMassiveMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)actorIds.Count());
			foreach (var objectToSend in actorIds)
            {
				writer.WriteDouble(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var actorIdsCount = reader.ReadUShort();
			var actorIds_ = new double[actorIdsCount];
			for (var actorIdsIndex = 0; actorIdsIndex < actorIdsCount; actorIdsIndex++)
			{
				actorIds_[actorIdsIndex] = reader.ReadDouble();
			}
			actorIds = actorIds_;
		}

	}
}
