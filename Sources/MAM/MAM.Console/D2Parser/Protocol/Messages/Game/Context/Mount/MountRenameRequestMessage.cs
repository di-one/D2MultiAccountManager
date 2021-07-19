namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MountRenameRequestMessage : NetworkMessage
	{
		public const uint Id = 8412;
		public override uint MessageId => Id;
		public string name { get; set; }
		public int mountId { get; set; }

		public MountRenameRequestMessage(string name, int mountId)
		{
			this.name = name;
			this.mountId = mountId;
		}

		public MountRenameRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(name);
			writer.WriteVarInt(mountId);
		}

		public override void Deserialize(IDataReader reader)
		{
			name = reader.ReadUTF();
			mountId = reader.ReadVarInt();
		}

	}
}
