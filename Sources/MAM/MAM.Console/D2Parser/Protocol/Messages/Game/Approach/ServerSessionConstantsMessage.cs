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
	public class ServerSessionConstantsMessage : NetworkMessage
	{
		public const uint Id = 20;
		public override uint MessageId => Id;
		public IEnumerable<ServerSessionConstant> variables { get; set; }

		public ServerSessionConstantsMessage(IEnumerable<ServerSessionConstant> variables)
		{
			this.variables = variables;
		}

		public ServerSessionConstantsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)variables.Count());
			foreach (var objectToSend in variables)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var variablesCount = reader.ReadUShort();
			var variables_ = new ServerSessionConstant[variablesCount];
			for (var variablesIndex = 0; variablesIndex < variablesCount; variablesIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<ServerSessionConstant>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				variables_[variablesIndex] = objectToAdd;
			}
			variables = variables_;
		}

	}
}
