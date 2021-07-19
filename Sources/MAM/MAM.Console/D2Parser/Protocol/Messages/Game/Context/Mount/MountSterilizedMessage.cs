namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MountSterilizedMessage : NetworkMessage
	{
		public const uint Id = 8630;
		public override uint MessageId => Id;
		public int mountId { get; set; }

		public MountSterilizedMessage(int mountId)
		{
			this.mountId = mountId;
		}

		public MountSterilizedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarInt(mountId);
		}

		public override void Deserialize(IDataReader reader)
		{
			mountId = reader.ReadVarInt();
		}

	}
}
