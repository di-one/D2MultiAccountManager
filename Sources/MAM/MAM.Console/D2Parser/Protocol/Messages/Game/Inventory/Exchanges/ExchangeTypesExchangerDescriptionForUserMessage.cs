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
	public class ExchangeTypesExchangerDescriptionForUserMessage : NetworkMessage
	{
		public const uint Id = 1423;
		public override uint MessageId => Id;
		public int objectType { get; set; }
		public IEnumerable<uint> typeDescription { get; set; }

		public ExchangeTypesExchangerDescriptionForUserMessage(int objectType, IEnumerable<uint> typeDescription)
		{
			this.objectType = objectType;
			this.typeDescription = typeDescription;
		}

		public ExchangeTypesExchangerDescriptionForUserMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(objectType);
			writer.WriteShort((short)typeDescription.Count());
			foreach (var objectToSend in typeDescription)
            {
				writer.WriteVarUInt(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			objectType = reader.ReadInt();
			var typeDescriptionCount = reader.ReadUShort();
			var typeDescription_ = new uint[typeDescriptionCount];
			for (var typeDescriptionIndex = 0; typeDescriptionIndex < typeDescriptionCount; typeDescriptionIndex++)
			{
				typeDescription_[typeDescriptionIndex] = reader.ReadVarUInt();
			}
			typeDescription = typeDescription_;
		}

	}
}
