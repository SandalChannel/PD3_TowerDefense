using System.Collections;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using Display.Libraries;
using Logic.Enemies;
using Logic.Game;

namespace Display.Enemies
{
    public class DisplayEnemy : DisplayBase<Enemy>
    {
        [SerializeField] TextMeshPro _healthText;

        Color _originalColour;

        Color _hitColour = Color.red;

        private float _movementCountdown;

        //all changed properties will react to this
        protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //only update the posistion if the changed property is this display's position
            if (e.PropertyName == nameof(Logic.Position) && this != null)
            {
                //update position
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
            if (this != null && this.gameObject != null)
            {
                Destroy(this.gameObject);
                StopAllCoroutines();
            }

            Destroy(this);
        }

        private void Start()
        {
            _movementCountdown = Logic.ActionDelay;
            HandlePropertyChanged(this, new PropertyChangedEventArgs(nameof(Logic.Position))); //runs the function once at spawn so the position is correctly synced

            _originalColour = this.GetComponent<Renderer>().material.color;

            
        }

        private void Update()
        {
            _movementCountdown -= Time.deltaTime;
            if (_movementCountdown < 0f && Logic != null && !GameLogic.IsReplaying)
            {
                Logic.StateMachine.Update();
                _movementCountdown = Logic.ActionDelay;
            }
        }

        private IEnumerator MoveAnimation(float moveDuration)
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

        private IEnumerator DamageFlash(float flashDuration)
        {
            float timer = 0f;
            while (timer < flashDuration)
            {
                timer += Time.deltaTime;
                float progress = timer / flashDuration;
                float sin = Mathf.Sin(progress * Mathf.PI);


                this.GetComponent<Renderer>().material.color = Color.Lerp(_originalColour, _hitColour, sin);
                yield return null;
            }
        }
    }
}
