using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class Player : MonoBehaviour
    {
        Vector2 _movement;
        Rigidbody2D _rb;
        [SerializeField] float speed = 5f;
        public bool isMoving;
        public float health = 100f;
        public float cooldown = 2f;

        public Enemy.Enemy ClosestEnemy = null;
        
        private void Awake()
        {
            _rb = this.gameObject.GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            _movement.x = horizontal;
            _movement.y = vertical;

            if (_movement.x != 0 || _movement.y != 0) //check for isMoving
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                Signals.Signals.Instance.OnSkillUse?.Invoke("Fireball");    
            }
            if (Input.GetButtonDown("Fire2"))
            {
                Signals.Signals.Instance.OnSkillUse?.Invoke("Iceball");
            }
        }
        
        private void FixedUpdate()
        {
            Move();
        }
        
        public Enemy.Enemy FindClosestEnemy() //takım aglıyo artık mousea dogru atcak
        {
            float distanceToClosestEnemy = Mathf.Infinity;
            Enemy.Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy.Enemy>();
            
            Debug.Log(allEnemies);
            
            foreach (Enemy.Enemy currentEnemy in allEnemies)
            {
                float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
                if (distanceToEnemy < distanceToClosestEnemy)
                {
                    distanceToClosestEnemy = distanceToEnemy;
                    ClosestEnemy = currentEnemy;
                }
            }

            return ClosestEnemy;
        }
        
        public void TakeDamage(float damage)
        {
            health = health - damage;
        }
        
        private void Move()
        {
            _rb.MovePosition(_rb.position + _movement.normalized * (speed * Time.fixedDeltaTime));
        }
        
        private IEnumerator EnemyAttack()
        {
            while (true)
            {
                TakeDamage(10);
                yield return new WaitForSeconds(cooldown);
            }
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Enemy"))
            {
                StartCoroutine(EnemyAttack());
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            StopCoroutine(EnemyAttack());
        }
    }
}