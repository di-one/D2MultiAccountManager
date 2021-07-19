﻿namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AbstractSocialGroupInfos
	{
		public const short Id  = 6558;
		public virtual short TypeId => Id;

		public AbstractSocialGroupInfos() { }

		public virtual void Serialize(IDataWriter writer)
		{
		}

		public virtual void Deserialize(IDataReader reader)
		{
		}

	}
}
