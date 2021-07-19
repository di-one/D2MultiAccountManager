namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class DebtsDeleteMessage : NetworkMessage
	{
		public const uint Id = 6311;
		public override uint MessageId => Id;
		public sbyte reason { get; set; }
		public IEnumerable<double> debts { get; set; }

		public DebtsDeleteMessage(sbyte reason, IEnumerable<double> debts)
		{
			this.reason = reason;
			this.debts = debts;
		}

		public DebtsDeleteMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(reason);
			writer.WriteShort((short)debts.Count());
			foreach (var objectToSend in debts)
            {
				writer.WriteDouble(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			reason = reader.ReadSByte();
			var debtsCount = reader.ReadUShort();
			var debts_ = new double[debtsCount];
			for (var debtsIndex = 0; debtsIndex < debtsCount; debtsIndex++)
			{
				debts_[debtsIndex] = reader.ReadDouble();
			}
			debts = debts_;
		}

	}
}
