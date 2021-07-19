namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterCharacteristic
	{
		public const short Id  = 2983;
		public virtual short TypeId => Id;
		public short characteristicId { get; set; }

		public CharacterCharacteristic(short characteristicId)
		{
			this.characteristicId = characteristicId;
		}

		public CharacterCharacteristic() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteShort(characteristicId);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			characteristicId = reader.ReadShort();
		}

	}
}
