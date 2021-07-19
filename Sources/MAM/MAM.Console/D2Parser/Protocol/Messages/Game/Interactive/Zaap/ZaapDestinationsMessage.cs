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
	public class ZaapDestinationsMessage : TeleportDestinationsMessage
	{
		public new const uint Id = 1847;
		public override uint MessageId => Id;
		public double spawnMapId { get; set; }

		public ZaapDestinationsMessage(sbyte type, IEnumerable<TeleportDestination> destinations, double spawnMapId)
		{
			this.type = type;
			this.destinations = destinations;
			this.spawnMapId = spawnMapId;
		}

		public ZaapDestinationsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(spawnMapId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			spawnMapId = reader.ReadDouble();
		}

	}
}
