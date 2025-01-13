using Logic.TileMap;
using System.ComponentModel;
using UnityEngine;
using Logic.Castles;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using Display.Enemies;
using Logic.Enemies;
using Logic.Game;

namespace Display.Castles
{
    public class DisplayCastle : DisplayBase<Castle>
    {
        [SerializeField]
        public Vector2Int Coordinate;
        public Coordinates MapCoordinate => new Coordinates(Coordinate.x, Coordinate.y);

        [SerializeField] private float Health = 100f;

        [SerializeField] private TextMeshPro _healthText;

        Color originalColour;

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
            if (this.gameObject != null)
            {
                Destroy(this.gameObject);
            }

            Destroy(this);
        }

        void Awake()
        {
            Logic = new Castle(MapCoordinate, Health);
            HandlePropertyChanged(this, new PropertyChangedEventArgs(nameof(Logic.Position))); //runs the function once at spawn so the position is correctly synced

            originalColour = this.GetComponentInChildren<Renderer>().material.color;
        }

        IEnumerator DamageFlash(float flashDuration)
        {
            float timer = 0f;
            while (timer < flashDuration)
            {
                timer += Time.deltaTime;
                float progress = timer / flashDuration;
                float sin = Mathf.Sin(progress * Mathf.PI);


                this.GetComponentInChildren<Renderer>().material.color = Color.Lerp(originalColour, Color.red, sin);
                yield return null;
            }
        }
    }
}
