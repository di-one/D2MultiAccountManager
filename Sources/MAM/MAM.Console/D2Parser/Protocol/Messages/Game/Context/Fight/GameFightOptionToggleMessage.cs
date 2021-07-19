namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightOptionToggleMessage : NetworkMessage
	{
		public const uint Id = 4487;
		public override uint MessageId => Id;
		public sbyte option { get; set; }

		public GameFightOptionToggleMessage(sbyte option)
		{
			this.option = option;
		}

		public GameFightOptionToggleMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(option);
		}

		public override void Deserialize(IDataReader reader)
		{
			option = reader.ReadSByte();
		}

	}
}
