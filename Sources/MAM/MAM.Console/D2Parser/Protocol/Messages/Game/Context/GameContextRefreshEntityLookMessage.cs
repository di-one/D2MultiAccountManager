namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameContextRefreshEntityLookMessage : NetworkMessage
	{
		public const uint Id = 6261;
		public override uint MessageId => Id;
		public double objectId { get; set; }
		public EntityLook look { get; set; }

		public GameContextRefreshEntityLookMessage(double objectId, EntityLook look)
		{
			this.objectId = objectId;
			this.look = look;
		}

		public GameContextRefreshEntityLookMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(objectId);
			look.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadDouble();
			look = new EntityLook();
			look.Deserialize(reader);
		}

	}
}
