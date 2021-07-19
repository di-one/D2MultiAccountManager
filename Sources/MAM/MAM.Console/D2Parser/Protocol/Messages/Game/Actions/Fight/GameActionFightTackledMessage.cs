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
	public class GameActionFightTackledMessage : AbstractGameActionMessage
	{
		public new const uint Id = 5099;
		public override uint MessageId => Id;
		public IEnumerable<double> tacklersIds { get; set; }

		public GameActionFightTackledMessage(ushort actionId, double sourceId, IEnumerable<double> tacklersIds)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.tacklersIds = tacklersIds;
		}

		public GameActionFightTackledMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)tacklersIds.Count());
			foreach (var objectToSend in tacklersIds)
            {
				writer.WriteDouble(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var tacklersIdsCount = reader.ReadUShort();
			var tacklersIds_ = new double[tacklersIdsCount];
			for (var tacklersIdsIndex = 0; tacklersIdsIndex < tacklersIdsCount; tacklersIdsIndex++)
			{
				tacklersIds_[tacklersIdsIndex] = reader.ReadDouble();
			}
			tacklersIds = tacklersIds_;
		}

	}
}
