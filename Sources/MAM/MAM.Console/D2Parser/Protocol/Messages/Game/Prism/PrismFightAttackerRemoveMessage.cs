namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PrismFightAttackerRemoveMessage : NetworkMessage
	{
		public const uint Id = 6919;
		public override uint MessageId => Id;
		public ushort subAreaId { get; set; }
		public ushort fightId { get; set; }
		public ulong fighterToRemoveId { get; set; }

		public PrismFightAttackerRemoveMessage(ushort subAreaId, ushort fightId, ulong fighterToRemoveId)
		{
			this.subAreaId = subAreaId;
			this.fightId = fightId;
			this.fighterToRemoveId = fighterToRemoveId;
		}

		public PrismFightAttackerRemoveMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(subAreaId);
			writer.WriteVarUShort(fightId);
			writer.WriteVarULong(fighterToRemoveId);
		}

		public override void Deserialize(IDataReader reader)
		{
			subAreaId = reader.ReadVarUShort();
			fightId = reader.ReadVarUShort();
			fighterToRemoveId = reader.ReadVarULong();
		}

	}
}
