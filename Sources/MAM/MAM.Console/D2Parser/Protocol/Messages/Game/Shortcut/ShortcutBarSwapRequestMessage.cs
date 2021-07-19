namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ShortcutBarSwapRequestMessage : NetworkMessage
	{
		public const uint Id = 2661;
		public override uint MessageId => Id;
		public sbyte barType { get; set; }
		public sbyte firstSlot { get; set; }
		public sbyte secondSlot { get; set; }

		public ShortcutBarSwapRequestMessage(sbyte barType, sbyte firstSlot, sbyte secondSlot)
		{
			this.barType = barType;
			this.firstSlot = firstSlot;
			this.secondSlot = secondSlot;
		}

		public ShortcutBarSwapRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(barType);
			writer.WriteSByte(firstSlot);
			writer.WriteSByte(secondSlot);
		}

		public override void Deserialize(IDataReader reader)
		{
			barType = reader.ReadSByte();
			firstSlot = reader.ReadSByte();
			secondSlot = reader.ReadSByte();
		}

	}
}
