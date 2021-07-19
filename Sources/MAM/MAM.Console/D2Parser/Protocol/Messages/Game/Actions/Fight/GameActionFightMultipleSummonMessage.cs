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
	public class GameActionFightMultipleSummonMessage : AbstractGameActionMessage
	{
		public new const uint Id = 5219;
		public override uint MessageId => Id;
		public IEnumerable<GameContextSummonsInformation> summons { get; set; }

		public GameActionFightMultipleSummonMessage(ushort actionId, double sourceId, IEnumerable<GameContextSummonsInformation> summons)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.summons = summons;
		}

		public GameActionFightMultipleSummonMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)summons.Count());
			foreach (var objectToSend in summons)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var summonsCount = reader.ReadUShort();
			var summons_ = new GameContextSummonsInformation[summonsCount];
			for (var summonsIndex = 0; summonsIndex < summonsCount; summonsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<GameContextSummonsInformation>((ushort)reader.ReadShort());
				objectToAdd.Deserialize(reader);
				summons_[summonsIndex] = objectToAdd;
			}
			summons = summons_;
		}

	}
}
