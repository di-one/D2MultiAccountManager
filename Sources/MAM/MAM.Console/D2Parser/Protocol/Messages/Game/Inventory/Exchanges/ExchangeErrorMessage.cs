namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeErrorMessage : NetworkMessage
	{
		public const uint Id = 9976;
		public override uint MessageId => Id;
		public sbyte errorType { get; set; }

		public ExchangeErrorMessage(sbyte errorType)
		{
			this.errorType = errorType;
		}

		public ExchangeErrorMessage() { }

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
