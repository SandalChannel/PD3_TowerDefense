using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using TMPro;
using UnityEngine;

public class DisplayEnemy : DisplayBase<Enemy>
{
    [SerializeField] TextMeshPro _healthText;
    
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
        //only update the health view if the changed property is this display's health
        if (e.PropertyName == nameof(Logic.Health))
        {
            _healthText.text = Logic.Health.ToString();
            
            //update health
            if (Logic.Health <= 0 && this != null)
            {
                Logic.IsAlive = false;
                Destroy(this.gameObject);
            }
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
