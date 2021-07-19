namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameContextBasicSpawnInformation
	{
		public const short Id  = 3043;
		public virtual short TypeId => Id;
		public sbyte teamId { get; set; }
		public bool alive { get; set; }
		public GameContextActorPositionInformations informations { get; set; }

		public GameContextBasicSpawnInformation(sbyte teamId, bool alive, GameContextActorPositionInformations informations)
		{
			this.teamId = teamId;
			this.alive = alive;
			this.informations = informations;
		}

		public GameContextBasicSpawnInformation() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(teamId);
			writer.WriteBoolean(alive);
			writer.WriteShort(informations.TypeId);
			informations.Serialize(writer);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			teamId = reader.ReadSByte();
			alive = reader.ReadBoolean();
			informations = ProtocolTypeManager.GetInstance<GameContextActorPositionInformations>(reader.ReadShort());
			informations.Deserialize(reader);
		}

	}
}
