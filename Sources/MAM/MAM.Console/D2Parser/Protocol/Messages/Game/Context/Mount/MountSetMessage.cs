namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MountSetMessage : NetworkMessage
	{
		public const uint Id = 7501;
		public override uint MessageId => Id;
		public MountClientData mountData { get; set; }

		public MountSetMessage(MountClientData mountData)
		{
			this.mountData = mountData;
		}

		public MountSetMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			mountData.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			mountData = new MountClientData();
			mountData.Deserialize(reader);
		}

	}
}
