namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class StatedElement
	{
		public const short Id  = 8521;
		public virtual short TypeId => Id;
		public int elementId { get; set; }
		public ushort elementCellId { get; set; }
		public uint elementState { get; set; }
		public bool onCurrentMap { get; set; }

		public StatedElement(int elementId, ushort elementCellId, uint elementState, bool onCurrentMap)
		{
			this.elementId = elementId;
			this.elementCellId = elementCellId;
			this.elementState = elementState;
			this.onCurrentMap = onCurrentMap;
		}

		public StatedElement() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteInt(elementId);
			writer.WriteVarUShort(elementCellId);
			writer.WriteVarUInt(elementState);
			writer.WriteBoolean(onCurrentMap);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			elementId = reader.ReadInt();
			elementCellId = reader.ReadVarUShort();
			elementState = reader.ReadVarUInt();
			onCurrentMap = reader.ReadBoolean();
		}

	}
}
