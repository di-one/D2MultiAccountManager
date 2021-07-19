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
	public class DebtsUpdateMessage : NetworkMessage
	{
		public const uint Id = 4837;
		public override uint MessageId => Id;
		public sbyte action { get; set; }
		public IEnumerable<DebtInformation> debts { get; set; }

		public DebtsUpdateMessage(sbyte action, IEnumerable<DebtInformation> debts)
		{
			this.action = action;
			this.debts = debts;
		}

		public DebtsUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(action);
			writer.WriteShort((short)debts.Count());
			foreach (var objectToSend in debts)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			action = reader.ReadSByte();
			var debtsCount = reader.ReadUShort();
			var debts_ = new DebtInformation[debtsCount];
			for (var debtsIndex = 0; debtsIndex < debtsCount; debtsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<DebtInformation>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				debts_[debtsIndex] = objectToAdd;
			}
			debts = debts_;
		}

	}
}
