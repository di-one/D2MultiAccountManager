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
	public class LivingObjectMessageRequestMessage : NetworkMessage
	{
		public const uint Id = 6281;
		public override uint MessageId => Id;
		public ushort msgId { get; set; }
		public IEnumerable<string> parameters { get; set; }
		public uint livingObject { get; set; }

		public LivingObjectMessageRequestMessage(ushort msgId, IEnumerable<string> parameters, uint livingObject)
		{
			this.msgId = msgId;
			this.parameters = parameters;
			this.livingObject = livingObject;
		}

		public LivingObjectMessageRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(msgId);
			writer.WriteShort((short)parameters.Count());
			foreach (var objectToSend in parameters)
            {
				writer.WriteUTF(objectToSend);
			}
			writer.WriteVarUInt(livingObject);
		}

		public override void Deserialize(IDataReader reader)
		{
			msgId = reader.ReadVarUShort();
			var parametersCount = reader.ReadUShort();
			var parameters_ = new string[parametersCount];
			for (var parametersIndex = 0; parametersIndex < parametersCount; parametersIndex++)
			{
				parameters_[parametersIndex] = reader.ReadUTF();
			}
			parameters = parameters_;
			livingObject = reader.ReadVarUInt();
		}

	}
}
