namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightDispellMessage : AbstractGameActionMessage
	{
		public new const uint Id = 3834;
		public override uint MessageId => Id;
		public double targetId { get; set; }
		public bool verboseCast { get; set; }

		public GameActionFightDispellMessage(ushort actionId, double sourceId, double targetId, bool verboseCast)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.verboseCast = verboseCast;
		}

		public GameActionFightDispellMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(targetId);
			writer.WriteBoolean(verboseCast);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			targetId = reader.ReadDouble();
			verboseCast = reader.ReadBoolean();
		}

	}
}
