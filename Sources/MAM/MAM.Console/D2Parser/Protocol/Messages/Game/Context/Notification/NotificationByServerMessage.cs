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
	public class NotificationByServerMessage : NetworkMessage
	{
		public const uint Id = 3065;
		public override uint MessageId => Id;
		public ushort objectId { get; set; }
		public IEnumerable<string> parameters { get; set; }
		public bool forceOpen { get; set; }

		public NotificationByServerMessage(ushort objectId, IEnumerable<string> parameters, bool forceOpen)
		{
			this.objectId = objectId;
			this.parameters = parameters;
			this.forceOpen = forceOpen;
		}

		public NotificationByServerMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(objectId);
			writer.WriteShort((short)parameters.Count());
			foreach (var objectToSend in parameters)
            {
				writer.WriteUTF(objectToSend);
			}
			writer.WriteBoolean(forceOpen);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarUShort();
			var parametersCount = reader.ReadUShort();
			var parameters_ = new string[parametersCount];
			for (var parametersIndex = 0; parametersIndex < parametersCount; parametersIndex++)
			{
				parameters_[parametersIndex] = reader.ReadUTF();
			}
			parameters = parameters_;
			forceOpen = reader.ReadBoolean();
		}

	}
}
