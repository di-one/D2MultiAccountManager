namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PrismUseRequestMessage : NetworkMessage
	{
		public const uint Id = 4515;
		public override uint MessageId => Id;
		public sbyte moduleToUse { get; set; }

		public PrismUseRequestMessage(sbyte moduleToUse)
		{
			this.moduleToUse = moduleToUse;
		}

		public PrismUseRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(moduleToUse);
		}

		public override void Deserialize(IDataReader reader)
		{
			moduleToUse = reader.ReadSByte();
		}

	}
}
