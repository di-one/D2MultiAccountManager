namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightCharacteristics
	{
		public const short Id  = 6094;
		public virtual short TypeId => Id;
		public CharacterCharacteristics characteristics { get; set; }
		public double summoner { get; set; }
		public bool summoned { get; set; }
		public sbyte invisibilityState { get; set; }

		public GameFightCharacteristics(CharacterCharacteristics characteristics, double summoner, bool summoned, sbyte invisibilityState)
		{
			this.characteristics = characteristics;
			this.summoner = summoner;
			this.summoned = summoned;
			this.invisibilityState = invisibilityState;
		}

		public GameFightCharacteristics() { }

		public virtual void Serialize(IDataWriter writer)
		{
			characteristics.Serialize(writer);
			writer.WriteDouble(summoner);
			writer.WriteBoolean(summoned);
			writer.WriteSByte(invisibilityState);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			characteristics = new CharacterCharacteristics();
			characteristics.Deserialize(reader);
			summoner = reader.ReadDouble();
			summoned = reader.ReadBoolean();
			invisibilityState = reader.ReadSByte();
		}

	}
}
