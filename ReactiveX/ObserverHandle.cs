using System;
using System.Collections.Generic;
using System.Text;

namespace ReactiveX
{
	public class ObserverHandle : IDisposable
	{
		private readonly Action _observerTermination;

		public ObserverHandle(Action observerTermination)
		{
			_observerTermination = observerTermination;
		}

		public void Dispose()
		{
			_observerTermination.Invoke();
		}
	}
}
