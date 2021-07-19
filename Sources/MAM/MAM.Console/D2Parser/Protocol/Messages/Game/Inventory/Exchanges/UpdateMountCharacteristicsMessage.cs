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
	public class UpdateMountCharacteristicsMessage : NetworkMessage
	{
		public const uint Id = 2256;
		public override uint MessageId => Id;
		public int rideId { get; set; }
		public IEnumerable<UpdateMountCharacteristic> boostToUpdateList { get; set; }

		public UpdateMountCharacteristicsMessage(int rideId, IEnumerable<UpdateMountCharacteristic> boostToUpdateList)
		{
			this.rideId = rideId;
			this.boostToUpdateList = boostToUpdateList;
		}

		public UpdateMountCharacteristicsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarInt(rideId);
			writer.WriteShort((short)boostToUpdateList.Count());
			foreach (var objectToSend in boostToUpdateList)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			rideId = reader.ReadVarInt();
			var boostToUpdateListCount = reader.ReadUShort();
			var boostToUpdateList_ = new UpdateMountCharacteristic[boostToUpdateListCount];
			for (var boostToUpdateListIndex = 0; boostToUpdateListIndex < boostToUpdateListCount; boostToUpdateListIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<UpdateMountCharacteristic>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				boostToUpdateList_[boostToUpdateListIndex] = objectToAdd;
			}
			boostToUpdateList = boostToUpdateList_;
		}

	}
}
