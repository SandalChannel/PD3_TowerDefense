using System.ComponentModel;
using UnityEngine;
using Display.Libraries;
using Logic.Towers;
using Display.Enemies;
using System.Collections.Generic;
using PlasticGui.Configuration.CloudEdition.Welcome;

namespace Display.Towers
{
    public class DisplayTower : DisplayBase<Tower>
    {
        private float _damageCountdown = 0.5f;

        //all changed properties will react to this
        protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //only update the posistion if the changed property is this display's position
            if (e.PropertyName == nameof(Logic.Position) && this != null)
            {
                //update position
                transform.position = CoordinateConverter.HexToVector(Vector3.one, Logic.Position);
            }
        }

        protected override void HandleObjectDestroy()
        {
            if (this != null && this.gameObject != null)
            {
                Destroy(this.gameObject);
            }

            Destroy(this);
        }

        void Start()
        {
            HandlePropertyChanged(this, new PropertyChangedEventArgs(nameof(Logic.Position))); //runs the function once at spawn so the position is correctly synced
        }

        void Update()
        {
            _damageCountdown -= Time.deltaTime;

            if (_damageCountdown <= 0)
            {
                Logic.DamageEnemies();
                _damageCountdown = Logic.DamageDelay;
            }
        }
    }
}
