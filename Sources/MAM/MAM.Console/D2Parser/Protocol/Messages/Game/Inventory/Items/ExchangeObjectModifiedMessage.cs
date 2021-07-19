namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeObjectModifiedMessage : ExchangeObjectMessage
	{
		public new const uint Id = 4834;
		public override uint MessageId => Id;
		public ObjectItem @object { get; set; }

		public ExchangeObjectModifiedMessage(bool remote, ObjectItem @object)
		{
			this.remote = remote;
			this.@object = @object;
		}

		public ExchangeObjectModifiedMessage() { }

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
