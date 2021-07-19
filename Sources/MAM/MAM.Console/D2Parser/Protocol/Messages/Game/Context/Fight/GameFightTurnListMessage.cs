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
	public class GameFightTurnListMessage : NetworkMessage
	{
		public const uint Id = 3288;
		public override uint MessageId => Id;
		public IEnumerable<double> ids { get; set; }
		public IEnumerable<double> deadsIds { get; set; }

		public GameFightTurnListMessage(IEnumerable<double> ids, IEnumerable<double> deadsIds)
		{
			this.ids = ids;
			this.deadsIds = deadsIds;
		}

		public GameFightTurnListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)ids.Count());
			foreach (var objectToSend in ids)
            {
				writer.WriteDouble(objectToSend);
			}
			writer.WriteShort((short)deadsIds.Count());
			foreach (var objectToSend in deadsIds)
            {
				writer.WriteDouble(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var idsCount = reader.ReadUShort();
			var ids_ = new double[idsCount];
			for (var idsIndex = 0; idsIndex < idsCount; idsIndex++)
			{
				ids_[idsIndex] = reader.ReadDouble();
			}
			ids = ids_;
			var deadsIdsCount = reader.ReadUShort();
			var deadsIds_ = new double[deadsIdsCount];
			for (var deadsIdsIndex = 0; deadsIdsIndex < deadsIdsCount; deadsIdsIndex++)
			{
				deadsIds_[deadsIdsIndex] = reader.ReadDouble();
			}
			deadsIds = deadsIds_;
		}

	}
}
