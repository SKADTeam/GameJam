using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        public float health = 100f;
        public float movSpeed = 5f;
        
        private Transform target;
        public GameObject player;
        
        public void TakeDamage (float damage)
        { 
            health -= damage;
        
            if (health <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            Destroy(gameObject);
        }
        
        void Start()
        {
            player = GameObject.Find("Player");
            target = player.transform;
        }
        
        void Update()
        {
            Move();
        }

        public void Move()
        {
            if (target != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, movSpeed * Time.deltaTime);
            }
        }
    }
}
