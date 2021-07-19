namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TreasureHuntDigRequestMessage : NetworkMessage
	{
		public const uint Id = 683;
		public override uint MessageId => Id;
		public sbyte questType { get; set; }

		public TreasureHuntDigRequestMessage(sbyte questType)
		{
			this.questType = questType;
		}

		public TreasureHuntDigRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(questType);
		}

		public override void Deserialize(IDataReader reader)
		{
			questType = reader.ReadSByte();
		}

	}
}
