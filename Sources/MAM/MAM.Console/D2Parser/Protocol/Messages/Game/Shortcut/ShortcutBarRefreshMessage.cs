namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ShortcutBarRefreshMessage : NetworkMessage
	{
		public const uint Id = 6320;
		public override uint MessageId => Id;
		public sbyte barType { get; set; }
		public Shortcut shortcut { get; set; }

		public ShortcutBarRefreshMessage(sbyte barType, Shortcut shortcut)
		{
			this.barType = barType;
			this.shortcut = shortcut;
		}

		public ShortcutBarRefreshMessage() { }

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
