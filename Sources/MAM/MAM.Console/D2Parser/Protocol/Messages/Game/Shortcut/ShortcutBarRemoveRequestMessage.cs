namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ShortcutBarRemoveRequestMessage : NetworkMessage
	{
		public const uint Id = 938;
		public override uint MessageId => Id;
		public sbyte barType { get; set; }
		public sbyte slot { get; set; }

		public ShortcutBarRemoveRequestMessage(sbyte barType, sbyte slot)
		{
			this.barType = barType;
			this.slot = slot;
		}

		public ShortcutBarRemoveRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(barType);
			writer.WriteSByte(slot);
		}

		public override void Deserialize(IDataReader reader)
		{
			barType = reader.ReadSByte();
			slot = reader.ReadSByte();
		}

	}
}
