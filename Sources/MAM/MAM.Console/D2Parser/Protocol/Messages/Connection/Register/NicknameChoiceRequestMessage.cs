namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class NicknameChoiceRequestMessage : NetworkMessage
	{
		public const uint Id = 7813;
		public override uint MessageId => Id;
		public string nickname { get; set; }

		public NicknameChoiceRequestMessage(string nickname)
		{
			this.nickname = nickname;
		}

		public NicknameChoiceRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(nickname);
		}

		public override void Deserialize(IDataReader reader)
		{
			nickname = reader.ReadUTF();
		}

	}
}
