namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeCraftResultWithObjectIdMessage : ExchangeCraftResultMessage
	{
		public new const uint Id = 3459;
		public override uint MessageId => Id;
		public ushort objectGenericId { get; set; }

		public ExchangeCraftResultWithObjectIdMessage(sbyte craftResult, ushort objectGenericId)
		{
			this.craftResult = craftResult;
			this.objectGenericId = objectGenericId;
		}

		public ExchangeCraftResultWithObjectIdMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(objectGenericId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			objectGenericId = reader.ReadVarUShort();
		}

	}
}
