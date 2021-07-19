namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameContextMoveElementMessage : NetworkMessage
	{
		public const uint Id = 2199;
		public override uint MessageId => Id;
		public EntityMovementInformations movement { get; set; }

		public GameContextMoveElementMessage(EntityMovementInformations movement)
		{
			this.movement = movement;
		}

		public GameContextMoveElementMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			movement.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			movement = new EntityMovementInformations();
			movement.Deserialize(reader);
		}

	}
}
