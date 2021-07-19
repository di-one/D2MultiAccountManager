namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BasicWhoIsRequestMessage : NetworkMessage
	{
		public const uint Id = 6034;
		public override uint MessageId => Id;
		public bool verbose { get; set; }
		public AbstractPlayerSearchInformation target { get; set; }

		public BasicWhoIsRequestMessage(bool verbose, AbstractPlayerSearchInformation target)
		{
			this.verbose = verbose;
			this.target = target;
		}

		public BasicWhoIsRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(verbose);
			writer.WriteShort(target.TypeId);
			target.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			verbose = reader.ReadBoolean();
			target = ProtocolTypeManager.GetInstance<AbstractPlayerSearchInformation>(reader.ReadShort());
			target.Deserialize(reader);
		}

	}
}
