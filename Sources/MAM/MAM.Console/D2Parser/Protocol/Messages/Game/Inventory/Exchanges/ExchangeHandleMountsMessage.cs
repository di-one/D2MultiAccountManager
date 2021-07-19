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
	public class ExchangeHandleMountsMessage : NetworkMessage
	{
		public const uint Id = 5462;
		public override uint MessageId => Id;
		public sbyte actionType { get; set; }
		public IEnumerable<uint> ridesId { get; set; }

		public ExchangeHandleMountsMessage(sbyte actionType, IEnumerable<uint> ridesId)
		{
			this.actionType = actionType;
			this.ridesId = ridesId;
		}

		public ExchangeHandleMountsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(actionType);
			writer.WriteShort((short)ridesId.Count());
			foreach (var objectToSend in ridesId)
            {
				writer.WriteVarUInt(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			actionType = reader.ReadSByte();
			var ridesIdCount = reader.ReadUShort();
			var ridesId_ = new uint[ridesIdCount];
			for (var ridesIdIndex = 0; ridesIdIndex < ridesIdCount; ridesIdIndex++)
			{
				ridesId_[ridesIdIndex] = reader.ReadVarUInt();
			}
			ridesId = ridesId_;
		}

	}
}
