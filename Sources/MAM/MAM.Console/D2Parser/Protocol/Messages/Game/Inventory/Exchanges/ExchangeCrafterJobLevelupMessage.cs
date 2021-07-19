namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeCrafterJobLevelupMessage : NetworkMessage
	{
		public const uint Id = 241;
		public override uint MessageId => Id;
		public byte crafterJobLevel { get; set; }

		public ExchangeCrafterJobLevelupMessage(byte crafterJobLevel)
		{
			this.crafterJobLevel = crafterJobLevel;
		}

		public ExchangeCrafterJobLevelupMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteByte(crafterJobLevel);
		}

		public override void Deserialize(IDataReader reader)
		{
			crafterJobLevel = reader.ReadByte();
		}

	}
}
