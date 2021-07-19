namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PortalDialogCreationMessage : NpcDialogCreationMessage
	{
		public new const uint Id = 3236;
		public override uint MessageId => Id;
		public int type { get; set; }

		public PortalDialogCreationMessage(double mapId, int npcId, int type)
		{
			this.mapId = mapId;
			this.npcId = npcId;
			this.type = type;
		}

		public PortalDialogCreationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(type);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			type = reader.ReadInt();
		}

	}
}
