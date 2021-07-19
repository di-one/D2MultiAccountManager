namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ConsoleCommandsListMessage : NetworkMessage
	{
		public const uint Id = 6479;
		public override uint MessageId => Id;
		public IEnumerable<string> aliases { get; set; }
		public IEnumerable<string> args { get; set; }
		public IEnumerable<string> descriptions { get; set; }

		public ConsoleCommandsListMessage(IEnumerable<string> aliases, IEnumerable<string> args, IEnumerable<string> descriptions)
		{
			this.aliases = aliases;
			this.args = args;
			this.descriptions = descriptions;
		}

		public ConsoleCommandsListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)aliases.Count());
			foreach (var objectToSend in aliases)
            {
				writer.WriteUTF(objectToSend);
			}
			writer.WriteShort((short)args.Count());
			foreach (var objectToSend in args)
            {
				writer.WriteUTF(objectToSend);
			}
			writer.WriteShort((short)descriptions.Count());
			foreach (var objectToSend in descriptions)
            {
				writer.WriteUTF(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var aliasesCount = reader.ReadUShort();
			var aliases_ = new string[aliasesCount];
			for (var aliasesIndex = 0; aliasesIndex < aliasesCount; aliasesIndex++)
			{
				aliases_[aliasesIndex] = reader.ReadUTF();
			}
			aliases = aliases_;
			var argsCount = reader.ReadUShort();
			var args_ = new string[argsCount];
			for (var argsIndex = 0; argsIndex < argsCount; argsIndex++)
			{
				args_[argsIndex] = reader.ReadUTF();
			}
			args = args_;
			var descriptionsCount = reader.ReadUShort();
			var descriptions_ = new string[descriptionsCount];
			for (var descriptionsIndex = 0; descriptionsIndex < descriptionsCount; descriptionsIndex++)
			{
				descriptions_[descriptionsIndex] = reader.ReadUTF();
			}
			descriptions = descriptions_;
		}

	}
}
