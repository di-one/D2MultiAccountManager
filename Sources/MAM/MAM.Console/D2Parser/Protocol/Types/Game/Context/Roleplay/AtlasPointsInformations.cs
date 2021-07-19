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
	public class AtlasPointsInformations
	{
		public const short Id  = 5863;
		public virtual short TypeId => Id;
		public sbyte type { get; set; }
		public IEnumerable<MapCoordinatesExtended> coords { get; set; }

		public AtlasPointsInformations(sbyte type, IEnumerable<MapCoordinatesExtended> coords)
		{
			this.type = type;
			this.coords = coords;
		}

		public AtlasPointsInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(type);
			writer.WriteShort((short)coords.Count());
			foreach (var objectToSend in coords)
            {
				objectToSend.Serialize(writer);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			type = reader.ReadSByte();
			var coordsCount = reader.ReadUShort();
			var coords_ = new MapCoordinatesExtended[coordsCount];
			for (var coordsIndex = 0; coordsIndex < coordsCount; coordsIndex++)
			{
				var objectToAdd = new MapCoordinatesExtended();
				objectToAdd.Deserialize(reader);
				coords_[coordsIndex] = objectToAdd;
			}
			coords = coords_;
		}

	}
}
