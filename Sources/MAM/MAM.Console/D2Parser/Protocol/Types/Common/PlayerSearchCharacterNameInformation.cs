namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PlayerSearchCharacterNameInformation : AbstractPlayerSearchInformation
	{
		public new const short Id = 1326;
		public override short TypeId => Id;
		public string name { get; set; }

		public PlayerSearchCharacterNameInformation(string name)
		{
			this.name = name;
		}

		public PlayerSearchCharacterNameInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(name);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			name = reader.ReadUTF();
		}

	}
}
