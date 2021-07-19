namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameMapChangeOrientationRequestMessage : NetworkMessage
	{
		public const uint Id = 339;
		public override uint MessageId => Id;
		public sbyte direction { get; set; }

		public GameMapChangeOrientationRequestMessage(sbyte direction)
		{
			this.direction = direction;
		}

		public GameMapChangeOrientationRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(direction);
		}

		public override void Deserialize(IDataReader reader)
		{
			direction = reader.ReadSByte();
		}

	}
}
