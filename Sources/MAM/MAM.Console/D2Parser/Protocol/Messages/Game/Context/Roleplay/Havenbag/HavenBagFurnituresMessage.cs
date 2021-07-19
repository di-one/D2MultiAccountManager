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
	public class HavenBagFurnituresMessage : NetworkMessage
	{
		public const uint Id = 5258;
		public override uint MessageId => Id;
		public IEnumerable<HavenBagFurnitureInformation> furnituresInfos { get; set; }

		public HavenBagFurnituresMessage(IEnumerable<HavenBagFurnitureInformation> furnituresInfos)
		{
			this.furnituresInfos = furnituresInfos;
		}

		public HavenBagFurnituresMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)furnituresInfos.Count());
			foreach (var objectToSend in furnituresInfos)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var furnituresInfosCount = reader.ReadUShort();
			var furnituresInfos_ = new HavenBagFurnitureInformation[furnituresInfosCount];
			for (var furnituresInfosIndex = 0; furnituresInfosIndex < furnituresInfosCount; furnituresInfosIndex++)
			{
				var objectToAdd = new HavenBagFurnitureInformation();
				objectToAdd.Deserialize(reader);
				furnituresInfos_[furnituresInfosIndex] = objectToAdd;
			}
			furnituresInfos = furnituresInfos_;
		}

	}
}
