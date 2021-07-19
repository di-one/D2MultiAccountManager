namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterCharacteristics
	{
		public const short Id  = 8957;
		public virtual short TypeId => Id;
		public IEnumerable<CharacterCharacteristic> characteristics { get; set; }

		public CharacterCharacteristics(IEnumerable<CharacterCharacteristic> characteristics)
		{
			this.characteristics = characteristics;
		}

		public CharacterCharacteristics() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)characteristics.Count());
			foreach (var objectToSend in characteristics)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			var characteristicsCount = reader.ReadUShort();
			var characteristics_ = new CharacterCharacteristic[characteristicsCount];
			for (var characteristicsIndex = 0; characteristicsIndex < characteristicsCount; characteristicsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<CharacterCharacteristic>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				characteristics_[characteristicsIndex] = objectToAdd;
			}
			characteristics = characteristics_;
		}

	}
}
