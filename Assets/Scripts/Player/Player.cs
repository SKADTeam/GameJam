using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        Vector2 _movement;
        Rigidbody2D _rb;
        [SerializeField] float speed = 5f;
        public bool isMoving;

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
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _rb.MovePosition(_rb.position + _movement.normalized * (speed * Time.fixedDeltaTime));
        }
    }
}