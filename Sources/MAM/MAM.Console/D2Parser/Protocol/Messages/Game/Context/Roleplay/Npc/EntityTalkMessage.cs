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
	public class EntityTalkMessage : NetworkMessage
	{
		public const uint Id = 8783;
		public override uint MessageId => Id;
		public double entityId { get; set; }
		public ushort textId { get; set; }
		public IEnumerable<string> parameters { get; set; }

		public EntityTalkMessage(double entityId, ushort textId, IEnumerable<string> parameters)
		{
			this.entityId = entityId;
			this.textId = textId;
			this.parameters = parameters;
		}

		public EntityTalkMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(entityId);
			writer.WriteVarUShort(textId);
			writer.WriteShort((short)parameters.Count());
			foreach (var objectToSend in parameters)
            {
				writer.WriteUTF(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			entityId = reader.ReadDouble();
			textId = reader.ReadVarUShort();
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
