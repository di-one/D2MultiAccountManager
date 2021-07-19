namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildSpellUpgradeRequestMessage : NetworkMessage
	{
		public const uint Id = 8606;
		public override uint MessageId => Id;
		public int spellId { get; set; }

		public GuildSpellUpgradeRequestMessage(int spellId)
		{
			this.spellId = spellId;
		}

		public GuildSpellUpgradeRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(spellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			spellId = reader.ReadInt();
		}

	}
}
