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
	public class SystemMessageDisplayMessage : NetworkMessage
	{
		public const uint Id = 1803;
		public override uint MessageId => Id;
		public bool hangUp { get; set; }
		public ushort msgId { get; set; }
		public IEnumerable<string> parameters { get; set; }

		public SystemMessageDisplayMessage(bool hangUp, ushort msgId, IEnumerable<string> parameters)
		{
			this.hangUp = hangUp;
			this.msgId = msgId;
			this.parameters = parameters;
		}

		public SystemMessageDisplayMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(hangUp);
			writer.WriteVarUShort(msgId);
			writer.WriteShort((short)parameters.Count());
			foreach (var objectToSend in parameters)
            {
				writer.WriteUTF(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			hangUp = reader.ReadBoolean();
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
