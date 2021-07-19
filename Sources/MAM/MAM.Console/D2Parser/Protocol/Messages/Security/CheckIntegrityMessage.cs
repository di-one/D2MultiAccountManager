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
	public class CheckIntegrityMessage : NetworkMessage
	{
		public const uint Id = 5541;
		public override uint MessageId => Id;
		public IEnumerable<sbyte> data { get; set; }

		public CheckIntegrityMessage(IEnumerable<sbyte> data)
		{
			this.data = data;
		}

		public CheckIntegrityMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarInt(data.Count());
			foreach (var objectToSend in data)
            {
				writer.WriteSByte(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var dataCount = reader.ReadVarInt();
			var data_ = new sbyte[dataCount];
			for (var dataIndex = 0; dataIndex < dataCount; dataIndex++)
			{
				data_[dataIndex] = reader.ReadSByte();
			}
			data = data_;
		}

	}
}
