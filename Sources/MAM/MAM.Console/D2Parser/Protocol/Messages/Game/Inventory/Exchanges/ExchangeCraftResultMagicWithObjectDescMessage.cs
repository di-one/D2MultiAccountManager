namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeCraftResultMagicWithObjectDescMessage : ExchangeCraftResultWithObjectDescMessage
	{
		public new const uint Id = 4186;
		public override uint MessageId => Id;
		public sbyte magicPoolStatus { get; set; }

		public ExchangeCraftResultMagicWithObjectDescMessage(sbyte craftResult, ObjectItemNotInContainer objectInfo, sbyte magicPoolStatus)
		{
			this.craftResult = craftResult;
			this.objectInfo = objectInfo;
			this.magicPoolStatus = magicPoolStatus;
		}

		public ExchangeCraftResultMagicWithObjectDescMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(magicPoolStatus);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			magicPoolStatus = reader.ReadSByte();
		}

	}
}
