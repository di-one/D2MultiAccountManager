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
	public class InvalidPresetsMessage : NetworkMessage
	{
		public const uint Id = 3104;
		public override uint MessageId => Id;
		public IEnumerable<short> presetIds { get; set; }

		public InvalidPresetsMessage(IEnumerable<short> presetIds)
		{
			this.presetIds = presetIds;
		}

		public InvalidPresetsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)presetIds.Count());
			foreach (var objectToSend in presetIds)
            {
				writer.WriteShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var presetIdsCount = reader.ReadUShort();
			var presetIds_ = new short[presetIdsCount];
			for (var presetIdsIndex = 0; presetIdsIndex < presetIdsCount; presetIdsIndex++)
			{
				presetIds_[presetIdsIndex] = reader.ReadShort();
			}
			presetIds = presetIds_;
		}

	}
}
