namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterLevelUpMessage : NetworkMessage
	{
		public const uint Id = 3887;
		public override uint MessageId => Id;
		public ushort newLevel { get; set; }

		public CharacterLevelUpMessage(ushort newLevel)
		{
			this.newLevel = newLevel;
		}

		public CharacterLevelUpMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(newLevel);
		}

		public override void Deserialize(IDataReader reader)
		{
			newLevel = reader.ReadVarUShort();
		}

	}
}
