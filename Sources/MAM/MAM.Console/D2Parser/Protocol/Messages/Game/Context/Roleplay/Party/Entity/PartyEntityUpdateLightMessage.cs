namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyEntityUpdateLightMessage : PartyUpdateLightMessage
	{
		public new const uint Id = 4825;
		public override uint MessageId => Id;
		public sbyte indexId { get; set; }

		public PartyEntityUpdateLightMessage(uint partyId, ulong objectId, uint lifePoints, uint maxLifePoints, ushort prospecting, byte regenRate, sbyte indexId)
		{
			this.partyId = partyId;
			this.objectId = objectId;
			this.lifePoints = lifePoints;
			this.maxLifePoints = maxLifePoints;
			this.prospecting = prospecting;
			this.regenRate = regenRate;
			this.indexId = indexId;
		}

		public PartyEntityUpdateLightMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(indexId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			indexId = reader.ReadSByte();
		}

	}
}
