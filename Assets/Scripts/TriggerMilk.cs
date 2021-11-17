using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HackedDesign
{
    public class TriggerMilk : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                Game.Instance.Data.HasMilk = true;
                this.gameObject.SetActive(false);
            }
            
        }
    }
}