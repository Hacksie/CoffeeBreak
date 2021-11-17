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
        private float health;
        private float slashTime = 0;
        private bool attack = false;

        void Awake()
        {
            health = settings.maxHealth;
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
            Attack();
            Animate();
        }

        public void FixedUpdate()
        {
            Movement();
        }

        public void Hit(float damage)
        {
            health -= damage;
            attack = false;
            if (health <= 0)
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

        private void Attack()
        {
            if (!attack && Time.time > slashTime) // Check for slash
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position + new Vector3(0, 1.5f, 0), transform.right, settings.slashDistance);
                /// FIXME: Linq
                foreach (var hit in hits)
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        attack = true;
                        slashTime = Time.time + settings.slashDelay;
                        Debug.Log("Attack, starting delay");
                    }

                    /*
                    if (Time.time > slashTime)
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


                    }*/
                }
            }

            if(attack && Time.time > slashTime) // Delay over, try and attack
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position + new Vector3(0, 1.5f, 0), transform.right, settings.slashDistance);

                foreach (var hit in hits)
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        Debug.Log("Attack player");
                        Game.Instance.Player.Hit(settings.slashDamage);
                        attack = false;
                        slashTime = Time.time + settings.slashTimer;
                    }
                }
            }
            // else delaying
        }

        private void Animate()
        {

            animator.SetFloat("speed", 1);
            animator.SetBool("duck", false);
        }
    }
}