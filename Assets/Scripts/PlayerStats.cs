using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.PackageManager;
using Unity.VisualScripting;
using TMPro;

// code from https://youtu.be/sPiVz1k-fEs

public class PlayerStats : MonoBehaviour
{
    public TextMeshProUGUI scrapUI;

    public static PlayerStats instance;
    public int maxHealth = 100;
    public int currentHealth;

    public int maxArmor = 3;
    public int currentArmor;

    public int currentKeys;

    public int currentTeleportScrap;

    public int totalKey;
    public int totalHealthUpgrade;
    public int totalArmor;

    public int regenAmount;
    public float regenAfterSecond;
    public float delayRegen;

    //Player sound effect
    public AudioSource playerHurt;
    public float volume = 0.5f;

    public UIStats healthBar;
    public List<GameObject> Armor;
    public List<GameObject> Keys;

    bool isRegenHealth;
    bool takeDMG;
    Rigidbody rb;

    private float time;
    private float elapsedTime;

    // Called when the game starts
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // set items
        currentHealth = 100;
        currentArmor = 0;
        currentKeys = 0;
        totalKey = 0;
        totalHealthUpgrade = 0;
        totalArmor = 0;
        //set player instance
        instance = this;
    }

    void Start()
    {
        //healthText.text = currentHealth.ToString() + " HP";
        healthBar.SetMaxHealth(maxHealth);
        Armor[0].SetActive(false);
        Armor[1].SetActive(false);
        Armor[2].SetActive(false);

        Keys[0].SetActive(false);
        Keys[1].SetActive(false);
        Keys[2].SetActive(false);

        time = regenAfterSecond;

        takeDMG= false;
    }

    void Update()
    {
        if (currentHealth != maxHealth && !isRegenHealth)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= time)
            {
                elapsedTime = 0f;
                Debug.Log("Player regen");
                StartCoroutine(RegainHealthOverTime());
            }
        }
    }

    private IEnumerator RegainHealthOverTime()
    {
        takeDMG = false;
        isRegenHealth = true;
        while (currentHealth < maxHealth)
        {
            Healthregen();
            yield return new WaitForSeconds(delayRegen);

            if(takeDMG)
            {
                takeDMG = false;
                break;
            }
        }
        isRegenHealth = false;
    }


    public void Healthregen()
    {
        currentHealth += regenAmount;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Regen Health: " + currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (currentArmor == 3){
            currentArmor -= 1;
            Debug.Log("Player Armor: " + currentArmor);
            Debug.Log("Player Health: " + currentHealth);
        }
        else if(currentArmor == 2){
            currentArmor -= 1;
            Debug.Log("Player Armor: " + currentArmor);
            Debug.Log("Player Health: " + currentHealth);
        }
        else if(currentArmor == 1){
            currentArmor -= 1;
            Debug.Log("Player Armor: " + currentArmor);
            Debug.Log("Player Health: " + currentHealth);
        }                 
        else if(currentArmor == 0)
        {
            currentHealth -= damage;
            // play PlayerHurt sound
            playerHurt.PlayOneShot(playerHurt.clip, volume);
            Debug.Log("Player Armor: " + currentArmor);
            Debug.Log("Player Health: " + currentHealth);
        }

        if (isRegenHealth)
        {
            StopCoroutine("RegainHealthOverTime");
            Debug.Log("Player hit, stop regen");
        }

        takeDMG = true;
        healthBar.SetHealth(currentHealth);
        RemoveArmor(currentArmor);

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    public void AddHealth()
    {
        totalHealthUpgrade += 1;
        currentHealth += 10;
        Debug.Log("Player Health: " + currentHealth);
        healthBar.SetHealth(currentHealth);
        //healthText.text = currentHealth.ToString() + " HP";
        healthBar.SetHealth(currentHealth);
    }

    public void AddArmor()
    {
        totalArmor += 1;
        if(currentArmor < 3)
        {
            currentArmor += 1;
            Debug.Log("Player Armor: " + currentArmor);
            AddArmor(currentArmor);
        }
        else 
        {
            Debug.Log("Max Armor: 3");
        }
    }

    public void AddKey()
    {
        currentKeys += 1;
        totalKey += 1;
        Debug.Log("Player Keys: " + currentKeys);
        AddKey(currentKeys);
    }

    public void AddTeleportScrap()
    {
        currentTeleportScrap += 1;
        scrapUI.text = currentTeleportScrap + "/3 Scraps";
        Debug.Log("Teleport Scrap: " + currentTeleportScrap);
    }

    public void Knockback(Vector3 dir)
    {
        rb.AddRelativeForce(dir * 20f, ForceMode.Impulse);
    }

    private void Die()
    {
        StartCoroutine(SceneLoader.instance.LoadLevel("GameOver"));
    }

    public void AddArmor(int armor)
    {
        int fixArmor = armor - 1;
        Armor[fixArmor].SetActive(true);
    }

    public void RemoveArmor(int armor)
    {
        Armor[armor].SetActive(false);
    }

    public void AddKey(int key)
    {
        int fixKey = key - 1;
        Keys[fixKey].SetActive(true);
    }

    public void RemoveKey(int key)
    {
        Keys[key].SetActive(false);
    }
}
