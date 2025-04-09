using UnityEngine;

public class gener : MonoBehaviour
{
    public GameObject kruh;
    public GameObject obdelnik;
    public GameObject heal;
    public float HealCooldown;
    public float poceOb;
    void Start()
    {

        poceOb = Random.Range(3, 7);
       
            for (int i = 0; i < poceOb; i++)
            {
                if (Random.Range(1, 3) < 2)
                {
                    GameObject novyKruh = Instantiate(kruh, new Vector3(Random.Range(-21, 21), Random.Range(-11, 11), 0), transform.rotation);
                    float velikost = Random.Range(1f, 8f);
                    novyKruh.transform.localScale = new Vector3(velikost, velikost, 1f);
                }
                else
                {
                    GameObject novyObd = Instantiate(obdelnik, new Vector3(Random.Range(-21, 21), Random.Range(-11, 11), 0), transform.rotation);
                    float velikostx = Random.Range(1f, 8f);
                    float velikosty = Random.Range(1f, 8f);
                    novyObd.transform.localScale = new Vector3(velikostx, velikosty, 1f);
                }   
                
            }
    }
    private void Update()
    {
        HealCooldown += Random.Range(1, 3) * Time.deltaTime;
        if(HealCooldown>20)
        { 
            Instantiate(heal, new Vector3(Random.Range(-15, 15), Random.Range(-8, 8), 0), transform.rotation);
            HealCooldown = 0;
        }
    }
}
