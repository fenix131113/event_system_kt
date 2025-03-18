using System;
using Core;
using PlayerResources;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Menu.View
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private ResourceDisplayItem displayItemPrefab;
        [SerializeField] private Transform content;
        [SerializeField] private Button resetResourcesButton;

        private ResourcesBank _resourcesBank;
        private Observables _observables;

        [Inject]
        private void Construct(ResourcesBank resourcesBank, Observables observables)
        {
            _resourcesBank = resourcesBank;
            _observables = observables;
        }

        private void Start()
        {
            foreach (var type in Enum.GetValues(typeof(ResourceType)))
                Instantiate(displayItemPrefab, content).Init((ResourceType)type, _resourcesBank, _observables);

            Bind();
        }

        private void OnDestroy() => Expose();

        public void OpenPanel()
        {
            mainPanel.SetActive(true);
        }

        public void ClosePanel()
        {
            mainPanel.SetActive(false);
        }

        private void OnResetButtonClicked()
        {
            foreach (var item in Enum.GetValues(typeof(ResourceType)))
                _resourcesBank.RemoveResources((ResourceType)item, int.MaxValue);
            
            _observables.ResetObservableSO.Notify();
        }
        
        private void Bind()
        {
            resetResourcesButton.onClick.AddListener(OnResetButtonClicked);
        }

        private void Expose() => resetResourcesButton.onClick.RemoveAllListeners();
    }
}