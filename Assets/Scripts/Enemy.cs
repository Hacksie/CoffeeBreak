using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HackedDesign
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private new Rigidbody2D rigidbody;
        [SerializeField] private new BoxCollider2D collider2D;

        [Header("Settings")]
        [SerializeField] private EnemySettings settings;

        private float movement = 0.0f;
        private float hits;

        void Awake()
        {
            hits = settings.maxHits;
            if (animator == null)
            {
                animator = GetComponent<Animator>();
            }

            if (rigidbody == null)
            {
                rigidbody = GetComponent<Rigidbody2D>();
            }

            if (collider2D == null)
            {
                collider2D = GetComponent<BoxCollider2D>();
            }

            Reset();
        }      

        private void Reset()
        {

        }  

        public void Update()
        {
            UpdateFacing();
            Animate();
        }

        public void FixedUpdate()
        {
            Movement();
        }

        public void Hit()
        {
            hits--;
            if(hits <= 0)   
            {
                Destroy(gameObject);
            }
        }

        private void UpdateFacing()
        {
            var facing = Game.Instance.Player.transform.position - transform.position;
            transform.right = facing;
        }

        private void Movement()
        {
            Vector3 newPosition = transform.position + (transform.right * Time.fixedDeltaTime * settings.movementSpeed);
            rigidbody.MovePosition(newPosition);
        }

        private void Animate()
        {

            animator.SetFloat("speed", 1);
            animator.SetBool("duck", false);
        }        
    }
}