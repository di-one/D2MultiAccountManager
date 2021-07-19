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
	public class HouseInformationsForSell
	{
		public const short Id  = 4646;
		public virtual short TypeId => Id;
		public int instanceId { get; set; }
		public bool secondHand { get; set; }
		public uint modelId { get; set; }
		public AccountTagInformation ownerTag { get; set; }
		public bool hasOwner { get; set; }
		public string ownerCharacterName { get; set; }
		public short worldX { get; set; }
		public short worldY { get; set; }
		public ushort subAreaId { get; set; }
		public sbyte nbRoom { get; set; }
		public sbyte nbChest { get; set; }
		public IEnumerable<int> skillListIds { get; set; }
		public bool isLocked { get; set; }
		public ulong price { get; set; }

		public HouseInformationsForSell(int instanceId, bool secondHand, uint modelId, AccountTagInformation ownerTag, bool hasOwner, string ownerCharacterName, short worldX, short worldY, ushort subAreaId, sbyte nbRoom, sbyte nbChest, IEnumerable<int> skillListIds, bool isLocked, ulong price)
		{
			this.instanceId = instanceId;
			this.secondHand = secondHand;
			this.modelId = modelId;
			this.ownerTag = ownerTag;
			this.hasOwner = hasOwner;
			this.ownerCharacterName = ownerCharacterName;
			this.worldX = worldX;
			this.worldY = worldY;
			this.subAreaId = subAreaId;
			this.nbRoom = nbRoom;
			this.nbChest = nbChest;
			this.skillListIds = skillListIds;
			this.isLocked = isLocked;
			this.price = price;
		}

		public HouseInformationsForSell() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteInt(instanceId);
			writer.WriteBoolean(secondHand);
			writer.WriteVarUInt(modelId);
			ownerTag.Serialize(writer);
			writer.WriteBoolean(hasOwner);
			writer.WriteUTF(ownerCharacterName);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
			writer.WriteVarUShort(subAreaId);
			writer.WriteSByte(nbRoom);
			writer.WriteSByte(nbChest);
			writer.WriteShort((short)skillListIds.Count());
			foreach (var objectToSend in skillListIds)
            {
				writer.WriteInt(objectToSend);
			}
			writer.WriteBoolean(isLocked);
			writer.WriteVarULong(price);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			instanceId = reader.ReadInt();
			secondHand = reader.ReadBoolean();
			modelId = reader.ReadVarUInt();
			ownerTag = new AccountTagInformation();
			ownerTag.Deserialize(reader);
			hasOwner = reader.ReadBoolean();
			ownerCharacterName = reader.ReadUTF();
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
			subAreaId = reader.ReadVarUShort();
			nbRoom = reader.ReadSByte();
			nbChest = reader.ReadSByte();
			var skillListIdsCount = reader.ReadUShort();
			var skillListIds_ = new int[skillListIdsCount];
			for (var skillListIdsIndex = 0; skillListIdsIndex < skillListIdsCount; skillListIdsIndex++)
			{
				skillListIds_[skillListIdsIndex] = reader.ReadInt();
			}
			skillListIds = skillListIds_;
			isLocked = reader.ReadBoolean();
			price = reader.ReadVarULong();
		}

	}
}
