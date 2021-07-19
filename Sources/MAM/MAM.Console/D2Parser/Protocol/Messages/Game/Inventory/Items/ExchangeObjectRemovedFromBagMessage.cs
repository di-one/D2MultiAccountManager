namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeObjectRemovedFromBagMessage : ExchangeObjectMessage
	{
		public new const uint Id = 9861;
		public override uint MessageId => Id;
		public uint objectUID { get; set; }

		public ExchangeObjectRemovedFromBagMessage(bool remote, uint objectUID)
		{
			this.remote = remote;
			this.objectUID = objectUID;
		}

		public ExchangeObjectRemovedFromBagMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(objectUID);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			objectUID = reader.ReadVarUInt();
		}

	}
}
