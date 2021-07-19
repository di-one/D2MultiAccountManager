namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PrismFightAttackerAddMessage : NetworkMessage
	{
		public const uint Id = 9673;
		public override uint MessageId => Id;
		public ushort subAreaId { get; set; }
		public ushort fightId { get; set; }
		public CharacterMinimalPlusLookInformations attacker { get; set; }

		public PrismFightAttackerAddMessage(ushort subAreaId, ushort fightId, CharacterMinimalPlusLookInformations attacker)
		{
			this.subAreaId = subAreaId;
			this.fightId = fightId;
			this.attacker = attacker;
		}

		public PrismFightAttackerAddMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(subAreaId);
			writer.WriteVarUShort(fightId);
			writer.WriteShort(attacker.TypeId);
			attacker.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			subAreaId = reader.ReadVarUShort();
			fightId = reader.ReadVarUShort();
			attacker = ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>(reader.ReadShort());
			attacker.Deserialize(reader);
		}

	}
}
