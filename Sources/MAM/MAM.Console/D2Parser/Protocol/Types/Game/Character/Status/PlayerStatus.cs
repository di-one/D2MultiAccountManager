namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PlayerStatus
	{
		public const short Id  = 223;
		public virtual short TypeId => Id;
		public sbyte statusId { get; set; }

		public PlayerStatus(sbyte statusId)
		{
			this.statusId = statusId;
		}

		public PlayerStatus() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(statusId);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			statusId = reader.ReadSByte();
		}

	}
}
