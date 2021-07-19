namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BreachKickRequestMessage : NetworkMessage
	{
		public const uint Id = 6248;
		public override uint MessageId => Id;
		public ulong target { get; set; }

		public BreachKickRequestMessage(ulong target)
		{
			this.target = target;
		}

		public BreachKickRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(target);
		}

		public override void Deserialize(IDataReader reader)
		{
			target = reader.ReadVarULong();
		}

	}
}
