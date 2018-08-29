using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace ReactiveX
{
	class Program
	{
		static async Task Main(string[] args)
		{
			//SubjectObservable();

			MyObservableTest();

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}

		#region MyObservable

		private static void MyObservableTest()
		{
			MyObservable<Message<string>> myObservable = new MyObservable<Message<string>>();
			ActionObserver<Message<string>> observer = new ActionObserver<Message<string>>(Handle, HandleException, HandleComplete);

			var observerHandle = myObservable.Subscribe(observer);
			
			myObservable.SendNext(new Message<string>("Test"));
			myObservable.SendError(new Exception("Test Exception"));
			myObservable.SendNext(new Message<string>("Test after exception"));
			myObservable.SendCompleted();
			myObservable.SendNext(new Message<string>("After completed"));

			observerHandle.Dispose();
		}

		#endregion

		#region Subject observable

		static void SubjectObservable()
		{
			Subject<Message<string>> s = new Subject<Message<string>>();
			s.Subscribe(Handle, HandleException, HandleComplete);

			s.OnNext(new Message<string>("Test1"));
			s.OnNext(new Message<string>("Test2"));
			s.OnNext(new Message<string>("Test3"));
			s.OnNext(new Message<string>("Test4"));
			s.OnCompleted();
			s.OnNext(new Message<string>("After completion"));
		}

		#endregion

		#region Handlers

		static void HandleComplete()
		{
			Console.WriteLine("Complete");
		}

		static void HandleException(Exception exception)
		{
			Console.WriteLine(exception);
		}

		static void Handle<T>(Message<T> message) where T : class
		{

			Console.WriteLine(message.ToString());
		}

		#endregion

	}
}
