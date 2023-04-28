using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Spells
{
    public class Spells : MonoBehaviour
    {
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
                    
                    
                    break;
                }
                case "Iceball":
                {
                    
                    break;
                }
                case "Poisonball":
                {
                 
                    break;
                }
            }
            
            Debug.Log("Fireball used.");
        }
    }
}