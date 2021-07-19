namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IdolsPreset : Preset
	{
		public new const short Id = 5155;
		public override short TypeId => Id;
		public short iconId { get; set; }
		public IEnumerable<ushort> idolIds { get; set; }

		public IdolsPreset(short objectId, short iconId, IEnumerable<ushort> idolIds)
		{
			this.objectId = objectId;
			this.iconId = iconId;
			this.idolIds = idolIds;
		}

		public IdolsPreset() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(iconId);
			writer.WriteShort((short)idolIds.Count());
			foreach (var objectToSend in idolIds)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			iconId = reader.ReadShort();
			var idolIdsCount = reader.ReadUShort();
			var idolIds_ = new ushort[idolIdsCount];
			for (var idolIdsIndex = 0; idolIdsIndex < idolIdsCount; idolIdsIndex++)
			{
				idolIds_[idolIdsIndex] = reader.ReadVarUShort();
			}
			idolIds = idolIds_;
		}

	}
}
