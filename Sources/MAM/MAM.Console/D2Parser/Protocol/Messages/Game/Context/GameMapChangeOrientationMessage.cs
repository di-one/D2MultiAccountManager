namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameMapChangeOrientationMessage : NetworkMessage
	{
		public const uint Id = 2457;
		public override uint MessageId => Id;
		public ActorOrientation orientation { get; set; }

		public GameMapChangeOrientationMessage(ActorOrientation orientation)
		{
			this.orientation = orientation;
		}

		public GameMapChangeOrientationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			orientation.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			orientation = new ActorOrientation();
			orientation.Deserialize(reader);
		}

	}
}
