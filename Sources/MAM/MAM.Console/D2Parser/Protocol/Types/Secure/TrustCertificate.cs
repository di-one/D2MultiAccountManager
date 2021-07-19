namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TrustCertificate
	{
		public const short Id  = 2178;
		public virtual short TypeId => Id;
		public int objectId { get; set; }
		public string hash { get; set; }

		public TrustCertificate(int objectId, string hash)
		{
			this.objectId = objectId;
			this.hash = hash;
		}

		public TrustCertificate() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteInt(objectId);
			writer.WriteUTF(hash);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadInt();
			hash = reader.ReadUTF();
		}

	}
}
