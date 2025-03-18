using System;
using PlayerResources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Menu.View
{
    public class RemoveMenuView : MonoBehaviour
    {
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private TMP_Dropdown resourcesDropdown;
        [SerializeField] private TMP_InputField resourcesCountInput;
        [SerializeField] private Button removeButton;
        
        private ResourcesBank _resourcesBank;

        [Inject]
        private void Construct(ResourcesBank resourcesBank) => _resourcesBank = resourcesBank;
        
        private void Start()
        {
            foreach(var item in Enum.GetNames(typeof(ResourceType)))
                resourcesDropdown.options.Add(new TMP_Dropdown.OptionData(item));

            Bind();
            ResetPanel();
        }

        private void OnDestroy() => Expose();

        private void ResetPanel()
        {
            resourcesDropdown.value = 0;
            resourcesCountInput.text = "0";
            resourcesDropdown.RefreshShownValue();
        }
        
        public void OpenPanel()
        {
            mainPanel.SetActive(true);
        }

        public void ClosePanel()
        {
            mainPanel.SetActive(false);
        }
        
        private void OnRemoveButtonClicked()
        {
            if(int.Parse(resourcesCountInput.text) == 0)
                return;
            
            _resourcesBank.RemoveResources(
                (ResourceType)Enum.Parse(typeof(ResourceType), resourcesDropdown.options[resourcesDropdown.value].text),
                int.Parse(resourcesCountInput.text));
            
            ResetPanel();
        }

        private void Bind() => removeButton.onClick.AddListener(OnRemoveButtonClicked);

        private void Expose() => removeButton.onClick.RemoveAllListeners();
    }
}