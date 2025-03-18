using Core.StateMachine;
using Menu.View;

namespace Menu.States
{
    public class MainMenuState : AState
    {
        private readonly MainMenuView _view;
        
        public MainMenuState(MainMenuView view) => _view = view;

        public override void Enter()
        {
            _view.OpenPanel();
        }

        public override void Exit()
        {
            _view.ClosePanel();
        }
    }
}