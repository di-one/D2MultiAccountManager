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
	public class TreasureHuntShowLegendaryUIMessage : NetworkMessage
	{
		public const uint Id = 3293;
		public override uint MessageId => Id;
		public IEnumerable<ushort> availableLegendaryIds { get; set; }

		public TreasureHuntShowLegendaryUIMessage(IEnumerable<ushort> availableLegendaryIds)
		{
			this.availableLegendaryIds = availableLegendaryIds;
		}

		public TreasureHuntShowLegendaryUIMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)availableLegendaryIds.Count());
			foreach (var objectToSend in availableLegendaryIds)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var availableLegendaryIdsCount = reader.ReadUShort();
			var availableLegendaryIds_ = new ushort[availableLegendaryIdsCount];
			for (var availableLegendaryIdsIndex = 0; availableLegendaryIdsIndex < availableLegendaryIdsCount; availableLegendaryIdsIndex++)
			{
				availableLegendaryIds_[availableLegendaryIdsIndex] = reader.ReadVarUShort();
			}
			availableLegendaryIds = availableLegendaryIds_;
		}

	}
}
