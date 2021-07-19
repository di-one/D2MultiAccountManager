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
	public class HelloConnectMessage : NetworkMessage
	{
		public const uint Id = 1030;
		public override uint MessageId => Id;
		public string salt { get; set; }
		public IEnumerable<sbyte> key { get; set; }

		public HelloConnectMessage(string salt, IEnumerable<sbyte> key)
		{
			this.salt = salt;
			this.key = key;
		}

		public HelloConnectMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(salt);
			writer.WriteVarInt(key.Count());
			foreach (var objectToSend in key)
            {
				writer.WriteSByte(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			salt = reader.ReadUTF();
			var keyCount = reader.ReadVarInt();
			var key_ = new sbyte[keyCount];
			for (var keyIndex = 0; keyIndex < keyCount; keyIndex++)
			{
				key_[keyIndex] = reader.ReadSByte();
			}
			key = key_;
		}

	}
}
