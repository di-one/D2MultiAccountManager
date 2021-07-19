namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AreaFightModificatorUpdateMessage : NetworkMessage
	{
		public const uint Id = 8822;
		public override uint MessageId => Id;
		public int spellPairId { get; set; }

		public AreaFightModificatorUpdateMessage(int spellPairId)
		{
			this.spellPairId = spellPairId;
		}

		public AreaFightModificatorUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(spellPairId);
		}

		public override void Deserialize(IDataReader reader)
		{
			spellPairId = reader.ReadInt();
		}

	}
}
