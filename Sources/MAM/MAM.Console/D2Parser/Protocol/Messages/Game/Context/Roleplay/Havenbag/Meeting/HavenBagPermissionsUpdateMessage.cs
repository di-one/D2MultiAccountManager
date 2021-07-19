namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HavenBagPermissionsUpdateMessage : NetworkMessage
	{
		public const uint Id = 7931;
		public override uint MessageId => Id;
		public int permissions { get; set; }

		public HavenBagPermissionsUpdateMessage(int permissions)
		{
			this.permissions = permissions;
		}

		public HavenBagPermissionsUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(permissions);
		}

		public override void Deserialize(IDataReader reader)
		{
			permissions = reader.ReadInt();
		}

	}
}
