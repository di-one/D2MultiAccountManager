namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeCraftResultWithObjectDescMessage : ExchangeCraftResultMessage
	{
		public new const uint Id = 5535;
		public override uint MessageId => Id;
		public ObjectItemNotInContainer objectInfo { get; set; }

		public ExchangeCraftResultWithObjectDescMessage(sbyte craftResult, ObjectItemNotInContainer objectInfo)
		{
			this.craftResult = craftResult;
			this.objectInfo = objectInfo;
		}

		public ExchangeCraftResultWithObjectDescMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			objectInfo.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			objectInfo = new ObjectItemNotInContainer();
			objectInfo.Deserialize(reader);
		}

	}
}
