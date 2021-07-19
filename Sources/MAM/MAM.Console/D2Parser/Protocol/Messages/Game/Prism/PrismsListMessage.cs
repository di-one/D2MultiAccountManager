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
	public class PrismsListMessage : NetworkMessage
	{
		public const uint Id = 6207;
		public override uint MessageId => Id;
		public IEnumerable<PrismSubareaEmptyInfo> prisms { get; set; }

		public PrismsListMessage(IEnumerable<PrismSubareaEmptyInfo> prisms)
		{
			this.prisms = prisms;
		}

		public PrismsListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)prisms.Count());
			foreach (var objectToSend in prisms)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var prismsCount = reader.ReadUShort();
			var prisms_ = new PrismSubareaEmptyInfo[prismsCount];
			for (var prismsIndex = 0; prismsIndex < prismsCount; prismsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<PrismSubareaEmptyInfo>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				prisms_[prismsIndex] = objectToAdd;
			}
			prisms = prisms_;
		}

	}
}
