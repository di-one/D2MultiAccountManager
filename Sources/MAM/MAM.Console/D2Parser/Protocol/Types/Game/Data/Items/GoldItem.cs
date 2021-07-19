namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GoldItem : Item
	{
		public new const short Id = 3121;
		public override short TypeId => Id;
		public ulong sum { get; set; }

		public GoldItem(ulong sum)
		{
			this.sum = sum;
		}

		public GoldItem() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(sum);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			sum = reader.ReadVarULong();
		}

	}
}
