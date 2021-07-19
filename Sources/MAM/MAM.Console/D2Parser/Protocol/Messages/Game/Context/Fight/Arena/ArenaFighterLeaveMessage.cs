namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ArenaFighterLeaveMessage : NetworkMessage
	{
		public const uint Id = 5912;
		public override uint MessageId => Id;
		public CharacterBasicMinimalInformations leaver { get; set; }

		public ArenaFighterLeaveMessage(CharacterBasicMinimalInformations leaver)
		{
			this.leaver = leaver;
		}

		public ArenaFighterLeaveMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			leaver.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			leaver = new CharacterBasicMinimalInformations();
			leaver.Deserialize(reader);
		}

	}
}
