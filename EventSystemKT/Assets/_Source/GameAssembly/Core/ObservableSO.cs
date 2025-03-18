using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "ObservableSO", menuName = "Configs/ObservableSO")]
    public class ObservableSO : ScriptableObject
    {
        private readonly List<IGameEventListener> _listeners = new();

        private void OnDestroy() => _listeners.Clear();

        public void RegisterObject(IGameEventListener listener)
        {
            if(_listeners.Contains(listener))
                return;
            
            _listeners.Add(listener);
        }

        public void RemoveObserver(IGameEventListener listener)
        {
            if(!_listeners.Contains(listener))
                return;
            
            _listeners.Remove(listener);
        }

        public void Notify()
        {
            foreach (var listener in _listeners)
                listener.OnNotified();
        }
    }
}