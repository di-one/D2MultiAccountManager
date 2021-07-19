namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameContextMoveMultipleElementsMessage : NetworkMessage
	{
		public const uint Id = 190;
		public override uint MessageId => Id;
		public IEnumerable<EntityMovementInformations> movements { get; set; }

		public GameContextMoveMultipleElementsMessage(IEnumerable<EntityMovementInformations> movements)
		{
			this.movements = movements;
		}

		public GameContextMoveMultipleElementsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)movements.Count());
			foreach (var objectToSend in movements)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var movementsCount = reader.ReadUShort();
			var movements_ = new EntityMovementInformations[movementsCount];
			for (var movementsIndex = 0; movementsIndex < movementsCount; movementsIndex++)
			{
				var objectToAdd = new EntityMovementInformations();
				objectToAdd.Deserialize(reader);
				movements_[movementsIndex] = objectToAdd;
			}
			movements = movements_;
		}

	}
}
