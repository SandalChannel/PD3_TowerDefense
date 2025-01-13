using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class EnemiesLeftUI
    {
        private VisualElement _EnemiesLeftPanel;

        public EnemiesLeftUI(int count, VisualElement rootElement)
        {
            _EnemiesLeftPanel = rootElement.Q("VisualElement");

            UpdateEnemyCount(count);
        }


        public void UpdateEnemyCount(int count)
        {
            //search for the label and change its text to HP
            Label text = _EnemiesLeftPanel.Q<Label>("EnemiesLeftText");
            text.text = count.ToString();
        }
    }
}

