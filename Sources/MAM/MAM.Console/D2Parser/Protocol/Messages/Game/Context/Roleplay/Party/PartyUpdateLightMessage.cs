namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyUpdateLightMessage : AbstractPartyEventMessage
	{
		public new const uint Id = 1032;
		public override uint MessageId => Id;
		public ulong objectId { get; set; }
		public uint lifePoints { get; set; }
		public uint maxLifePoints { get; set; }
		public ushort prospecting { get; set; }
		public byte regenRate { get; set; }

		public PartyUpdateLightMessage(uint partyId, ulong objectId, uint lifePoints, uint maxLifePoints, ushort prospecting, byte regenRate)
		{
			this.partyId = partyId;
			this.objectId = objectId;
			this.lifePoints = lifePoints;
			this.maxLifePoints = maxLifePoints;
			this.prospecting = prospecting;
			this.regenRate = regenRate;
		}

		public PartyUpdateLightMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(objectId);
			writer.WriteVarUInt(lifePoints);
			writer.WriteVarUInt(maxLifePoints);
			writer.WriteVarUShort(prospecting);
			writer.WriteByte(regenRate);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			objectId = reader.ReadVarULong();
			lifePoints = reader.ReadVarUInt();
			maxLifePoints = reader.ReadVarUInt();
			prospecting = reader.ReadVarUShort();
			regenRate = reader.ReadByte();
		}

	}
}
