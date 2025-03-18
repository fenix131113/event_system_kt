using Core;
using TMPro;
using UnityEngine;

namespace PlayerResources
{
    public class ResourceDisplayItem : MonoBehaviour, IGameEventListener
    {
        [SerializeField] private TMP_Text titleLabel;
        [SerializeField] private TMP_Text countLabel;
        
        private ResourceType _resourceType;
        private ResourcesBank _resourcesBank;
        private Observables _observables;
        
        public void Init(ResourceType resourceType, ResourcesBank resourcesBank, Observables observables)
        {
            _resourcesBank = resourcesBank;
            _resourceType = resourceType;
            _observables = observables;
            titleLabel.text = _resourceType.ToString();
        }

        private void Start()
        {
            UpdateView();
            Bind();
        }

        private void UpdateView() => countLabel.text = _resourcesBank.GetResourceCount(_resourceType).ToString();
        
        public void OnNotified() => UpdateView();

        private void Bind()
        {
            _observables.AddObservableSO.RegisterObject(this);
            _observables.ResetObservableSO.RegisterObject(this);
            _observables.RemoveObservableSO.RegisterObject(this);
        }
    }
}