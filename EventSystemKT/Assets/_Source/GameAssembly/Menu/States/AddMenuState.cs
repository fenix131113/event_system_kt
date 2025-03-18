using Core.StateMachine;
using Menu.View;
using VContainer;

namespace Menu.States
{
    public class AddMenuState : AState
    {
        private readonly AddMenuView _addMenuView;

        [Inject]
        public AddMenuState(AddMenuView addMenuView) => _addMenuView = addMenuView;

        public override void Enter()
        {
            _addMenuView.OpenPanel();
        }

        public override void Exit()
        {
            _addMenuView.ClosePanel();
        }
    }
}