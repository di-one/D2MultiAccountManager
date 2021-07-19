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
	public class PaddockContentInformations : PaddockInformations
	{
		public new const short Id = 1574;
		public override short TypeId => Id;
		public double paddockId { get; set; }
		public short worldX { get; set; }
		public short worldY { get; set; }
		public double mapId { get; set; }
		public ushort subAreaId { get; set; }
		public bool abandonned { get; set; }
		public IEnumerable<MountInformationsForPaddock> mountsInformations { get; set; }

		public PaddockContentInformations(ushort maxOutdoorMount, ushort maxItems, double paddockId, short worldX, short worldY, double mapId, ushort subAreaId, bool abandonned, IEnumerable<MountInformationsForPaddock> mountsInformations)
		{
			this.maxOutdoorMount = maxOutdoorMount;
			this.maxItems = maxItems;
			this.paddockId = paddockId;
			this.worldX = worldX;
			this.worldY = worldY;
			this.mapId = mapId;
			this.subAreaId = subAreaId;
			this.abandonned = abandonned;
			this.mountsInformations = mountsInformations;
		}

		public PaddockContentInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(paddockId);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
			writer.WriteDouble(mapId);
			writer.WriteVarUShort(subAreaId);
			writer.WriteBoolean(abandonned);
			writer.WriteShort((short)mountsInformations.Count());
			foreach (var objectToSend in mountsInformations)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			paddockId = reader.ReadDouble();
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
			mapId = reader.ReadDouble();
			subAreaId = reader.ReadVarUShort();
			abandonned = reader.ReadBoolean();
			var mountsInformationsCount = reader.ReadUShort();
			var mountsInformations_ = new MountInformationsForPaddock[mountsInformationsCount];
			for (var mountsInformationsIndex = 0; mountsInformationsIndex < mountsInformationsCount; mountsInformationsIndex++)
			{
				var objectToAdd = new MountInformationsForPaddock();
				objectToAdd.Deserialize(reader);
				mountsInformations_[mountsInformationsIndex] = objectToAdd;
			}
			mountsInformations = mountsInformations_;
		}

	}
}
