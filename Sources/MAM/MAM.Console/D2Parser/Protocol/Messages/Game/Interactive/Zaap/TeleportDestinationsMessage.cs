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
	public class TeleportDestinationsMessage : NetworkMessage
	{
		public const uint Id = 2128;
		public override uint MessageId => Id;
		public sbyte type { get; set; }
		public IEnumerable<TeleportDestination> destinations { get; set; }

		public TeleportDestinationsMessage(sbyte type, IEnumerable<TeleportDestination> destinations)
		{
			this.type = type;
			this.destinations = destinations;
		}

		public TeleportDestinationsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(type);
			writer.WriteShort((short)destinations.Count());
			foreach (var objectToSend in destinations)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			type = reader.ReadSByte();
			var destinationsCount = reader.ReadUShort();
			var destinations_ = new TeleportDestination[destinationsCount];
			for (var destinationsIndex = 0; destinationsIndex < destinationsCount; destinationsIndex++)
			{
				var objectToAdd = new TeleportDestination();
				objectToAdd.Deserialize(reader);
				destinations_[destinationsIndex] = objectToAdd;
			}
			destinations = destinations_;
		}

	}
}
