namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MountRenamedMessage : NetworkMessage
	{
		public const uint Id = 197;
		public override uint MessageId => Id;
		public int mountId { get; set; }
		public string name { get; set; }

		public MountRenamedMessage(int mountId, string name)
		{
			this.mountId = mountId;
			this.name = name;
		}

		public MountRenamedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarInt(mountId);
			writer.WriteUTF(name);
		}

		public override void Deserialize(IDataReader reader)
		{
			mountId = reader.ReadVarInt();
			name = reader.ReadUTF();
		}

	}
}
