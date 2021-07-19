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
	public class ExchangeGuildTaxCollectorGetMessage : NetworkMessage
	{
		public const uint Id = 2529;
		public override uint MessageId => Id;
		public string collectorName { get; set; }
		public short worldX { get; set; }
		public short worldY { get; set; }
		public double mapId { get; set; }
		public ushort subAreaId { get; set; }
		public string userName { get; set; }
		public ulong callerId { get; set; }
		public string callerName { get; set; }
		public double experience { get; set; }
		public ushort pods { get; set; }
		public IEnumerable<ObjectItemGenericQuantity> objectsInfos { get; set; }

		public ExchangeGuildTaxCollectorGetMessage(string collectorName, short worldX, short worldY, double mapId, ushort subAreaId, string userName, ulong callerId, string callerName, double experience, ushort pods, IEnumerable<ObjectItemGenericQuantity> objectsInfos)
		{
			this.collectorName = collectorName;
			this.worldX = worldX;
			this.worldY = worldY;
			this.mapId = mapId;
			this.subAreaId = subAreaId;
			this.userName = userName;
			this.callerId = callerId;
			this.callerName = callerName;
			this.experience = experience;
			this.pods = pods;
			this.objectsInfos = objectsInfos;
		}

		public ExchangeGuildTaxCollectorGetMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(collectorName);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
			writer.WriteDouble(mapId);
			writer.WriteVarUShort(subAreaId);
			writer.WriteUTF(userName);
			writer.WriteVarULong(callerId);
			writer.WriteUTF(callerName);
			writer.WriteDouble(experience);
			writer.WriteVarUShort(pods);
			writer.WriteShort((short)objectsInfos.Count());
			foreach (var objectToSend in objectsInfos)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			collectorName = reader.ReadUTF();
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
			mapId = reader.ReadDouble();
			subAreaId = reader.ReadVarUShort();
			userName = reader.ReadUTF();
			callerId = reader.ReadVarULong();
			callerName = reader.ReadUTF();
			experience = reader.ReadDouble();
			pods = reader.ReadVarUShort();
			var objectsInfosCount = reader.ReadUShort();
			var objectsInfos_ = new ObjectItemGenericQuantity[objectsInfosCount];
			for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
			{
				var objectToAdd = new ObjectItemGenericQuantity();
				objectToAdd.Deserialize(reader);
				objectsInfos_[objectsInfosIndex] = objectToAdd;
			}
			objectsInfos = objectsInfos_;
		}

	}
}
