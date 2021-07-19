namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterCharacteristicValue : CharacterCharacteristic
	{
		public new const short Id = 4252;
		public override short TypeId => Id;
		public int total { get; set; }

		public CharacterCharacteristicValue(short characteristicId, int total)
		{
			this.characteristicId = characteristicId;
			this.total = total;
		}

		public CharacterCharacteristicValue() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(total);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			total = reader.ReadInt();
		}

	}
}
