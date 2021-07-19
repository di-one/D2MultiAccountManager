namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class LockableStateUpdateStorageMessage : LockableStateUpdateAbstractMessage
	{
		public new const uint Id = 9646;
		public override uint MessageId => Id;
		public double mapId { get; set; }
		public uint elementId { get; set; }

		public LockableStateUpdateStorageMessage(bool locked, double mapId, uint elementId)
		{
			this.locked = locked;
			this.mapId = mapId;
			this.elementId = elementId;
		}

		public LockableStateUpdateStorageMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(mapId);
			writer.WriteVarUInt(elementId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			mapId = reader.ReadDouble();
			elementId = reader.ReadVarUInt();
		}

	}
}
