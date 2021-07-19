namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AdditionalTaxCollectorInformations
	{
		public const short Id  = 7720;
		public virtual short TypeId => Id;
		public string collectorCallerName { get; set; }
		public int date { get; set; }

		public AdditionalTaxCollectorInformations(string collectorCallerName, int date)
		{
			this.collectorCallerName = collectorCallerName;
			this.date = date;
		}

		public AdditionalTaxCollectorInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(collectorCallerName);
			writer.WriteInt(date);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			collectorCallerName = reader.ReadUTF();
			date = reader.ReadInt();
		}

	}
}
