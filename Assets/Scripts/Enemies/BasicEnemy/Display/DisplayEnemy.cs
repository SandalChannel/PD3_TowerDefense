using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using UnityEngine;

public class DisplayEnemy : DisplayBase<Enemy>
{
    public GameObject Prefab;

    private float movementCountdown;

    //all changed properties will react to this
    protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        //only update the posistion if the changed property is this display's position
        if (e.PropertyName == nameof(Logic.Position))
        {
            //update position
            transform.position = CoordinateConverter.HexToVector(Vector3.one , Logic.Position);
        }
    }

    void Start()
    {
        movementCountdown = Logic.MovementDelay;
        HandlePropertyChanged(this, new PropertyChangedEventArgs(nameof(Logic.Position))); //runs the function once at spawn so the position is correctly synced
    }

    void Update()
    {
        movementCountdown -= Time.deltaTime;
        if (movementCountdown < 0f && Logic != null)
        {
            Logic.AdvancePath();
            movementCountdown = Logic.MovementDelay;
        }
    }
}
