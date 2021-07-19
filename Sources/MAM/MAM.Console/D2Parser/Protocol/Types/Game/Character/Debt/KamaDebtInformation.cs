namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class KamaDebtInformation : DebtInformation
	{
		public new const short Id = 6700;
		public override short TypeId => Id;
		public ulong kamas { get; set; }

		public KamaDebtInformation(double objectId, double timestamp, ulong kamas)
		{
			this.objectId = objectId;
			this.timestamp = timestamp;
			this.kamas = kamas;
		}

		public KamaDebtInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(kamas);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			kamas = reader.ReadVarULong();
		}

	}
}
