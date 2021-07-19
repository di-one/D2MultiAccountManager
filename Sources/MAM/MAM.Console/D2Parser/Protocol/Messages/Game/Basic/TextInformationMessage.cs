namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TextInformationMessage : NetworkMessage
	{
		public const uint Id = 8845;
		public override uint MessageId => Id;
		public sbyte msgType { get; set; }
		public ushort msgId { get; set; }
		public IEnumerable<string> parameters { get; set; }

		public TextInformationMessage(sbyte msgType, ushort msgId, IEnumerable<string> parameters)
		{
			this.msgType = msgType;
			this.msgId = msgId;
			this.parameters = parameters;
		}

		public TextInformationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(msgType);
			writer.WriteVarUShort(msgId);
			writer.WriteShort((short)parameters.Count());
			foreach (var objectToSend in parameters)
            {
				writer.WriteUTF(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			msgType = reader.ReadSByte();
			msgId = reader.ReadVarUShort();
			var parametersCount = reader.ReadUShort();
			var parameters_ = new string[parametersCount];
			for (var parametersIndex = 0; parametersIndex < parametersCount; parametersIndex++)
			{
				parameters_[parametersIndex] = reader.ReadUTF();
			}
			parameters = parameters_;
		}

	}
}
