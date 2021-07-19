namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AcquaintanceInformation : AbstractContactInformations
	{
		public new const short Id = 1;
		public override short TypeId => Id;
		public sbyte playerState { get; set; }

		public AcquaintanceInformation(int accountId, AccountTagInformation accountTag, sbyte playerState)
		{
			this.accountId = accountId;
			this.accountTag = accountTag;
			this.playerState = playerState;
		}

		public AcquaintanceInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(playerState);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			playerState = reader.ReadSByte();
		}

	}
}
