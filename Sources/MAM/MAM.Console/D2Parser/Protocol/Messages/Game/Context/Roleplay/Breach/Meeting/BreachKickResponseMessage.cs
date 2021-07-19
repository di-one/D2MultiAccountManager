namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BreachKickResponseMessage : NetworkMessage
	{
		public const uint Id = 1022;
		public override uint MessageId => Id;
		public CharacterMinimalInformations target { get; set; }
		public bool kicked { get; set; }

		public BreachKickResponseMessage(CharacterMinimalInformations target, bool kicked)
		{
			this.target = target;
			this.kicked = kicked;
		}

		public BreachKickResponseMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			target.Serialize(writer);
			writer.WriteBoolean(kicked);
		}

		public override void Deserialize(IDataReader reader)
		{
			target = new CharacterMinimalInformations();
			target.Deserialize(reader);
			kicked = reader.ReadBoolean();
		}

	}
}
