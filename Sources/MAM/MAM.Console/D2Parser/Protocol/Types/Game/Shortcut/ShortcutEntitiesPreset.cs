﻿namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ShortcutEntitiesPreset : Shortcut
	{
		public new const short Id = 5484;
		public override short TypeId => Id;
		public short presetId { get; set; }

		public ShortcutEntitiesPreset(sbyte slot, short presetId)
		{
			this.slot = slot;
			this.presetId = presetId;
		}

		public ShortcutEntitiesPreset() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(presetId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			presetId = reader.ReadShort();
		}

	}
}
