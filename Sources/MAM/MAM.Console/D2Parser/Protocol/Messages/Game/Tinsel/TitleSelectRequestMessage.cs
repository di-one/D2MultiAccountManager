namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TitleSelectRequestMessage : NetworkMessage
	{
		public const uint Id = 5262;
		public override uint MessageId => Id;
		public ushort titleId { get; set; }

		public TitleSelectRequestMessage(ushort titleId)
		{
			this.titleId = titleId;
		}

		public TitleSelectRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(titleId);
		}

		public override void Deserialize(IDataReader reader)
		{
			titleId = reader.ReadVarUShort();
		}

	}
}
