using System;
using System.Collections.Generic;
using System.Text;

namespace ReactiveX
{
	public class Message<TPayload> where TPayload : class
	{
		public TPayload Payload { get; }
		private DateTime _createdOnUtc;

		public Message(TPayload payload)
		{
			Payload = payload;
			_createdOnUtc = DateTime.UtcNow;
		}

		public override string ToString()
		{
			return Payload.ToString();
		}
	}
}
