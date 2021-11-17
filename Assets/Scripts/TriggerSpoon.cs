using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HackedDesign
{
    public class TriggerSpoon : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                Game.Instance.Data.HasSpoon = true;
                this.gameObject.SetActive(false);
            }
            
        }
    }
}