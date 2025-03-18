using Menu.States;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Menu.View
{
    public class UiSwitcherView : MonoBehaviour
    {
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button addMenuButton;
        [SerializeField] private Button removeMenuButton;
        
        private UiStateMachine _uiStateMachine;

        [Inject]
        private void Construct(UiStateMachine uiStateMachine) => _uiStateMachine = uiStateMachine;
        
        private void Start() => Bind();

        private void OnDestroy() => Expose();
        
        private void OnMainMenuButtonClicked()
        {
            _uiStateMachine.Switch(typeof(MainMenuState));
        }

        private void OnAddMenuButtonClicked()
        {
            _uiStateMachine.Switch(typeof(AddMenuState));
        }

        private void OnRemoveMenuButtonClicked()
        {
            _uiStateMachine.Switch(typeof(RemoveMenuState));
        }

        private void Bind()
        {
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
            addMenuButton.onClick.AddListener(OnAddMenuButtonClicked);
            removeMenuButton.onClick.AddListener(OnRemoveMenuButtonClicked);
        }

        private void Expose()
        {
            mainMenuButton.onClick.RemoveAllListeners();
            addMenuButton.onClick.RemoveAllListeners();
            removeMenuButton.onClick.RemoveAllListeners();
        }
    }
}