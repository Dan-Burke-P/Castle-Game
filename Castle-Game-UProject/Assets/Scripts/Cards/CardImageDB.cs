using System.Collections.Generic;
using UnityEngine;

namespace Cards{
    [CreateAssetMenu(fileName = "CardImageDB", menuName = "HANDUI", order = 0)]
    public class CardImageDB : ScriptableObject
    {
        public Sprite calvaryArt;
        public Sprite medicArt;
        public Sprite rangerArt;
        public Sprite siegeArt;
        public Sprite soldierArt;

        private static CardImageDB _instance;

        private void OnEnable()
        {
            calvaryArt = createSprite("Images/CalvaryArt");
            medicArt = createSprite("Images/MedicArt");
            rangerArt = createSprite("Images/RangerArt");
            siegeArt = createSprite("Images/SiegeArt");
            soldierArt = createSprite("Images/SoldierArt");
        }

        private Sprite createSprite(string path)
        {
            var texture = Resources.Load<Texture2D>(path);
            if (texture != null)
            {
                return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }

            return null;
        }

        public static CardImageDB Instance()
        {
            if (_instance == null)
            {
                _instance = CreateInstance<CardImageDB>();
                return _instance;
            }
            else {
                return _instance;
            }
        }
    }
}