namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class EntityInformationMessage : NetworkMessage
	{
		public const uint Id = 2176;
		public override uint MessageId => Id;
		public EntityInformation entity { get; set; }

		public EntityInformationMessage(EntityInformation entity)
		{
			this.entity = entity;
		}

		public EntityInformationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			entity.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			entity = new EntityInformation();
			entity.Deserialize(reader);
		}

	}
}
