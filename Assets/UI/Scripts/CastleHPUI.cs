using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class CastleHPUI
    {
        private VisualElement _TowerHPPanel;

        public CastleHPUI(int HP, VisualElement rootElement)
        {
            _TowerHPPanel = rootElement.Q("VisualElement");

            ChangeHP(HP);
        }


        public void ChangeHP(int HP)
        {
            //search for the label and change its text to HP
            Label HPText = _TowerHPPanel.Q<Label>("CastleHPText");
            HPText.text = HP.ToString();
        }
    }
}
