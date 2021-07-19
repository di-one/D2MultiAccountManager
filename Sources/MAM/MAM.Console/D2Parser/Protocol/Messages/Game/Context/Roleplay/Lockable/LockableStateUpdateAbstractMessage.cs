namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class LockableStateUpdateAbstractMessage : NetworkMessage
	{
		public const uint Id = 5643;
		public override uint MessageId => Id;
		public bool locked { get; set; }

		public LockableStateUpdateAbstractMessage(bool locked)
		{
			this.locked = locked;
		}

		public LockableStateUpdateAbstractMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(locked);
		}

		public override void Deserialize(IDataReader reader)
		{
			locked = reader.ReadBoolean();
		}

	}
}
