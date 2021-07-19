namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MountDataMessage : NetworkMessage
	{
		public const uint Id = 7591;
		public override uint MessageId => Id;
		public MountClientData mountData { get; set; }

		public MountDataMessage(MountClientData mountData)
		{
			this.mountData = mountData;
		}

		public MountDataMessage() { }

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
