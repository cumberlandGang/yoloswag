using System;
using ChatterBotAPI;

namespace Yoloswag
{
	/// <summary>
	/// A participant in the conversation
	/// </summary>
	public class Participant
	{
		/// <summary>
		/// The name for this chat bot
		/// </summary>
		/// <value>The name</value>
		public string Name {get; set;}

		/// <summary>
		/// The actual reference to the chat bot
		/// </summary>
		/// <value>The bot.</value>
		public ChatterBotSession Bot {get; set;}

		/// <summary>
		/// Initializes a new instance of the <see cref="Yoloswag.Participant"/> class.
		/// </summary>
		/// <param name="name">The name for this chatbot</param>
		/// <param name="bot">The bot itself</param>
		public Participant (string name, ChatterBotSession bot)
		{
			Name = name;
			Bot = bot;
		}

		/// <summary>
		/// Generates a message using this particpant with a given input
		/// </summary>
		/// <param name="seed">The seed to make the bot think about</param>
		public Message Think(string seed) 
		{
			return new Message (this, Bot.Think (seed));
		}
	}
}

