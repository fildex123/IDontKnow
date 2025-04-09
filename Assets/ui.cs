using UnityEngine;
using UnityEngine.UI;

public class ui : MonoBehaviour
{
    public GameObject vipni1;
    public GameObject vipni2;
    public GameObject vipni3;
    public GameObject vipni4;
    public Transform mec;
    public Slider healthSlider;
    public float maxHealth = 100f;
    public float currentHealth=100f;
    public float damage = 1f;
    public string targetTag = "myWeapon";
    public string HealTag = "heal";

    void Start()
    {
        UpdateHealthBar();
        transform.position = new Vector3(Random.Range(-19, 19), Random.Range(-9, 9), 0);
        mec.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        vipni1.SetActive(false);
        vipni2.SetActive(false);
        vipni3.SetActive(true);
    }
    void Update()
    {
        if(currentHealth<=0)
        {
            vipni1.SetActive(true);
            vipni2.SetActive(true);
            vipni3.SetActive(false);

        }

        UpdateHealthBar();
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void UpdateHealthBar()
    {
        healthSlider.value = currentHealth;
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            TakeDamage(collision.relativeVelocity.magnitude/5);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(HealTag))
        {
            Heal(15*maxHealth/100);
        }
    }
}
