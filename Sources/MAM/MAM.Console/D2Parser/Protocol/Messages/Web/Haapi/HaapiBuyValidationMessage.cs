namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HaapiBuyValidationMessage : HaapiValidationMessage
	{
		public new const uint Id = 5662;
		public override uint MessageId => Id;
		public ulong amount { get; set; }
		public string email { get; set; }

		public HaapiBuyValidationMessage(sbyte action, sbyte code, ulong amount, string email)
		{
			this.action = action;
			this.code = code;
			this.amount = amount;
			this.email = email;
		}

		public HaapiBuyValidationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(amount);
			writer.WriteUTF(email);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			amount = reader.ReadVarULong();
			email = reader.ReadUTF();
		}

	}
}
