namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class StartupActionsObjetAttributionMessage : NetworkMessage
	{
		public const uint Id = 10;
		public override uint MessageId => Id;
		public int actionId { get; set; }
		public ulong characterId { get; set; }

		public StartupActionsObjetAttributionMessage(int actionId, ulong characterId)
		{
			this.actionId = actionId;
			this.characterId = characterId;
		}

		public StartupActionsObjetAttributionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(actionId);
			writer.WriteVarULong(characterId);
		}

		public override void Deserialize(IDataReader reader)
		{
			actionId = reader.ReadInt();
			characterId = reader.ReadVarULong();
		}

	}
}
