namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class StartupActionsAllAttributionMessage : NetworkMessage
	{
		public const uint Id = 2880;
		public override uint MessageId => Id;
		public ulong characterId { get; set; }

		public StartupActionsAllAttributionMessage(ulong characterId)
		{
			this.characterId = characterId;
		}

		public StartupActionsAllAttributionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(characterId);
		}

		public override void Deserialize(IDataReader reader)
		{
			characterId = reader.ReadVarULong();
		}

	}
}
