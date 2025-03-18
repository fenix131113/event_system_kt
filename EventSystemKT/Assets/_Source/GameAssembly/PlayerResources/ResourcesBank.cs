using System;
using System.Collections.Generic;
using Core;
using UnityEngine;
using VContainer;

namespace PlayerResources
{
    public class ResourcesBank
    {
        private readonly Dictionary<ResourceType, int> _resources = new();

        private readonly Observables _observables;

        [Inject]
        public ResourcesBank(Observables observables)
        {
            _observables = observables;
            
            foreach (var item in Enum.GetValues(typeof(ResourceType)))
                _resources.Add((ResourceType)item, 0);
        }

        public int GetResourceCount(ResourceType resourceType) => _resources[resourceType];

        public void AddResource(ResourceType resourceType, int amount)
        {
            _resources[resourceType] =
                Mathf.Clamp(_resources[resourceType] + amount, 0, int.MaxValue);
            
            _observables.AddObservableSO.Notify();
        }

        public void RemoveResources(ResourceType resourceType, int amount)
        {
            _resources[resourceType] =
                Mathf.Clamp(_resources[resourceType] - amount, 0, int.MaxValue);
            
            _observables.RemoveObservableSO.Notify();
        }
    }
}