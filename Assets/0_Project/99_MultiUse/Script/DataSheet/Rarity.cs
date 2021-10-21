using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle
{
    public enum Rarity
    {
        None = -1,

        Common = 0,
        Uncommon = 1,
        Rare = 2,
        Unique = 3,
        Essential = 4,
    }
    public static class RarityMethod
    {
        public static Color ToColor(this Rarity rarity)
        {
            Color rarityColor = new Color(0.95f, 0.8f, 0.6f);   //None

            switch (rarity)
            {
                case Rarity.Common:
                    rarityColor = new Color(1f, 1f, 1f); break;
                case Rarity.Uncommon:
                    rarityColor = new Color(0.05f, 0.9f, 0f); break;
                case Rarity.Rare:
                    rarityColor = new Color(0.7f, 0.31f, 0.98f); break;
                case Rarity.Unique:
                    rarityColor = new Color(1f, 0.88f, 0f); break;
                case Rarity.Essential:
                    rarityColor = new Color(0f, 0.3f, 0.9f); break;

            }

            return rarityColor;
        }
    }
}
