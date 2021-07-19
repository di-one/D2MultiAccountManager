namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PrismFightDefenderAddMessage : NetworkMessage
	{
		public const uint Id = 6333;
		public override uint MessageId => Id;
		public ushort subAreaId { get; set; }
		public ushort fightId { get; set; }
		public CharacterMinimalPlusLookInformations defender { get; set; }

		public PrismFightDefenderAddMessage(ushort subAreaId, ushort fightId, CharacterMinimalPlusLookInformations defender)
		{
			this.subAreaId = subAreaId;
			this.fightId = fightId;
			this.defender = defender;
		}

		public PrismFightDefenderAddMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(subAreaId);
			writer.WriteVarUShort(fightId);
			writer.WriteShort(defender.TypeId);
			defender.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			subAreaId = reader.ReadVarUShort();
			fightId = reader.ReadVarUShort();
			defender = ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>(reader.ReadShort());
			defender.Deserialize(reader);
		}

	}
}
