using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ReactiveX
{
	public class ActionObserver<T> : IObserver<T>
	{

		private readonly Action<T> _onNext;
		private readonly Action<Exception> _onException;
		private readonly Action _onComplete;

		public ActionObserver(Action<T> onNext, Action<Exception> onException, Action onComplete)
		{
			_onNext = onNext;
			_onException = onException;
			_onComplete = onComplete;
		}

		public void OnCompleted()
		{
			_onComplete.Invoke();
		}

		public void OnError(Exception error)
		{
			_onException.Invoke(error);
		}

		public void OnNext(T value)
		{
			_onNext.Invoke(value);
		}
	}
}
