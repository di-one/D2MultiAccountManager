namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightActivateGlyphTrapMessage : AbstractGameActionMessage
	{
		public new const uint Id = 1091;
		public override uint MessageId => Id;
		public short markId { get; set; }
		public bool active { get; set; }

		public GameActionFightActivateGlyphTrapMessage(ushort actionId, double sourceId, short markId, bool active)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.markId = markId;
			this.active = active;
		}

		public GameActionFightActivateGlyphTrapMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(markId);
			writer.WriteBoolean(active);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			markId = reader.ReadShort();
			active = reader.ReadBoolean();
		}

	}
}
