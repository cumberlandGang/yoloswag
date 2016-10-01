using System;

namespace Yoloswag
{
	public class Message
	{
		/// <summary>
		/// Who said this message
		/// </summary>
		/// <value>The author of the message</value>
		public Participant Author {get; set;}

		/// <summary>
		/// The body of the message itself
		/// </summary>
		/// <value>The content</value>
		public string Content { get; set;}

		/// <summary>
		/// Initializes a new instance of the <see cref="Yoloswag.Message"/> class.
		/// </summary>
		/// <param name="author">Author.</param>
		/// <param name="content">Content.</param>
		public Message (Participant author, string content)
		{
			Author = author;
			Content = content;
		}
	}
}

