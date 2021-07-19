namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AbstractCharacterInformation
	{
		public const short Id  = 8427;
		public virtual short TypeId => Id;
		public ulong objectId { get; set; }

		public AbstractCharacterInformation(ulong objectId)
		{
			this.objectId = objectId;
		}

		public AbstractCharacterInformation() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(objectId);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarULong();
		}

	}
}
