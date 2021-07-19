namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TaxCollectorAttackedResultMessage : NetworkMessage
	{
		public const uint Id = 4154;
		public override uint MessageId => Id;
		public bool deadOrAlive { get; set; }
		public TaxCollectorBasicInformations basicInfos { get; set; }
		public BasicGuildInformations guild { get; set; }

		public TaxCollectorAttackedResultMessage(bool deadOrAlive, TaxCollectorBasicInformations basicInfos, BasicGuildInformations guild)
		{
			this.deadOrAlive = deadOrAlive;
			this.basicInfos = basicInfos;
			this.guild = guild;
		}

		public TaxCollectorAttackedResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(deadOrAlive);
			basicInfos.Serialize(writer);
			guild.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			deadOrAlive = reader.ReadBoolean();
			basicInfos = new TaxCollectorBasicInformations();
			basicInfos.Deserialize(reader);
			guild = new BasicGuildInformations();
			guild.Deserialize(reader);
		}

	}
}
