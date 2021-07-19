namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameContextRemoveElementWithEventMessage : GameContextRemoveElementMessage
	{
		public new const uint Id = 7176;
		public override uint MessageId => Id;
		public sbyte elementEventId { get; set; }

		public GameContextRemoveElementWithEventMessage(double objectId, sbyte elementEventId)
		{
			this.objectId = objectId;
			this.elementEventId = elementEventId;
		}

		public GameContextRemoveElementWithEventMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(elementEventId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			elementEventId = reader.ReadSByte();
		}

	}
}
