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
	public class ForgettableSpellDeleteMessage : NetworkMessage
	{
		public const uint Id = 9772;
		public override uint MessageId => Id;
		public sbyte reason { get; set; }
		public IEnumerable<int> spells { get; set; }

		public ForgettableSpellDeleteMessage(sbyte reason, IEnumerable<int> spells)
		{
			this.reason = reason;
			this.spells = spells;
		}

		public ForgettableSpellDeleteMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(reason);
			writer.WriteShort((short)spells.Count());
			foreach (var objectToSend in spells)
            {
				writer.WriteInt(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			reason = reader.ReadSByte();
			var spellsCount = reader.ReadUShort();
			var spells_ = new int[spellsCount];
			for (var spellsIndex = 0; spellsIndex < spellsCount; spellsIndex++)
			{
				spells_[spellsIndex] = reader.ReadInt();
			}
			spells = spells_;
		}

	}
}
