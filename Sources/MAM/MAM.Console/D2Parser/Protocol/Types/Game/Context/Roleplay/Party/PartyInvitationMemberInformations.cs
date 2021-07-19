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
	public class PartyInvitationMemberInformations : CharacterBaseInformations
	{
		public new const short Id = 6670;
		public override short TypeId => Id;
		public short worldX { get; set; }
		public short worldY { get; set; }
		public double mapId { get; set; }
		public ushort subAreaId { get; set; }
		public IEnumerable<PartyEntityBaseInformation> entities { get; set; }

		public PartyInvitationMemberInformations(ulong objectId, string name, ushort level, EntityLook entityLook, sbyte breed, bool sex, short worldX, short worldY, double mapId, ushort subAreaId, IEnumerable<PartyEntityBaseInformation> entities)
		{
			this.objectId = objectId;
			this.name = name;
			this.level = level;
			this.entityLook = entityLook;
			this.breed = breed;
			this.sex = sex;
			this.worldX = worldX;
			this.worldY = worldY;
			this.mapId = mapId;
			this.subAreaId = subAreaId;
			this.entities = entities;
		}

		public PartyInvitationMemberInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
			writer.WriteDouble(mapId);
			writer.WriteVarUShort(subAreaId);
			writer.WriteShort((short)entities.Count());
			foreach (var objectToSend in entities)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
			mapId = reader.ReadDouble();
			subAreaId = reader.ReadVarUShort();
			var entitiesCount = reader.ReadUShort();
			var entities_ = new PartyEntityBaseInformation[entitiesCount];
			for (var entitiesIndex = 0; entitiesIndex < entitiesCount; entitiesIndex++)
			{
				var objectToAdd = new PartyEntityBaseInformation();
				objectToAdd.Deserialize(reader);
				entities_[entitiesIndex] = objectToAdd;
			}
			entities = entities_;
		}

	}
}
