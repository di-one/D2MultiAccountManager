namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectUseOnCellMessage : ObjectUseMessage
	{
		public new const uint Id = 3585;
		public override uint MessageId => Id;
		public ushort cells { get; set; }

		public ObjectUseOnCellMessage(uint objectUID, ushort cells)
		{
			this.objectUID = objectUID;
			this.cells = cells;
		}

		public ObjectUseOnCellMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(cells);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			cells = reader.ReadVarUShort();
		}

	}
}
