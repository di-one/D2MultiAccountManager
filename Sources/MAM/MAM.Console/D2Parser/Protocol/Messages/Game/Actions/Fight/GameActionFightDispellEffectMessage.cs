namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightDispellEffectMessage : GameActionFightDispellMessage
	{
		public new const uint Id = 8035;
		public override uint MessageId => Id;
		public int boostUID { get; set; }

		public GameActionFightDispellEffectMessage(ushort actionId, double sourceId, double targetId, bool verboseCast, int boostUID)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.verboseCast = verboseCast;
			this.boostUID = boostUID;
		}

		public GameActionFightDispellEffectMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(boostUID);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			boostUID = reader.ReadInt();
		}

	}
}
