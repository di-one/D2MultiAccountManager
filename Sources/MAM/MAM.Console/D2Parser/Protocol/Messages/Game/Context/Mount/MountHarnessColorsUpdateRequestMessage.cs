namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MountHarnessColorsUpdateRequestMessage : NetworkMessage
	{
		public const uint Id = 8829;
		public override uint MessageId => Id;
		public bool useHarnessColors { get; set; }

		public MountHarnessColorsUpdateRequestMessage(bool useHarnessColors)
		{
			this.useHarnessColors = useHarnessColors;
		}

		public MountHarnessColorsUpdateRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(useHarnessColors);
		}

		public override void Deserialize(IDataReader reader)
		{
			useHarnessColors = reader.ReadBoolean();
		}

	}
}
