namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HumanOptionTitle : HumanOption
	{
		public new const short Id = 5299;
		public override short TypeId => Id;
		public ushort titleId { get; set; }
		public string titleParam { get; set; }

		public HumanOptionTitle(ushort titleId, string titleParam)
		{
			this.titleId = titleId;
			this.titleParam = titleParam;
		}

		public HumanOptionTitle() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(titleId);
			writer.WriteUTF(titleParam);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			titleId = reader.ReadVarUShort();
			titleParam = reader.ReadUTF();
		}

	}
}
