namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MountEquipedErrorMessage : NetworkMessage
	{
		public const uint Id = 1488;
		public override uint MessageId => Id;
		public sbyte errorType { get; set; }

		public MountEquipedErrorMessage(sbyte errorType)
		{
			this.errorType = errorType;
		}

		public MountEquipedErrorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(errorType);
		}

		public override void Deserialize(IDataReader reader)
		{
			errorType = reader.ReadSByte();
		}

	}
}
