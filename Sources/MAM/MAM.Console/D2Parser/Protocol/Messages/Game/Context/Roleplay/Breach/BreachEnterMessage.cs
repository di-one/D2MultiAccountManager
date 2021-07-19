namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BreachEnterMessage : NetworkMessage
	{
		public const uint Id = 3363;
		public override uint MessageId => Id;
		public ulong owner { get; set; }

		public BreachEnterMessage(ulong owner)
		{
			this.owner = owner;
		}

		public BreachEnterMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(owner);
		}

		public override void Deserialize(IDataReader reader)
		{
			owner = reader.ReadVarULong();
		}

	}
}
