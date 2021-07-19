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
	public class HavenBagPackListMessage : NetworkMessage
	{
		public const uint Id = 8756;
		public override uint MessageId => Id;
		public IEnumerable<sbyte> packIds { get; set; }

		public HavenBagPackListMessage(IEnumerable<sbyte> packIds)
		{
			this.packIds = packIds;
		}

		public HavenBagPackListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)packIds.Count());
			foreach (var objectToSend in packIds)
            {
				writer.WriteSByte(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var packIdsCount = reader.ReadUShort();
			var packIds_ = new sbyte[packIdsCount];
			for (var packIdsIndex = 0; packIdsIndex < packIdsCount; packIdsIndex++)
			{
				packIds_[packIdsIndex] = reader.ReadSByte();
			}
			packIds = packIds_;
		}

	}
}
