namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class Preset
	{
		public const short Id  = 6748;
		public virtual short TypeId => Id;
		public short objectId { get; set; }

		public Preset(short objectId)
		{
			this.objectId = objectId;
		}

		public Preset() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteShort(objectId);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadShort();
		}

	}
}
