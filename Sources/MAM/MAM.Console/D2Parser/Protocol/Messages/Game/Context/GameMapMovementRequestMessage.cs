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
	public class GameMapMovementRequestMessage : NetworkMessage
	{
		public const uint Id = 1780;
		public override uint MessageId => Id;
		public IEnumerable<short> keyMovements { get; set; }
		public double mapId { get; set; }

		public GameMapMovementRequestMessage(IEnumerable<short> keyMovements, double mapId)
		{
			this.keyMovements = keyMovements;
			this.mapId = mapId;
		}

		public GameMapMovementRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)keyMovements.Count());
			foreach (var objectToSend in keyMovements)
            {
				writer.WriteShort(objectToSend);
			}
			writer.WriteDouble(mapId);
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
			mapId = reader.ReadDouble();
		}

	}
}
