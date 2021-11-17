using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HackedDesign
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "CoffeeBreak/Settings/Game")]
    public class GameSettings : ScriptableObject
    {
        [Header("Game Play")]
        public float gameLength = 480.0f;
        public float maxWill = 100;
        public float kittyTimer = 2.0f;
        
        public string[] tasks = {
            "Obtain coffee",
            "Grind coffee",
            "Brew coffee",
            "Find milk",
            "Find a clean spoon",
            "Pour coffee",
            "Enjoy"
        };
    }
}