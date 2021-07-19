namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildPaddockTeleportRequestMessage : NetworkMessage
	{
		public const uint Id = 3688;
		public override uint MessageId => Id;
		public double paddockId { get; set; }

		public GuildPaddockTeleportRequestMessage(double paddockId)
		{
			this.paddockId = paddockId;
		}

		public GuildPaddockTeleportRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(paddockId);
		}

		public override void Deserialize(IDataReader reader)
		{
			paddockId = reader.ReadDouble();
		}

	}
}
