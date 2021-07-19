namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MountInformationsForPaddock
	{
		public const short Id  = 6807;
		public virtual short TypeId => Id;
		public ushort modelId { get; set; }
		public string name { get; set; }
		public string ownerName { get; set; }

		public MountInformationsForPaddock(ushort modelId, string name, string ownerName)
		{
			this.modelId = modelId;
			this.name = name;
			this.ownerName = ownerName;
		}

		public MountInformationsForPaddock() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(modelId);
			writer.WriteUTF(name);
			writer.WriteUTF(ownerName);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			modelId = reader.ReadVarUShort();
			name = reader.ReadUTF();
			ownerName = reader.ReadUTF();
		}

	}
}
