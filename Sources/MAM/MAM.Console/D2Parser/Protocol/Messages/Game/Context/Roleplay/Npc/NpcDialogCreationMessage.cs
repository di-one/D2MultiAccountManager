namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class NpcDialogCreationMessage : NetworkMessage
	{
		public const uint Id = 8206;
		public override uint MessageId => Id;
		public double mapId { get; set; }
		public int npcId { get; set; }

		public NpcDialogCreationMessage(double mapId, int npcId)
		{
			this.mapId = mapId;
			this.npcId = npcId;
		}

		public NpcDialogCreationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(mapId);
			writer.WriteInt(npcId);
		}

		public override void Deserialize(IDataReader reader)
		{
			mapId = reader.ReadDouble();
			npcId = reader.ReadInt();
		}

	}
}
