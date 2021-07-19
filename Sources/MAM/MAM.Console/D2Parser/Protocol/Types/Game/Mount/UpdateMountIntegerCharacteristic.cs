namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class UpdateMountIntegerCharacteristic : UpdateMountCharacteristic
	{
		public new const short Id = 4747;
		public override short TypeId => Id;
		public int value { get; set; }

		public UpdateMountIntegerCharacteristic(sbyte type, int value)
		{
			this.type = type;
			this.value = value;
		}

		public UpdateMountIntegerCharacteristic() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(value);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			value = reader.ReadInt();
		}

	}
}
