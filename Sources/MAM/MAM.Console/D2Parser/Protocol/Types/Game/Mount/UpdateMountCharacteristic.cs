namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class UpdateMountCharacteristic
	{
		public const short Id  = 5898;
		public virtual short TypeId => Id;
		public sbyte type { get; set; }

		public UpdateMountCharacteristic(sbyte type)
		{
			this.type = type;
		}

		public UpdateMountCharacteristic() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(type);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			type = reader.ReadSByte();
		}

	}
}
