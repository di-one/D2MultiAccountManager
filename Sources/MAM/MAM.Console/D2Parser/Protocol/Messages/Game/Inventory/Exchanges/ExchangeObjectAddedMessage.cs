namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeObjectAddedMessage : ExchangeObjectMessage
	{
		public new const uint Id = 8239;
		public override uint MessageId => Id;
		public ObjectItem @object { get; set; }

		public ExchangeObjectAddedMessage(bool remote, ObjectItem @object)
		{
			this.remote = remote;
			this.@object = @object;
		}

		public ExchangeObjectAddedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			@object.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			@object = new ObjectItem();
			@object.Deserialize(reader);
		}

	}
}
