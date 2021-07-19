namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class NpcGenericActionRequestMessage : NetworkMessage
	{
		public const uint Id = 3105;
		public override uint MessageId => Id;
		public int npcId { get; set; }
		public sbyte npcActionId { get; set; }
		public double npcMapId { get; set; }

		public NpcGenericActionRequestMessage(int npcId, sbyte npcActionId, double npcMapId)
		{
			this.npcId = npcId;
			this.npcActionId = npcActionId;
			this.npcMapId = npcMapId;
		}

		public NpcGenericActionRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(npcId);
			writer.WriteSByte(npcActionId);
			writer.WriteDouble(npcMapId);
		}

		public override void Deserialize(IDataReader reader)
		{
			npcId = reader.ReadInt();
			npcActionId = reader.ReadSByte();
			npcMapId = reader.ReadDouble();
		}

	}
}
