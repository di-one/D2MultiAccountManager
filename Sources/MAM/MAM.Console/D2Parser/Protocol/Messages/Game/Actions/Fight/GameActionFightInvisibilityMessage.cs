namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightInvisibilityMessage : AbstractGameActionMessage
	{
		public new const uint Id = 4346;
		public override uint MessageId => Id;
		public double targetId { get; set; }
		public sbyte state { get; set; }

		public GameActionFightInvisibilityMessage(ushort actionId, double sourceId, double targetId, sbyte state)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.state = state;
		}

		public GameActionFightInvisibilityMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(targetId);
			writer.WriteSByte(state);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			targetId = reader.ReadDouble();
			state = reader.ReadSByte();
		}

	}
}
