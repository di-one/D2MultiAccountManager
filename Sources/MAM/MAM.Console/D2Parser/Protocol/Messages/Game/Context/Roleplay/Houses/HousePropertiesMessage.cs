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
	public class HousePropertiesMessage : NetworkMessage
	{
		public const uint Id = 7872;
		public override uint MessageId => Id;
		public uint houseId { get; set; }
		public IEnumerable<int> doorsOnMap { get; set; }
		public HouseInstanceInformations properties { get; set; }

		public HousePropertiesMessage(uint houseId, IEnumerable<int> doorsOnMap, HouseInstanceInformations properties)
		{
			this.houseId = houseId;
			this.doorsOnMap = doorsOnMap;
			this.properties = properties;
		}

		public HousePropertiesMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(houseId);
			writer.WriteShort((short)doorsOnMap.Count());
			foreach (var objectToSend in doorsOnMap)
            {
				writer.WriteInt(objectToSend);
			}
			writer.WriteShort(properties.TypeId);
			properties.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			houseId = reader.ReadVarUInt();
			var doorsOnMapCount = reader.ReadUShort();
			var doorsOnMap_ = new int[doorsOnMapCount];
			for (var doorsOnMapIndex = 0; doorsOnMapIndex < doorsOnMapCount; doorsOnMapIndex++)
			{
				doorsOnMap_[doorsOnMapIndex] = reader.ReadInt();
			}
			doorsOnMap = doorsOnMap_;
			properties = ProtocolTypeManager.GetInstance<HouseInstanceInformations>(reader.ReadShort());
			properties.Deserialize(reader);
		}

	}
}
