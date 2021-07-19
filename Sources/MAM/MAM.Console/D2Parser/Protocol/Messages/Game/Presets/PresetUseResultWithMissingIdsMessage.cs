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
	public class PresetUseResultWithMissingIdsMessage : PresetUseResultMessage
	{
		public new const uint Id = 294;
		public override uint MessageId => Id;
		public IEnumerable<ushort> missingIds { get; set; }

		public PresetUseResultWithMissingIdsMessage(short presetId, sbyte code, IEnumerable<ushort> missingIds)
		{
			this.presetId = presetId;
			this.code = code;
			this.missingIds = missingIds;
		}

		public PresetUseResultWithMissingIdsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)missingIds.Count());
			foreach (var objectToSend in missingIds)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var missingIdsCount = reader.ReadUShort();
			var missingIds_ = new ushort[missingIdsCount];
			for (var missingIdsIndex = 0; missingIdsIndex < missingIdsCount; missingIdsIndex++)
			{
				missingIds_[missingIdsIndex] = reader.ReadVarUShort();
			}
			missingIds = missingIds_;
		}

	}
}
