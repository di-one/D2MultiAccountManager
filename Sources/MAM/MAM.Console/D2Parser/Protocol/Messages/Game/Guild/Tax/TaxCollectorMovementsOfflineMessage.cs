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
	public class TaxCollectorMovementsOfflineMessage : NetworkMessage
	{
		public const uint Id = 1715;
		public override uint MessageId => Id;
		public IEnumerable<TaxCollectorMovement> movements { get; set; }

		public TaxCollectorMovementsOfflineMessage(IEnumerable<TaxCollectorMovement> movements)
		{
			this.movements = movements;
		}

		public TaxCollectorMovementsOfflineMessage() { }

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
			var movements_ = new TaxCollectorMovement[movementsCount];
			for (var movementsIndex = 0; movementsIndex < movementsCount; movementsIndex++)
			{
				var objectToAdd = new TaxCollectorMovement();
				objectToAdd.Deserialize(reader);
				movements_[movementsIndex] = objectToAdd;
			}
			movements = movements_;
		}

	}
}
