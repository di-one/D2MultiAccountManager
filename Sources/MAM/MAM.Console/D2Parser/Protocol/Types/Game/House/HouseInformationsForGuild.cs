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
	public class HouseInformationsForGuild : HouseInformations
	{
		public new const short Id = 9540;
		public override short TypeId => Id;
		public int instanceId { get; set; }
		public bool secondHand { get; set; }
		public AccountTagInformation ownerTag { get; set; }
		public short worldX { get; set; }
		public short worldY { get; set; }
		public double mapId { get; set; }
		public ushort subAreaId { get; set; }
		public IEnumerable<int> skillListIds { get; set; }
		public uint guildshareParams { get; set; }

		public HouseInformationsForGuild(uint houseId, ushort modelId, int instanceId, bool secondHand, AccountTagInformation ownerTag, short worldX, short worldY, double mapId, ushort subAreaId, IEnumerable<int> skillListIds, uint guildshareParams)
		{
			this.houseId = houseId;
			this.modelId = modelId;
			this.instanceId = instanceId;
			this.secondHand = secondHand;
			this.ownerTag = ownerTag;
			this.worldX = worldX;
			this.worldY = worldY;
			this.mapId = mapId;
			this.subAreaId = subAreaId;
			this.skillListIds = skillListIds;
			this.guildshareParams = guildshareParams;
		}

		public HouseInformationsForGuild() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(instanceId);
			writer.WriteBoolean(secondHand);
			ownerTag.Serialize(writer);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
			writer.WriteDouble(mapId);
			writer.WriteVarUShort(subAreaId);
			writer.WriteShort((short)skillListIds.Count());
			foreach (var objectToSend in skillListIds)
            {
				writer.WriteInt(objectToSend);
			}
			writer.WriteVarUInt(guildshareParams);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			instanceId = reader.ReadInt();
			secondHand = reader.ReadBoolean();
			ownerTag = new AccountTagInformation();
			ownerTag.Deserialize(reader);
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
			mapId = reader.ReadDouble();
			subAreaId = reader.ReadVarUShort();
			var skillListIdsCount = reader.ReadUShort();
			var skillListIds_ = new int[skillListIdsCount];
			for (var skillListIdsIndex = 0; skillListIdsIndex < skillListIdsCount; skillListIdsIndex++)
			{
				skillListIds_[skillListIdsIndex] = reader.ReadInt();
			}
			skillListIds = skillListIds_;
			guildshareParams = reader.ReadVarUInt();
		}

	}
}
