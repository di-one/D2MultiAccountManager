namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AccountTagInformation
	{
		public const short Id  = 7164;
		public virtual short TypeId => Id;
		public string nickname { get; set; }
		public string tagNumber { get; set; }

		public AccountTagInformation(string nickname, string tagNumber)
		{
			this.nickname = nickname;
			this.tagNumber = tagNumber;
		}

		public AccountTagInformation() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(nickname);
			writer.WriteUTF(tagNumber);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			nickname = reader.ReadUTF();
			tagNumber = reader.ReadUTF();
		}

	}
}
