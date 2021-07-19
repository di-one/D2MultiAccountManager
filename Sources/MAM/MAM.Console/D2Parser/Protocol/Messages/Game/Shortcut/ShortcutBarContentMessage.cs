namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ShortcutBarContentMessage : NetworkMessage
	{
		public const uint Id = 9017;
		public override uint MessageId => Id;
		public sbyte barType { get; set; }
		public IEnumerable<Shortcut> shortcuts { get; set; }

		public ShortcutBarContentMessage(sbyte barType, IEnumerable<Shortcut> shortcuts)
		{
			this.barType = barType;
			this.shortcuts = shortcuts;
		}

		public ShortcutBarContentMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(barType);
			writer.WriteShort((short)shortcuts.Count());
			foreach (var objectToSend in shortcuts)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			barType = reader.ReadSByte();
			var shortcutsCount = reader.ReadUShort();
			var shortcuts_ = new Shortcut[shortcutsCount];
			for (var shortcutsIndex = 0; shortcutsIndex < shortcutsCount; shortcutsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<Shortcut>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				shortcuts_[shortcutsIndex] = objectToAdd;
			}
			shortcuts = shortcuts_;
		}

	}
}
