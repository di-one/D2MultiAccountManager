namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class Shortcut
	{
		public const short Id  = 3614;
		public virtual short TypeId => Id;
		public sbyte slot { get; set; }

		public Shortcut(sbyte slot)
		{
			this.slot = slot;
		}

		public Shortcut() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(slot);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			slot = reader.ReadSByte();
		}

	}
}
