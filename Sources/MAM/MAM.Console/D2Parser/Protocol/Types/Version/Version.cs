namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class Version
	{
		public const short Id  = 9475;
		public virtual short TypeId => Id;
		public sbyte major { get; set; }
		public sbyte minor { get; set; }
		public sbyte code { get; set; }
		public int build { get; set; }
		public sbyte buildType { get; set; }

		public Version(sbyte major, sbyte minor, sbyte code, int build, sbyte buildType)
		{
			this.major = major;
			this.minor = minor;
			this.code = code;
			this.build = build;
			this.buildType = buildType;
		}

		public Version() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(major);
			writer.WriteSByte(minor);
			writer.WriteSByte(code);
			writer.WriteInt(build);
			writer.WriteSByte(buildType);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			major = reader.ReadSByte();
			minor = reader.ReadSByte();
			code = reader.ReadSByte();
			build = reader.ReadInt();
			buildType = reader.ReadSByte();
		}

	}
}
