using System;
using System.Collections.Generic;

using ChatterBotAPI;

namespace Yoloswag
{
	public class Conversation
	{
		/// <summary>
		/// The participants in the conversation, which are relayed information
		/// that happens within the conversation.
		/// </summary>
		/// <value>The participants</value>
		public List<ChatterBotSession> Participants {get; set;}

		private ChatterBotFactory Factory { get; set;}

		public Conversation()
		{
			Participants = new List<ChatterBotSession>();
			Factory = new ChatterBotFactory();
		}

		/// <summary>
		/// This will add a new bot to the conversation
		/// </summary>
		public void AddBot()
		{
			ChatterBot newBot = Factory.Create(ChatterBotType.CLEVERBOT);
			ChatterBotSession botSession = newBot.CreateSession();

			Participants.Add(botSession);
		}

		/// <summary>
		/// This will generate a conversation, using "hello" as a seed.
		/// </summary>
		/// <returns>The conversation</returns>
		/// <param name="length">The length, in lines, of the conversation</param></param>
		public IEnumerable<string> GenerateConversation(int length)
		{
			return GenerateConversation(length, "Hello");
		}

		/// <summary>
		/// Generates a conversation with the given string as a seed.
		/// </summary>
		/// <returns>The conversation</returns>
		/// <param name="length">The length of the conversation, in lines.</param>
		/// <param name="seed">What to originally tell the first bot.</param>
		public IEnumerable<string> GenerateConversation(int length, string seed)
		{
			List<string> log = new List<string>();

			string last = Participants.ToArray()[0].Think(seed);
			for (int i = 0; i < length; i++)
			{
				foreach (ChatterBotSession session in Participants)
				{
					log.Add(last);
					last = session.Think(last);
				}
			}

			return log;
		}
	}
}
