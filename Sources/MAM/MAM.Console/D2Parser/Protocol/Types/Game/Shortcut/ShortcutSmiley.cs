namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ShortcutSmiley : Shortcut
	{
		public new const short Id = 6309;
		public override short TypeId => Id;
		public ushort smileyId { get; set; }

		public ShortcutSmiley(sbyte slot, ushort smileyId)
		{
			this.slot = slot;
			this.smileyId = smileyId;
		}

		public ShortcutSmiley() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(smileyId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			smileyId = reader.ReadVarUShort();
		}

	}
}
