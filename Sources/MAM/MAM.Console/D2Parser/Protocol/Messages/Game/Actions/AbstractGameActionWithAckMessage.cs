namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AbstractGameActionWithAckMessage : AbstractGameActionMessage
	{
		public new const uint Id = 4833;
		public override uint MessageId => Id;
		public short waitAckId { get; set; }

		public AbstractGameActionWithAckMessage(ushort actionId, double sourceId, short waitAckId)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.waitAckId = waitAckId;
		}

		public AbstractGameActionWithAckMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(waitAckId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			waitAckId = reader.ReadShort();
		}

	}
}
