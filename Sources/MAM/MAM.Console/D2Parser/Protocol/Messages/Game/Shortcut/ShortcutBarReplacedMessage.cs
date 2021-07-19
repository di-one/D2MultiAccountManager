namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ShortcutBarReplacedMessage : NetworkMessage
	{
		public const uint Id = 2820;
		public override uint MessageId => Id;
		public sbyte barType { get; set; }
		public Shortcut shortcut { get; set; }

		public ShortcutBarReplacedMessage(sbyte barType, Shortcut shortcut)
		{
			this.barType = barType;
			this.shortcut = shortcut;
		}

		public ShortcutBarReplacedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(barType);
			writer.WriteShort(shortcut.TypeId);
			shortcut.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			barType = reader.ReadSByte();
			shortcut = ProtocolTypeManager.GetInstance<Shortcut>(reader.ReadShort());
			shortcut.Deserialize(reader);
		}

	}
}
