using System;

namespace Yoloswag
{
	/// <summary>
	/// The "Holy-Shit-I-Can't-Believe-I-Had-To-Make-This" class
	/// </summary>
	public class Incrementor
	{
		/// <summary>
		/// The freaking incremented integer
		/// </summary>
		/// <value>One more than whatever the hell you gave the constructor</value>
		public int Value {get; set;}

		/// <summary>
		/// Makes one more of these ungodly unnecessary class instances
		/// </summary>
		/// <param name="value">Whatever integer you want to commit to this incredible anti-pattern</param>
		public Incrementor (int value)
		{
			Value = value + 1; // Man that was intense
		}
	}
}

