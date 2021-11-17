using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HackedDesign
{
    public class PlayerController : MonoBehaviour
    {
        private float movement;
        private float facing;
        private bool duck;
        private bool attack;

        [SerializeField] private Animator animator;
        [SerializeField] private Animator slashAnimator;
        [SerializeField] private new Rigidbody2D rigidbody;
        [SerializeField] private new BoxCollider2D collider2D;

        [Header("Settings")]
        [SerializeField] private PlayerSettings settings;
        [SerializeField] private LayerMask layerMask;

        private float slashTime = 0;



        void Awake()
        {
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

        public void OnMove(InputValue input)
        {
            movement = input.Get<float>();

            if (movement != 0)
            {
                facing = movement;
                transform.right = new Vector2(facing, 0);
            }
        }

        public void OnDuck(InputValue input)
        {
            if (Game.Instance.State.Playing)
            {
                duck = input.Get<float>() > float.Epsilon;
            }
        }

        public void OnAttack()
        {
            if (Game.Instance.State.Playing)
            {
                attack = true;
            }
        }

        public void Reset()
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }

        public void Hit(float amount)
        {
            Game.Instance.Data.Will -= amount;

            if(Game.Instance.Data.Will <= 0)   
            {
                Game.Instance.SetGameOver();
            }
        }

        // Update is called once per frame
        public void UpdateBehaviour()
        {

            UpdateDuck();
            Attack();
            Animate();

        }

        public void FixedUpdateBehaviour()
        {
            Movement();
            slashAnimator.SetBool("slash", false);
        }

        private void Attack()
        {
            if (attack && Time.time > slashTime)
            {
                slashTime = Time.time + settings.slashTimer;
                //Debug.Log("Attack");
                slashAnimator.SetBool("slash", true);
                RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position + new Vector3(0, 1.5f, 0), transform.right, settings.slashDistance);
                Debug.DrawRay(transform.position + new Vector3(0, 1.5f, 0), transform.right, Color.red, 0.5f);

                foreach (var hit in hits)
                {
                    if (hit.collider.CompareTag("Enemy"))
                    {
                        //Debug.Log(hit.collider.name);
                        hit.collider.GetComponent<Enemy>().Hit(settings.slashDamage);
                        hit.collider.attachedRigidbody.AddForce(new Vector2(transform.right.x, transform.right.y) * settings.slashForce, ForceMode2D.Force);
                    }
                }

                // if(hit.collider != null)
                // {
                //     Debug.Log(hit.collider.name);
                // }


            }
            attack = false;
        }

        private void UpdateDuck()
        {
            collider2D.offset = duck ? settings.duckColliderOffset : settings.standingColliderOffset;
            collider2D.size = duck ? settings.standingColliderSize : settings.standingColliderSize;
        }


        private void Movement()
        {
            if (!duck)
            {
                Vector3 newPosition = transform.position + (new Vector3(movement, 0, 0) * Time.fixedDeltaTime * settings.movementSpeed);
                rigidbody.MovePosition(newPosition);
            }
        }

        private void Animate()
        {

            animator.SetFloat("speed", duck ? 0 : Mathf.Abs(movement));
            animator.SetBool("duck", duck);
        }
    }
}