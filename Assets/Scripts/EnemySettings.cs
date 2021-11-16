using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HackedDesign
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "CoffeeBreak/Settings/Enemy")]
    public class EnemySettings : ScriptableObject
    {
        public float movementSpeed = 3.0f;
        public Vector2 standingColliderSize = new Vector2(1, 3);
        public Vector2 standingColliderOffset = new Vector2(0, 1.5f);
        public Vector2 duckColliderSize = new Vector2(1, 2);
        public Vector2 duckColliderOffset = new Vector2(0, 1.0f);
        public float slashForce = 25.0f;
        public int maxHits = 3;

    }
}