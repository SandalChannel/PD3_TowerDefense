using Logic.Castles;
using Logic.Enemies;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class TowerDefenseUI : MonoBehaviour
    {
        private CastleHPUI _towerHPUI;
        private EnemiesLeftUI _enemyUI;
        private Castle Castle => LogicBase.GetAllInstancesOfType<Castle>()[0];

        private List<Enemy> Enemies => LogicBase.GetAllInstancesOfType<Enemy>();

        //reacts to the event
        protected void HandleCastlePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (Castle != null && e.PropertyName == nameof(Castle.Health))
            {
                _towerHPUI.ChangeHP((int)Castle.Health);
            }
        }

        private void Update()
        {
            _enemyUI.UpdateEnemyCount(Enemies.Count); //updates every frame, could be more efficient
        }

        private void Start()
        {
            Castle.PropertyChanged += HandleCastlePropertyChanged;

            VisualElement rootElement = GetComponent<UIDocument>().rootVisualElement;

            VisualElement TowerHPElement = rootElement.Q("GoalInfoPanel"); //finds any ui object with name GoalInfoPanelPanel
            VisualElement EnemiesLeftElement = rootElement.Q("EnemyInfoPanel");

            _towerHPUI = new CastleHPUI((int)Castle.Health, TowerHPElement); //creates a PlayerView class with the name White for the element of PlayerPanel1
            _enemyUI = new EnemiesLeftUI(Enemies.Count, EnemiesLeftElement);
        }
    }
}
