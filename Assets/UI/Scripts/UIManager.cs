using Logic.Castles;
using StatePattern;
using UI.States;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;


namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private UIDocument PauseDocument;

        [SerializeField]
        private UIDocument EndDocument;

        [SerializeField]
        private UIDocument Title;


        public StateMachine StateMachine { get; set; }
        public IState TitleState { get; private set; }
        public IState PlayState { get; private set; }
        public IState ReplayState { get; private set; }
        public IState PauseState { get; private set; }
        public IState EndState { get; private set; }


        private Castle Castle => LogicBase.GetAllInstancesOfType<Castle>()[0];


        void Start()
        {
            TitleState = new TitleState(this, Title);
            PlayState = new PlayState(this, PauseDocument);
            ReplayState = new ReplayState(this);
            PauseState = new PauseState(this, PauseDocument);
            EndState = new EndState(this, EndDocument);
            StateMachine = new StateMachine(PlayState);


            Castle.ObjectDestroyed += HandleCastleDestroy;
        }

        protected void HandleCastleDestroy()
        {
            StateMachine.MoveToState(EndState);
        }

        void Update()
        {
            StateMachine.Update();
        }

    }
}

