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
	public class KnownZaapListMessage : NetworkMessage
	{
		public const uint Id = 9689;
		public override uint MessageId => Id;
		public IEnumerable<double> destinations { get; set; }

		public KnownZaapListMessage(IEnumerable<double> destinations)
		{
			this.destinations = destinations;
		}

		public KnownZaapListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)destinations.Count());
			foreach (var objectToSend in destinations)
            {
				writer.WriteDouble(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var destinationsCount = reader.ReadUShort();
			var destinations_ = new double[destinationsCount];
			for (var destinationsIndex = 0; destinationsIndex < destinationsCount; destinationsIndex++)
			{
				destinations_[destinationsIndex] = reader.ReadDouble();
			}
			destinations = destinations_;
		}

	}
}
