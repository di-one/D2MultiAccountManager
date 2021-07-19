namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ServerSessionConstantString : ServerSessionConstant
	{
		public new const short Id = 9726;
		public override short TypeId => Id;
		public string value { get; set; }

		public ServerSessionConstantString(ushort objectId, string value)
		{
			this.objectId = objectId;
			this.value = value;
		}

		public ServerSessionConstantString() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(value);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			value = reader.ReadUTF();
		}

	}
}
