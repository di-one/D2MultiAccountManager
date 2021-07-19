namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AccessoryPreviewMessage : NetworkMessage
	{
		public const uint Id = 9725;
		public override uint MessageId => Id;
		public EntityLook look { get; set; }

		public AccessoryPreviewMessage(EntityLook look)
		{
			this.look = look;
		}

		public AccessoryPreviewMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			look.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			look = new EntityLook();
			look.Deserialize(reader);
		}

	}
}
