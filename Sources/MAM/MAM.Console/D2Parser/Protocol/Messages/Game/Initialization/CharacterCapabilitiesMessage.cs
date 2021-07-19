namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterCapabilitiesMessage : NetworkMessage
	{
		public const uint Id = 6008;
		public override uint MessageId => Id;
		public uint guildEmblemSymbolCategories { get; set; }

		public CharacterCapabilitiesMessage(uint guildEmblemSymbolCategories)
		{
			this.guildEmblemSymbolCategories = guildEmblemSymbolCategories;
		}

		public CharacterCapabilitiesMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(guildEmblemSymbolCategories);
		}

		public override void Deserialize(IDataReader reader)
		{
			guildEmblemSymbolCategories = reader.ReadVarUInt();
		}

	}
}
