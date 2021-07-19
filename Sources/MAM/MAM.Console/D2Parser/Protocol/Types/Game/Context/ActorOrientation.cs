namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ActorOrientation
	{
		public const short Id  = 6675;
		public virtual short TypeId => Id;
		public double objectId { get; set; }
		public sbyte direction { get; set; }

		public ActorOrientation(double objectId, sbyte direction)
		{
			this.objectId = objectId;
			this.direction = direction;
		}

		public ActorOrientation() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(objectId);
			writer.WriteSByte(direction);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadDouble();
			direction = reader.ReadSByte();
		}

	}
}
