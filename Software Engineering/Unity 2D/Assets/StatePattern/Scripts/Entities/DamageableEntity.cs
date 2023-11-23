using UnityEngine;

namespace StatePattern.Entities
{
    public abstract class DamageableEntity : MonoBehaviour
    {
        [Header("Health and damage")]
        [SerializeField] private float _maxHealth = 100f;
        
        public float Health { get; private set; }
        
        
        public void TakeDamage(float damage)
        {
            Health -= damage;
            if (Health <= 0f)
            {
                Destroy(gameObject);
                Debug.Log($"{gameObject.name} died");
            }
            else
            {
                Debug.Log($"{gameObject.name} took {damage} damage. Health: {Health}");
            }
        }
        
        
        protected virtual void Awake()
        {
            Health = _maxHealth;
        }
    }
}