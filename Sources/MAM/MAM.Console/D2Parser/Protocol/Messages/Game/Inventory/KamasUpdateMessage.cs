namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class KamasUpdateMessage : NetworkMessage
	{
		public const uint Id = 9819;
		public override uint MessageId => Id;
		public ulong kamasTotal { get; set; }

		public KamasUpdateMessage(ulong kamasTotal)
		{
			this.kamasTotal = kamasTotal;
		}

		public KamasUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(kamasTotal);
		}

		public override void Deserialize(IDataReader reader)
		{
			kamasTotal = reader.ReadVarULong();
		}

	}
}
