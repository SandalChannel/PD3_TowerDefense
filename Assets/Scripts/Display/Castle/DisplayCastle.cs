using Logic.TileMap;
using System.ComponentModel;
using UnityEngine;
using Logic.Castles;
using TMPro;
using System.Collections;

namespace Display.Castles
{
    public class DisplayCastle : DisplayBase<Castle>
    {
        [SerializeField]
        private Vector2Int _coordinate;
        public Coordinates MapCoordinate { get => new(_coordinate.x, _coordinate.y); set { _coordinate = new(value.X, value.Y); } }

        [SerializeField] private float Health = 100f;

        [SerializeField] private TextMeshPro _healthText;

        private Color _originalColour;

        private Color _hitColour = Color.red;

        //all changed properties will react to this
        protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
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
            }

            Destroy(this);
        }

        void Start()
        {
            this.transform.position = Libraries.CoordinateConverter.HexToVector(this.transform.lossyScale, Logic.Position);

            _originalColour = this.GetComponentInChildren<Renderer>().material.color;
        }

        IEnumerator DamageFlash(float flashDuration)
        {
            float timer = 0f;
            while (timer < flashDuration)
            {
                timer += Time.deltaTime;
                float progress = timer / flashDuration;
                float sin = Mathf.Sin(progress * Mathf.PI);

                this.GetComponentInChildren<Renderer>().material.color = Color.Lerp(_originalColour, _hitColour, sin);
                yield return null;
            }
        }
    }
}
