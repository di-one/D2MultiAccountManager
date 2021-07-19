namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HaapiValidationMessage : NetworkMessage
	{
		public const uint Id = 5175;
		public override uint MessageId => Id;
		public sbyte action { get; set; }
		public sbyte code { get; set; }

		public HaapiValidationMessage(sbyte action, sbyte code)
		{
			this.action = action;
			this.code = code;
		}

		public HaapiValidationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(action);
			writer.WriteSByte(code);
		}

		public override void Deserialize(IDataReader reader)
		{
			action = reader.ReadSByte();
			code = reader.ReadSByte();
		}

	}
}
