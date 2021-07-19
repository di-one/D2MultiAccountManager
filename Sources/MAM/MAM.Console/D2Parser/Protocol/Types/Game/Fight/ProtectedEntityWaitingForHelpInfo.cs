namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ProtectedEntityWaitingForHelpInfo
	{
		public const short Id  = 1050;
		public virtual short TypeId => Id;
		public int timeLeftBeforeFight { get; set; }
		public int waitTimeForPlacement { get; set; }
		public sbyte nbPositionForDefensors { get; set; }

		public ProtectedEntityWaitingForHelpInfo(int timeLeftBeforeFight, int waitTimeForPlacement, sbyte nbPositionForDefensors)
		{
			this.timeLeftBeforeFight = timeLeftBeforeFight;
			this.waitTimeForPlacement = waitTimeForPlacement;
			this.nbPositionForDefensors = nbPositionForDefensors;
		}

		public ProtectedEntityWaitingForHelpInfo() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteInt(timeLeftBeforeFight);
			writer.WriteInt(waitTimeForPlacement);
			writer.WriteSByte(nbPositionForDefensors);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			timeLeftBeforeFight = reader.ReadInt();
			waitTimeForPlacement = reader.ReadInt();
			nbPositionForDefensors = reader.ReadSByte();
		}

	}
}
