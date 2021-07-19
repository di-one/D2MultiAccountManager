namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameContextKickMessage : NetworkMessage
	{
		public const uint Id = 7025;
		public override uint MessageId => Id;
		public double targetId { get; set; }

		public GameContextKickMessage(double targetId)
		{
			this.targetId = targetId;
		}

		public GameContextKickMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(targetId);
		}

		public override void Deserialize(IDataReader reader)
		{
			targetId = reader.ReadDouble();
		}

	}
}
