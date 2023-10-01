using Invector.vCharacterController;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSingleton : MonoBehaviour
{
    public enum Ability {None, Dash, Shoot, Grante, Minimize};

    private Stack<Ability> abilityStack = new Stack<Ability>();
    public event Action<Ability> OnAbilityStack;

    bool isDashing = false;
    [Header("Character")]
    [SerializeField] vThirdPersonController controller;
    [SerializeField] private KeyCode dash;
    [Header("Spawning")]
    [SerializeField] private float MaxHealth = 100f;
    [SerializeField] private Transform spawnPoint;
    [Header("Shooting")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnpoint;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileDamage;
    [Header("Bombing")]
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private LayerMask groundLayer;
    [Header("Minimize/Maximize")]
    [SerializeField] private float miniScale;
    public bool isMini = false;



    //Player Stats

    private float health;

    public Stack<Ability> getAbilityStack(){
        return abilityStack;
    }
    public void setAbilityStack(Stack<Ability> value){
       abilityStack = value;
    }

    public void pushAbilityStack(Ability value){
        abilityStack.Push(value);
        OnAbilityStack?.Invoke(value);
    }

    public Ability popAbilityStack()
    {

         if (abilityStack.Count > 0)
        {
            OnAbilityStack?.Invoke(Ability.None);
            return abilityStack.Pop();
            
        }
        return Ability.None;

    }

    public Ability peekAbilityStack(){
        return abilityStack.Peek();
    }

    private static PlayerSingleton _instance; 

    public static PlayerSingleton Instance
    {
        get {
            if (_instance == null) {
                Debug.LogError("PlayerSingleton not instantiated.");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        Init();
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ability currentAbility = popAbilityStack();
            switch (currentAbility)
            {
                case Ability.None:
                    break;
                case Ability.Dash:
                    Dash();
                    break;
                case Ability.Shoot:
                    Shoot();
                    break;
                case Ability.Grante:
                    Bomb();
                    break;
                case Ability.Minimize:
                    Minimize();
                    break;
                default:
                    break;
            }
            Debug.Log("pressed");
            //Vector3 forwardMotion = new Vector3(0, .1f, -100);
            //rb.AddForce(forwardMotion, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            pushAbilityStack(Ability.Grante);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            pushAbilityStack(Ability.Dash);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Ability tmp = popAbilityStack();
            Debug.Log("Popidi Pop: " + tmp.ToString());
        }
    }

    private void Dash()
    {
        controller.Dash();

    }
    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnpoint.transform.position, projectileSpawnpoint.transform.rotation);
        PlayerProjectile playerProjectile = projectile.GetComponent<PlayerProjectile>();
        playerProjectile.SetDamage(projectileDamage);
        playerProjectile.SetSpeed(projectileSpeed);

    }

    private void Minimize()
    {
        if (!isMini)
        {
            transform.localScale = new Vector3(miniScale, miniScale, miniScale);
            isMini = true;

        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            isMini = false;
        }
    }
    private void Bomb()
    {
        float rayCastDistance = 3f;
        Debug.Log("Bomb");

        if (Physics.Raycast(transform.position + Vector3.up * .1f, Vector3.down, out RaycastHit hit, rayCastDistance, groundLayer))
        {
            Debug.Log("Found ground");
            GameObject bomb = Instantiate(bombPrefab, hit.point, Quaternion.identity);
        }
    }

    public void DamagePlayer(float damage)
    {
        health -= damage;
        if (health < 1)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;
    }

    private void Init()
    {
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;
        health = MaxHealth;
    }

}
