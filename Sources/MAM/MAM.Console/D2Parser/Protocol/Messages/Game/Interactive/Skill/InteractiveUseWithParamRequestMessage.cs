namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class InteractiveUseWithParamRequestMessage : InteractiveUseRequestMessage
	{
		public new const uint Id = 2223;
		public override uint MessageId => Id;
		public int objectId { get; set; }

		public InteractiveUseWithParamRequestMessage(uint elemId, uint skillInstanceUid, int objectId)
		{
			this.elemId = elemId;
			this.skillInstanceUid = skillInstanceUid;
			this.objectId = objectId;
		}

		public InteractiveUseWithParamRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(objectId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			objectId = reader.ReadInt();
		}

	}
}
