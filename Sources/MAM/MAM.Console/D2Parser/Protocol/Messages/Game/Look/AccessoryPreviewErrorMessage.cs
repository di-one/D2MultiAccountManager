namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AccessoryPreviewErrorMessage : NetworkMessage
	{
		public const uint Id = 1428;
		public override uint MessageId => Id;
		public sbyte error { get; set; }

		public AccessoryPreviewErrorMessage(sbyte error)
		{
			this.error = error;
		}

		public AccessoryPreviewErrorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(error);
		}

		public override void Deserialize(IDataReader reader)
		{
			error = reader.ReadSByte();
		}

	}
}
