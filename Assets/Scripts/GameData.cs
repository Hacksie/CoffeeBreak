using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HackedDesign
{
    [System.Serializable]
    public class GameData 
    {
        
        public float Time = 0;
        public float Will = 100;

        public void Reset(GameSettings settings)
        {
            Time = settings.gameLength;
            Will = settings.maxWill;
        }
    }
}