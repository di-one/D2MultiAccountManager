namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PlayerStatusUpdateRequestMessage : NetworkMessage
	{
		public const uint Id = 9100;
		public override uint MessageId => Id;
		public PlayerStatus status { get; set; }

		public PlayerStatusUpdateRequestMessage(PlayerStatus status)
		{
			this.status = status;
		}

		public PlayerStatusUpdateRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(status.TypeId);
			status.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
			status.Deserialize(reader);
		}

	}
}
