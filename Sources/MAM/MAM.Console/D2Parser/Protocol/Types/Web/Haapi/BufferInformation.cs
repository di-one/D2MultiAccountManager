namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BufferInformation
	{
		public const short Id  = 7219;
		public virtual short TypeId => Id;
		public ulong objectId { get; set; }
		public ulong amount { get; set; }

		public BufferInformation(ulong objectId, ulong amount)
		{
			this.objectId = objectId;
			this.amount = amount;
		}

		public BufferInformation() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(objectId);
			writer.WriteVarULong(amount);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarULong();
			amount = reader.ReadVarULong();
		}

	}
}
