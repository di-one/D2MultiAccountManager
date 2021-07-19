namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChangeThemeRequestMessage : NetworkMessage
	{
		public const uint Id = 6713;
		public override uint MessageId => Id;
		public sbyte theme { get; set; }

		public ChangeThemeRequestMessage(sbyte theme)
		{
			this.theme = theme;
		}

		public ChangeThemeRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(theme);
		}

		public override void Deserialize(IDataReader reader)
		{
			theme = reader.ReadSByte();
		}

	}
}
