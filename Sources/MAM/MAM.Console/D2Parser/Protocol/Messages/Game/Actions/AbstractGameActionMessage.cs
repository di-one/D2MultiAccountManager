namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AbstractGameActionMessage : NetworkMessage
	{
		public const uint Id = 8538;
		public override uint MessageId => Id;
		public ushort actionId { get; set; }
		public double sourceId { get; set; }

		public AbstractGameActionMessage(ushort actionId, double sourceId)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
		}

		public AbstractGameActionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(actionId);
			writer.WriteDouble(sourceId);
		}

		public override void Deserialize(IDataReader reader)
		{
			actionId = reader.ReadVarUShort();
			sourceId = reader.ReadDouble();
		}

	}
}
