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
	public class DungeonKeyRingMessage : NetworkMessage
	{
		public const uint Id = 8074;
		public override uint MessageId => Id;
		public IEnumerable<ushort> availables { get; set; }
		public IEnumerable<ushort> unavailables { get; set; }

		public DungeonKeyRingMessage(IEnumerable<ushort> availables, IEnumerable<ushort> unavailables)
		{
			this.availables = availables;
			this.unavailables = unavailables;
		}

		public DungeonKeyRingMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)availables.Count());
			foreach (var objectToSend in availables)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteShort((short)unavailables.Count());
			foreach (var objectToSend in unavailables)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var availablesCount = reader.ReadUShort();
			var availables_ = new ushort[availablesCount];
			for (var availablesIndex = 0; availablesIndex < availablesCount; availablesIndex++)
			{
				availables_[availablesIndex] = reader.ReadVarUShort();
			}
			availables = availables_;
			var unavailablesCount = reader.ReadUShort();
			var unavailables_ = new ushort[unavailablesCount];
			for (var unavailablesIndex = 0; unavailablesIndex < unavailablesCount; unavailablesIndex++)
			{
				unavailables_[unavailablesIndex] = reader.ReadVarUShort();
			}
			unavailables = unavailables_;
		}

	}
}
