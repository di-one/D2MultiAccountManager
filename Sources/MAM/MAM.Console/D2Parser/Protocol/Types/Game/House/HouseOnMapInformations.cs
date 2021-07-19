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
	public class HouseOnMapInformations : HouseInformations
	{
		public new const short Id = 2155;
		public override short TypeId => Id;
		public IEnumerable<int> doorsOnMap { get; set; }
		public IEnumerable<HouseInstanceInformations> houseInstances { get; set; }

		public HouseOnMapInformations(uint houseId, ushort modelId, IEnumerable<int> doorsOnMap, IEnumerable<HouseInstanceInformations> houseInstances)
		{
			this.houseId = houseId;
			this.modelId = modelId;
			this.doorsOnMap = doorsOnMap;
			this.houseInstances = houseInstances;
		}

		public HouseOnMapInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)doorsOnMap.Count());
			foreach (var objectToSend in doorsOnMap)
            {
				writer.WriteInt(objectToSend);
			}
			writer.WriteShort((short)houseInstances.Count());
			foreach (var objectToSend in houseInstances)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var doorsOnMapCount = reader.ReadUShort();
			var doorsOnMap_ = new int[doorsOnMapCount];
			for (var doorsOnMapIndex = 0; doorsOnMapIndex < doorsOnMapCount; doorsOnMapIndex++)
			{
				doorsOnMap_[doorsOnMapIndex] = reader.ReadInt();
			}
			doorsOnMap = doorsOnMap_;
			var houseInstancesCount = reader.ReadUShort();
			var houseInstances_ = new HouseInstanceInformations[houseInstancesCount];
			for (var houseInstancesIndex = 0; houseInstancesIndex < houseInstancesCount; houseInstancesIndex++)
			{
				var objectToAdd = new HouseInstanceInformations();
				objectToAdd.Deserialize(reader);
				houseInstances_[houseInstancesIndex] = objectToAdd;
			}
			houseInstances = houseInstances_;
		}

	}
}
