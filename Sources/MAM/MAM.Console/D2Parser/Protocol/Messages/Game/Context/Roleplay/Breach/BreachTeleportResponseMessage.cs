namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BreachTeleportResponseMessage : NetworkMessage
	{
		public const uint Id = 9007;
		public override uint MessageId => Id;
		public bool teleported { get; set; }

		public BreachTeleportResponseMessage(bool teleported)
		{
			this.teleported = teleported;
		}

		public BreachTeleportResponseMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(teleported);
		}

		public override void Deserialize(IDataReader reader)
		{
			teleported = reader.ReadBoolean();
		}

	}
}
