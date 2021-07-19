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
	public class GameActionUpdateEffectTriggerCountMessage : NetworkMessage
	{
		public const uint Id = 8672;
		public override uint MessageId => Id;
		public IEnumerable<GameFightEffectTriggerCount> targetIds { get; set; }

		public GameActionUpdateEffectTriggerCountMessage(IEnumerable<GameFightEffectTriggerCount> targetIds)
		{
			this.targetIds = targetIds;
		}

		public GameActionUpdateEffectTriggerCountMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)targetIds.Count());
			foreach (var objectToSend in targetIds)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var targetIdsCount = reader.ReadUShort();
			var targetIds_ = new GameFightEffectTriggerCount[targetIdsCount];
			for (var targetIdsIndex = 0; targetIdsIndex < targetIdsCount; targetIdsIndex++)
			{
				var objectToAdd = new GameFightEffectTriggerCount();
				objectToAdd.Deserialize(reader);
				targetIds_[targetIdsIndex] = objectToAdd;
			}
			targetIds = targetIds_;
		}

	}
}
