using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : LivingEntity
{
    public Slider healthSlider;

    private PlayerMovement playerMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
        healthSlider.value = health;
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
}
