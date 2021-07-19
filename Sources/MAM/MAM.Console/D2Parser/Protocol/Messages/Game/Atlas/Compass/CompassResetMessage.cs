namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CompassResetMessage : NetworkMessage
	{
		public const uint Id = 1700;
		public override uint MessageId => Id;
		public sbyte type { get; set; }

		public CompassResetMessage(sbyte type)
		{
			this.type = type;
		}

		public CompassResetMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(type);
		}

		public override void Deserialize(IDataReader reader)
		{
			type = reader.ReadSByte();
		}

	}
}
