namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ShowCellSpectatorMessage : ShowCellMessage
	{
		public new const uint Id = 3955;
		public override uint MessageId => Id;
		public string playerName { get; set; }

		public ShowCellSpectatorMessage(double sourceId, ushort cellId, string playerName)
		{
			this.sourceId = sourceId;
			this.cellId = cellId;
			this.playerName = playerName;
		}

		public ShowCellSpectatorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(playerName);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			playerName = reader.ReadUTF();
		}

	}
}
