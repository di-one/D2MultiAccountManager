namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MapFightCountMessage : NetworkMessage
	{
		public const uint Id = 1367;
		public override uint MessageId => Id;
		public ushort fightCount { get; set; }

		public MapFightCountMessage(ushort fightCount)
		{
			this.fightCount = fightCount;
		}

		public MapFightCountMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(fightCount);
		}

		public override void Deserialize(IDataReader reader)
		{
			fightCount = reader.ReadVarUShort();
		}

	}
}
