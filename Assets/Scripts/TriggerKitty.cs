using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HackedDesign
{
    public class TriggerKitty : MonoBehaviour
    {
        [SerializeField] private GameObject purrSprite;

        private float timer = 0;

        void Update()
        {
            if(purrSprite.activeInHierarchy && Time.time > timer)
            {
                purrSprite.SetActive(false);
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                purrSprite.SetActive(true);
                timer = Time.time + Game.Instance.Settings.kittyTimer;
                
                //this.gameObject.SetActive(false);
            }
            
        }
    }
}