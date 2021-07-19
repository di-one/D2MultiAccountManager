namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightMarkCellsMessage : AbstractGameActionMessage
	{
		public new const uint Id = 3605;
		public override uint MessageId => Id;
		public GameActionMark mark { get; set; }

		public GameActionFightMarkCellsMessage(ushort actionId, double sourceId, GameActionMark mark)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.mark = mark;
		}

		public GameActionFightMarkCellsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			mark.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			mark = new GameActionMark();
			mark.Deserialize(reader);
		}

	}
}
