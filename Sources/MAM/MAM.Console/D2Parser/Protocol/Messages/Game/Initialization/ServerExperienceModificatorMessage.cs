namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ServerExperienceModificatorMessage : NetworkMessage
	{
		public const uint Id = 622;
		public override uint MessageId => Id;
		public ushort experiencePercent { get; set; }

		public ServerExperienceModificatorMessage(ushort experiencePercent)
		{
			this.experiencePercent = experiencePercent;
		}

		public ServerExperienceModificatorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(experiencePercent);
		}

		public override void Deserialize(IDataReader reader)
		{
			experiencePercent = reader.ReadVarUShort();
		}

	}
}
