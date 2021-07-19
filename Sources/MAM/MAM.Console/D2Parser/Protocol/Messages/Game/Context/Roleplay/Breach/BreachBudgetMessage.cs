namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BreachBudgetMessage : NetworkMessage
	{
		public const uint Id = 1748;
		public override uint MessageId => Id;
		public uint bugdet { get; set; }

		public BreachBudgetMessage(uint bugdet)
		{
			this.bugdet = bugdet;
		}

		public BreachBudgetMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(bugdet);
		}

		public override void Deserialize(IDataReader reader)
		{
			bugdet = reader.ReadVarUInt();
		}

	}
}
