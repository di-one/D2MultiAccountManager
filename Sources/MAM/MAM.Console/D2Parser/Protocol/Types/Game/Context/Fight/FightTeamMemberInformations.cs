namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightTeamMemberInformations
	{
		public const short Id  = 7292;
		public virtual short TypeId => Id;
		public double objectId { get; set; }

		public FightTeamMemberInformations(double objectId)
		{
			this.objectId = objectId;
		}

		public FightTeamMemberInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(objectId);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadDouble();
		}

	}
}
