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
	public class PartyMemberArenaInformations : PartyMemberInformations
	{
		public new const short Id = 358;
		public override short TypeId => Id;
		public ushort rank { get; set; }

		public PartyMemberArenaInformations(ulong objectId, string name, ushort level, EntityLook entityLook, sbyte breed, bool sex, uint lifePoints, uint maxLifePoints, ushort prospecting, byte regenRate, ushort initiative, sbyte alignmentSide, short worldX, short worldY, double mapId, ushort subAreaId, PlayerStatus status, IEnumerable<PartyEntityBaseInformation> entities, ushort rank)
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
			this.rank = rank;
		}

		public PartyMemberArenaInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(rank);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			rank = reader.ReadVarUShort();
		}

	}
}
