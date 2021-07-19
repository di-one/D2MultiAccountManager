namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectUseMultipleMessage : ObjectUseMessage
	{
		public new const uint Id = 3993;
		public override uint MessageId => Id;
		public uint quantity { get; set; }

		public ObjectUseMultipleMessage(uint objectUID, uint quantity)
		{
			this.objectUID = objectUID;
			this.quantity = quantity;
		}

		public ObjectUseMultipleMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(quantity);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			quantity = reader.ReadVarUInt();
		}

	}
}
