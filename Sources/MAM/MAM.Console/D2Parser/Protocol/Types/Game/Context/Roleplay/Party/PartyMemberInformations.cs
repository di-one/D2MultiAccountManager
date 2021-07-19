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
	public class PartyMemberInformations : CharacterBaseInformations
	{
		public new const short Id = 3956;
		public override short TypeId => Id;
		public uint lifePoints { get; set; }
		public uint maxLifePoints { get; set; }
		public ushort prospecting { get; set; }
		public byte regenRate { get; set; }
		public ushort initiative { get; set; }
		public sbyte alignmentSide { get; set; }
		public short worldX { get; set; }
		public short worldY { get; set; }
		public double mapId { get; set; }
		public ushort subAreaId { get; set; }
		public PlayerStatus status { get; set; }
		public IEnumerable<PartyEntityBaseInformation> entities { get; set; }

		public PartyMemberInformations(ulong objectId, string name, ushort level, EntityLook entityLook, sbyte breed, bool sex, uint lifePoints, uint maxLifePoints, ushort prospecting, byte regenRate, ushort initiative, sbyte alignmentSide, short worldX, short worldY, double mapId, ushort subAreaId, PlayerStatus status, IEnumerable<PartyEntityBaseInformation> entities)
		{
			this.objectId = objectId;
			this.name = name;
			this.level = level;
			this.entityLook = entityLook;
			this.breed = breed;
			this.sex = sex;
			this.lifePoints = lifePoints;
			this.maxLifePoints = maxLifePoints;
			this.prospecting = prospecting;
			this.regenRate = regenRate;
			this.initiative = initiative;
			this.alignmentSide = alignmentSide;
			this.worldX = worldX;
			this.worldY = worldY;
			this.mapId = mapId;
			this.subAreaId = subAreaId;
			this.status = status;
			this.entities = entities;
		}

		public PartyMemberInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(lifePoints);
			writer.WriteVarUInt(maxLifePoints);
			writer.WriteVarUShort(prospecting);
			writer.WriteByte(regenRate);
			writer.WriteVarUShort(initiative);
			writer.WriteSByte(alignmentSide);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
			writer.WriteDouble(mapId);
			writer.WriteVarUShort(subAreaId);
			writer.WriteShort(status.TypeId);
			status.Serialize(writer);
			writer.WriteShort((short)entities.Count());
			foreach (var objectToSend in entities)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			lifePoints = reader.ReadVarUInt();
			maxLifePoints = reader.ReadVarUInt();
			prospecting = reader.ReadVarUShort();
			regenRate = reader.ReadByte();
			initiative = reader.ReadVarUShort();
			alignmentSide = reader.ReadSByte();
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
			mapId = reader.ReadDouble();
			subAreaId = reader.ReadVarUShort();
			status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
			status.Deserialize(reader);
			var entitiesCount = reader.ReadUShort();
			var entities_ = new PartyEntityBaseInformation[entitiesCount];
			for (var entitiesIndex = 0; entitiesIndex < entitiesCount; entitiesIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<PartyEntityBaseInformation>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				entities_[entitiesIndex] = objectToAdd;
			}
			entities = entities_;
		}

	}
}
