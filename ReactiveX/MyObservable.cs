using System;
using System.Collections.Generic;
using System.Text;

namespace ReactiveX
{
	public class MyObservable<T> : IObservable<T>
	{
		private readonly List<IObserver<T>> _observers = new List<IObserver<T>>();

		public IDisposable Subscribe(IObserver<T> observer)
		{
			_observers.Add(observer);
			return new ObserverHandle(()=>_observers.Remove(observer));
		}

		public void SendNext(T message)
		{
			foreach (var observer in _observers)
			{
				observer.OnNext(message);
			}
		}

		public void SendError(Exception error)
		{
			foreach (var observer in _observers)
			{
				observer.OnError(error);
			}
		}

		public void SendCompleted()
		{
			foreach (var observer in _observers)
			{
				observer.OnCompleted();
			}
		}
	}
}
