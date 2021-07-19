namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameContextCreateMessage : NetworkMessage
	{
		public const uint Id = 7145;
		public override uint MessageId => Id;
		public sbyte context { get; set; }

		public GameContextCreateMessage(sbyte context)
		{
			this.context = context;
		}

		public GameContextCreateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(context);
		}

		public override void Deserialize(IDataReader reader)
		{
			context = reader.ReadSByte();
		}

	}
}
