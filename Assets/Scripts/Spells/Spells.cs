using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using Extensions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Object = System.Object;

namespace Spells
{
    public class Spells : MonoBehaviour
    {
        public float FireballSpeed = 8f;
        
        public GameObject FireballSpell;
        public Player.Player playerCharacter;
        
        private void OnEnable()
        {
            Signals.Signals.Instance.OnSkillUse += CastSpell;
        }
        
        public void CastSpell(string spell)
        {
            switch (spell)
            {
                case "Fireball":
                {
                    
                    GameObject Fireball = Instantiate(FireballSpell, playerCharacter.transform);
                    Rigidbody2D FireballRB = Fireball.GetComponent<Rigidbody2D>();
                    
                    
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 shootDirection = mousePosition - (Vector2)playerCharacter.transform.position;
                    shootDirection.Normalize();
                    FireballRB.velocity = shootDirection * FireballSpeed;
                    
                    
                    
                    break;
                }
                case "Iceball":
                {
                    
                    break;
                }
                case "Lightning":
                {
                                     
                    break;
                }
            }
        }

        void sanatimanlasilmiyor()
        {
            Vector2 cenemy = playerCharacter.FindClosestEnemy().transform.position - playerCharacter.transform.position;
            Debug.Log(cenemy);
            //FireballRB.AddForce(cenemy, ForceMode2D.Impulse);
        }
    }
}