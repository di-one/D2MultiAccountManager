namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectEffect
	{
		public const short Id  = 2671;
		public virtual short TypeId => Id;
		public ushort actionId { get; set; }

		public ObjectEffect(ushort actionId)
		{
			this.actionId = actionId;
		}

		public ObjectEffect() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(actionId);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			actionId = reader.ReadVarUShort();
		}

	}
}
