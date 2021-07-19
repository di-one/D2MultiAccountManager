namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ClientUIOpenedByObjectMessage : ClientUIOpenedMessage
	{
		public new const uint Id = 6653;
		public override uint MessageId => Id;
		public uint uid { get; set; }

		public ClientUIOpenedByObjectMessage(sbyte type, uint uid)
		{
			this.type = type;
			this.uid = uid;
		}

		public ClientUIOpenedByObjectMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(uid);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			uid = reader.ReadVarUInt();
		}

	}
}
