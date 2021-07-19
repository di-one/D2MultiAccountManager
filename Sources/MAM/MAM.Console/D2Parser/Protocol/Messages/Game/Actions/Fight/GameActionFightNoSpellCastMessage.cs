namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightNoSpellCastMessage : NetworkMessage
	{
		public const uint Id = 9699;
		public override uint MessageId => Id;
		public uint spellLevelId { get; set; }

		public GameActionFightNoSpellCastMessage(uint spellLevelId)
		{
			this.spellLevelId = spellLevelId;
		}

		public GameActionFightNoSpellCastMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(spellLevelId);
		}

		public override void Deserialize(IDataReader reader)
		{
			spellLevelId = reader.ReadVarUInt();
		}

	}
}
