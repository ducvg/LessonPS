using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 100;
    public float fuelValue = 20;
    public float damageValue = 50;
    public GameObject explusionPrefabs;
    //prvate 
    public float currentHealth = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fuel")
        {
            Destroy(other.gameObject);
            GameManager.Instance.SetFuel(fuelValue);
            InstantiateGame(other);
        }
        else if (other.tag == "Damage")
        {
            DamageHealth(damageValue);
            InstantiateGame(other);
            Destroy(other);
        }
        else if(other.tag == "FinishLine")
        {
            GameManager.Instance.AddRound();
        }
    }
    void InstantiateGame(Collider other)
    {
        Instantiate(explusionPrefabs, other.transform.position, Quaternion.identity);
    }
    private void DamageHealth(float health)
    {
        if (currentHealth > 0)
        {
            currentHealth -= health;
        }
        else
        {
            currentHealth = 0;
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -60f, 60f), 0, Mathf.Clamp(transform.position.z, -60f, 60f));
    }
}
