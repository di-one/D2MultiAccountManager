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
	public class EntitiesPreset : Preset
	{
		public new const short Id = 8645;
		public override short TypeId => Id;
		public short iconId { get; set; }
		public IEnumerable<ushort> entityIds { get; set; }

		public EntitiesPreset(short objectId, short iconId, IEnumerable<ushort> entityIds)
		{
			this.objectId = objectId;
			this.iconId = iconId;
			this.entityIds = entityIds;
		}

		public EntitiesPreset() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(iconId);
			writer.WriteShort((short)entityIds.Count());
			foreach (var objectToSend in entityIds)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			iconId = reader.ReadShort();
			var entityIdsCount = reader.ReadUShort();
			var entityIds_ = new ushort[entityIdsCount];
			for (var entityIdsIndex = 0; entityIdsIndex < entityIdsCount; entityIdsIndex++)
			{
				entityIds_[entityIdsIndex] = reader.ReadVarUShort();
			}
			entityIds = entityIds_;
		}

	}
}
