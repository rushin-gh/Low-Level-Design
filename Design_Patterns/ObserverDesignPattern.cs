using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public class ObserverDesignPattern
    {
    }
}

/*
Two Ways of achieving it
1. Push Model -> Pushes its updated state to subscriber
2. Pull Model -> Observable holds a reference to Observable and Observable just updates Observer that there is change in state
                and observer checks the referenced object
 */

namespace Push_Model
{
    public interface IObservable
    {
        public void Add(IObserver observer);

        public void Remove(IObserver obeserver);

        public void Notify();
    }

    public interface IObserver
    {
        public void Update(int newState);
    }

    public class Observable : IObservable
    {
        public int someStateVar { get; set; }

        private List<IObserver> _observers = new List<IObserver>();

        public void Add(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Remove(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            // Notify subscriber on update
            _observers.ForEach(x => x.Update(someStateVar));
        }

        public void Method()
        {
            someStateVar++;
            Notify();
        }
    }

    public class Observer : IObserver
    {
        public void Update(int newState)
        {
            // State variable updated do intended action
        }
    }
}

namespace Pull_Model
{
    public interface IObservable
    {
        public void Add(IObserver observer);

        public void Remove(IObserver obeserver);

        public void Notify();
    }

    public interface IObserver
    {
        public void Update();
    }

    public class Observable : IObservable
    {
        public int someStateVar { get; set; }

        private List<IObserver> _observers = new List<IObserver>();

        public void Add(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Remove(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            // Notify subscriber on update
            _observers.ForEach(x => x.Update());
        }

        public void Method()
        {
            someStateVar++;
            Notify();
        }
    }



    public class Observer : IObserver
    {
        public IObservable observable;

        public void Update()
        {
            // State variable updated do intended action
        }
    }
}




