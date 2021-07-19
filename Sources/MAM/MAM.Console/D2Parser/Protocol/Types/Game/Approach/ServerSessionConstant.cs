namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ServerSessionConstant
	{
		public const short Id  = 2772;
		public virtual short TypeId => Id;
		public ushort objectId { get; set; }

		public ServerSessionConstant(ushort objectId)
		{
			this.objectId = objectId;
		}

		public ServerSessionConstant() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(objectId);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarUShort();
		}

	}
}
