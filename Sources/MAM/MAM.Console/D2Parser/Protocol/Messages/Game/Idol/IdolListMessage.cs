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
	public class IdolListMessage : NetworkMessage
	{
		public const uint Id = 3868;
		public override uint MessageId => Id;
		public IEnumerable<ushort> chosenIdols { get; set; }
		public IEnumerable<ushort> partyChosenIdols { get; set; }
		public IEnumerable<PartyIdol> partyIdols { get; set; }

		public IdolListMessage(IEnumerable<ushort> chosenIdols, IEnumerable<ushort> partyChosenIdols, IEnumerable<PartyIdol> partyIdols)
		{
			this.chosenIdols = chosenIdols;
			this.partyChosenIdols = partyChosenIdols;
			this.partyIdols = partyIdols;
		}

		public IdolListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)chosenIdols.Count());
			foreach (var objectToSend in chosenIdols)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteShort((short)partyChosenIdols.Count());
			foreach (var objectToSend in partyChosenIdols)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteShort((short)partyIdols.Count());
			foreach (var objectToSend in partyIdols)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var chosenIdolsCount = reader.ReadUShort();
			var chosenIdols_ = new ushort[chosenIdolsCount];
			for (var chosenIdolsIndex = 0; chosenIdolsIndex < chosenIdolsCount; chosenIdolsIndex++)
			{
				chosenIdols_[chosenIdolsIndex] = reader.ReadVarUShort();
			}
			chosenIdols = chosenIdols_;
			var partyChosenIdolsCount = reader.ReadUShort();
			var partyChosenIdols_ = new ushort[partyChosenIdolsCount];
			for (var partyChosenIdolsIndex = 0; partyChosenIdolsIndex < partyChosenIdolsCount; partyChosenIdolsIndex++)
			{
				partyChosenIdols_[partyChosenIdolsIndex] = reader.ReadVarUShort();
			}
			partyChosenIdols = partyChosenIdols_;
			var partyIdolsCount = reader.ReadUShort();
			var partyIdols_ = new PartyIdol[partyIdolsCount];
			for (var partyIdolsIndex = 0; partyIdolsIndex < partyIdolsCount; partyIdolsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<PartyIdol>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				partyIdols_[partyIdolsIndex] = objectToAdd;
			}
			partyIdols = partyIdols_;
		}

	}
}
