namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CurrentMapInstanceMessage : CurrentMapMessage
	{
		public new const uint Id = 5592;
		public override uint MessageId => Id;
		public double instantiatedMapId { get; set; }

		public CurrentMapInstanceMessage(double mapId, string mapKey, double instantiatedMapId)
		{
			this.mapId = mapId;
			this.mapKey = mapKey;
			this.instantiatedMapId = instantiatedMapId;
		}

		public CurrentMapInstanceMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(instantiatedMapId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			instantiatedMapId = reader.ReadDouble();
		}

	}
}
