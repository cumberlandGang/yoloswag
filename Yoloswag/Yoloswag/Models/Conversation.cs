using System;
using System.Collections.Generic;

using ChatterBotAPI;

using HumDrum.Collections;

namespace Yoloswag
{
	public class Conversation
	{
		/// <summary>
		/// The participants in the conversation, which are relayed information
		/// that happens within the conversation.
		/// </summary>
		/// <value>The participants</value>
		public List<Participant> Participants {get; set;}

		/// <summary>
		/// Factory used for generating new Chatbots.
		/// </summary>
		/// <value>The factory.</value>
		private ChatterBotFactory Factory { get; set;}

		public Conversation()
		{
			Participants = new List<Participant>();
			Factory = new ChatterBotFactory();
		}

		/// <summary>
		/// This will add a new bot to the conversation
		/// </summary>
		public void AddBot()
		{
			ChatterBot newBot = Factory.Create(ChatterBotType.CLEVERBOT);
			ChatterBotSession botSession = newBot.CreateSession();
			string botName = "bot" + Participants.Count.ToString ();

			Participants.Add(new Participant(botName, botSession));
		}

		/// <summary>
		/// This will generate a conversation, using "hello" as a seed.
		/// </summary>
		/// <returns>The conversation</returns>
		/// <param name="length">The length, in lines, of the conversation</param></param>
		public IEnumerable<Message> GenerateConversation(int length)
		{
			return GenerateConversation(length, "Hello");
		}

		/// <summary>
		/// Generates a conversation with the given string as a seed.
		/// </summary>
		/// <returns>The conversation</returns>
		/// <param name="length">The length of the conversation, in lines.</param>
		/// <param name="seed">What to originally tell the first bot.</param>
		public IEnumerable<Message> GenerateConversation(int length, string seed)
		{
			List<Message> log = new List<Message>();

			Message last = Participants.First (x => true).Think (seed);

			for (int i = 0; i < length; i++)
			{
				foreach (Participant participant in Participants)
				{
					log.Add(last);
					last = participant.Think (last.Content);
				}
			}

			return log;
		}
	}
}
