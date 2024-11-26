using System.ComponentModel;
using UnityEngine;

public class DisplayTower : DisplayBase<Tower>
{
    private float _damageCountdown = 0.5f;
    
    //all changed properties will react to this
    protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        //only update the posistion if the changed property is this display's position
        if (e.PropertyName == nameof(Logic.Position))
        {
            //update position
            transform.position = CoordinateConverter.HexToVector(Vector3.one, Logic.Position);
        }
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
