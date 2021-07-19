namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class UpdateMountBooleanCharacteristic : UpdateMountCharacteristic
	{
		public new const short Id = 1327;
		public override short TypeId => Id;
		public bool value { get; set; }

		public UpdateMountBooleanCharacteristic(sbyte type, bool value)
		{
			this.type = type;
			this.value = value;
		}

		public UpdateMountBooleanCharacteristic() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteBoolean(value);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			value = reader.ReadBoolean();
		}

	}
}
