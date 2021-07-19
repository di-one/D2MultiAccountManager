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
	public class ServerOptionalFeaturesMessage : NetworkMessage
	{
		public const uint Id = 4257;
		public override uint MessageId => Id;
		public IEnumerable<byte> features { get; set; }

		public ServerOptionalFeaturesMessage(IEnumerable<byte> features)
		{
			this.features = features;
		}

		public ServerOptionalFeaturesMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)features.Count());
			foreach (var objectToSend in features)
            {
				writer.WriteByte(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var featuresCount = reader.ReadUShort();
			var features_ = new byte[featuresCount];
			for (var featuresIndex = 0; featuresIndex < featuresCount; featuresIndex++)
			{
				features_[featuresIndex] = reader.ReadByte();
			}
			features = features_;
		}

	}
}
