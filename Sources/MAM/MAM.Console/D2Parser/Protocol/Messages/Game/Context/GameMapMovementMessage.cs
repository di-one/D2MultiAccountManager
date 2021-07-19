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
	public class GameMapMovementMessage : NetworkMessage
	{
		public const uint Id = 4500;
		public override uint MessageId => Id;
		public IEnumerable<short> keyMovements { get; set; }
		public short forcedDirection { get; set; }
		public double actorId { get; set; }

		public GameMapMovementMessage(IEnumerable<short> keyMovements, short forcedDirection, double actorId)
		{
			this.keyMovements = keyMovements;
			this.forcedDirection = forcedDirection;
			this.actorId = actorId;
		}

		public GameMapMovementMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)keyMovements.Count());
			foreach (var objectToSend in keyMovements)
            {
				writer.WriteShort(objectToSend);
			}
			writer.WriteShort(forcedDirection);
			writer.WriteDouble(actorId);
		}

		public override void Deserialize(IDataReader reader)
		{
			var keyMovementsCount = reader.ReadUShort();
			var keyMovements_ = new short[keyMovementsCount];
			for (var keyMovementsIndex = 0; keyMovementsIndex < keyMovementsCount; keyMovementsIndex++)
			{
				keyMovements_[keyMovementsIndex] = reader.ReadShort();
			}
			keyMovements = keyMovements_;
			forcedDirection = reader.ReadShort();
			actorId = reader.ReadDouble();
		}

	}
}
