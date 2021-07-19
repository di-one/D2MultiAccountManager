namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ShortcutEmote : Shortcut
	{
		public new const short Id = 2084;
		public override short TypeId => Id;
		public byte emoteId { get; set; }

		public ShortcutEmote(sbyte slot, byte emoteId)
		{
			this.slot = slot;
			this.emoteId = emoteId;
		}

		public ShortcutEmote() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteByte(emoteId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			emoteId = reader.ReadByte();
		}

	}
}
