namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameContextRemoveElementMessage : NetworkMessage
	{
		public const uint Id = 6263;
		public override uint MessageId => Id;
		public double objectId { get; set; }

		public GameContextRemoveElementMessage(double objectId)
		{
			this.objectId = objectId;
		}

		public GameContextRemoveElementMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(objectId);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadDouble();
		}

	}
}
