using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using TMPro;
using UnityEngine;
using Display.Libraries;
using Logic.Enemies;
using Logic.Libraries;
using Display.Game;
using Logic.TileMap;
using Logic.Game;

namespace Display.Enemies
{
    public class DisplayEnemy : DisplayBase<Enemy>
    {
        [SerializeField] TextMeshPro _healthText;

        Color originalColour;

        private float movementCountdown;

        //all changed properties will react to this
        protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //only update the posistion if the changed property is this display's position
            if (e.PropertyName == nameof(Logic.Position))
            {
                //update position
                //transform.position = CoordinateConverter.HexToVector(Vector3.one , Logic.Position);
                

                StartCoroutine(MoveAnimation(0.2f));
            }
            //only update the health view if the changed property is this display's health
            if (e.PropertyName == nameof(Logic.Health) && this != null)
            {
                StartCoroutine(DamageFlash(0.2f));
                _healthText.text = Logic.Health.ToString();
            }

        }

        protected override void HandleObjectDestroy()
        {
            if (this.gameObject != null)
            {
                Destroy(this.gameObject);
                StopAllCoroutines();
            }

            Destroy(this);
        }

        void Start()
        {
            movementCountdown = Logic.ActionDelay;
            HandlePropertyChanged(this, new PropertyChangedEventArgs(nameof(Logic.Position))); //runs the function once at spawn so the position is correctly synced

            originalColour = this.GetComponent<Renderer>().material.color;

            
        }

        void Update()
        {
            movementCountdown -= Time.deltaTime;
            if (movementCountdown < 0f && Logic != null)
            {
                //Logic.AdvancePath();
                //Logic.TryAttack();
                Logic.StateMachine.Update();
                movementCountdown = Logic.ActionDelay;
            }
        }

        IEnumerator MoveAnimation(float moveDuration)
        {
            Vector3 startPosition = CoordinateConverter.HexToVector(this.transform.lossyScale, Logic.PrevPosition);
            Vector3 endPosition = CoordinateConverter.HexToVector(this.transform.lossyScale, Logic.Position);

            float timer = 0f;
            while (timer < moveDuration)
            {
                timer += Time.deltaTime;
                float progress = timer / moveDuration;

                this.transform.position = Vector3.Lerp(startPosition, endPosition, progress);
                yield return null; //needs to be in the for loop so that it doesnt execute the whole for loop in one frame
            }
        }

        IEnumerator DamageFlash(float flashDuration)
        {
            float timer = 0f;
            while (timer < flashDuration)
            {
                timer += Time.deltaTime;
                float progress = timer / flashDuration;
                float sin = Mathf.Sin(progress * Mathf.PI);


                this.GetComponent<Renderer>().material.color = Color.Lerp(originalColour, Color.red, sin);
                yield return null;
            }
        }
    }
}
