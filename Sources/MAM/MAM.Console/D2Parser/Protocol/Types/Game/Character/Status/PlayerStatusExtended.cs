namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PlayerStatusExtended : PlayerStatus
	{
		public new const short Id = 4104;
		public override short TypeId => Id;
		public string message { get; set; }

		public PlayerStatusExtended(sbyte statusId, string message)
		{
			this.statusId = statusId;
			this.message = message;
		}

		public PlayerStatusExtended() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(message);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			message = reader.ReadUTF();
		}

	}
}
