using Menu.States;
using Menu.View;
using VContainer;
using VContainer.Unity;

namespace Menu
{
    public class UiStatesRegister : IInitializable
    {
        private readonly UiStateMachine _stateMachine;
        private readonly MainMenuView _mainMenuView;
        private readonly AddMenuView _addMenuView;
        private readonly RemoveMenuView _removeMenuView;
        
        [Inject]
        public UiStatesRegister(UiStateMachine uiStateMachine, MainMenuView mainMenuMainMenuView, AddMenuView addMenuView, RemoveMenuView removeMenuView)
        {
            _stateMachine = uiStateMachine;
            _mainMenuView = mainMenuMainMenuView;
            _addMenuView = addMenuView;
            _removeMenuView = removeMenuView;
        }

        public void Initialize()
        {
            _stateMachine.RegisterState(new MainMenuState(_mainMenuView));
            _stateMachine.RegisterState(new AddMenuState(_addMenuView));
            _stateMachine.RegisterState(new RemoveMenuState(_removeMenuView));
            
            _stateMachine.Switch(typeof(MainMenuState));
        }
    }
}