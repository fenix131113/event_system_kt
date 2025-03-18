using Core.StateMachine;
using Menu.View;

namespace Menu.States
{
    public class RemoveMenuState : AState
    {
        private readonly RemoveMenuView _removeMenuView;

        public RemoveMenuState(RemoveMenuView removeMenuView) => _removeMenuView = removeMenuView;

        public override void Enter()
        {
            _removeMenuView.OpenPanel();
        }

        public override void Exit()
        {
            _removeMenuView.ClosePanel();
        }
    }
}