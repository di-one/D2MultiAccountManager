namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HavenBagPermissionsUpdateRequestMessage : NetworkMessage
	{
		public const uint Id = 9737;
		public override uint MessageId => Id;
		public int permissions { get; set; }

		public HavenBagPermissionsUpdateRequestMessage(int permissions)
		{
			this.permissions = permissions;
		}

		public HavenBagPermissionsUpdateRequestMessage() { }

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
