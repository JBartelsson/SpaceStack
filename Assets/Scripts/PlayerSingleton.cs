using Invector.vCharacterController;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSingleton : MonoBehaviour
{

    //public CamerShake camerShake;

    public enum Ability {None, Dash, Shoot, Grante, Minimize};

    private Stack<Ability> abilityStack = new Stack<Ability>();
    public event Action<Ability> OnAbilityStack;
    public event Action OnDeath;

    [Header("Dashing")]
    bool isDashing = false;
    [SerializeField] private ParticleSystem dashParticles;
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
    [SerializeField] public vThirdPersonCamera vCamera;
    [SerializeField] private float miniScale;
    [SerializeField] private float miniCameraHeight;
    [SerializeField] private float miniCameraDistance;
    public bool isMini = false;
    [Header("Sounds")]
    [SerializeField] AudioSource dashSound;
    [SerializeField] AudioSource minimize;
    [SerializeField] AudioSource maximize;
    [SerializeField] AudioSource acidDeath;
    [SerializeField] AudioSource foodstep;

    const string MOUSESENSITIVITY = "MouseSensitivity";


    private float oldCameraHeight;
    private float oldCameraDistance;
    
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

    public Ability peekAbilityStack()
    {
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
        Time.timeScale = 1;

        if (PlayerPrefs.HasKey(MOUSESENSITIVITY))
        {
            vCamera.xMouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");
            vCamera.yMouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");
        }
        else
        {
            PlayerPrefs.SetFloat(MOUSESENSITIVITY, 3f);
            PlayerPrefs.Save();
        }
        
        oldCameraHeight = vCamera.height;
        oldCameraDistance = vCamera.defaultDistance;
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
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (!foodstep.isPlaying)
            {
                foodstep.Play();
            }
        }
        else
        {
            if (foodstep.isPlaying)
            {
                foodstep.Stop();
            }
        }
    }

    private void Dash()
    {
        dashSound.Play();
        controller.Dash();
        Instantiate(dashParticles, transform);
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
            vCamera.height = miniCameraHeight;
            vCamera.defaultDistance = miniCameraDistance;
            minimize.Play();
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            isMini = false;
            vCamera.height = oldCameraHeight;
            vCamera.defaultDistance = oldCameraDistance;
            maximize.Play();
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
        OnDeath?.Invoke();
        StartCoroutine(DeathSoundTest());

    }

    void disableGravity()
    {
        GetComponent<Rigidbody>().useGravity = false;

    }

    void Reload()
    {
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Init()
    {
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;
        health = MaxHealth;
    }

    public void CameraShake(float duration, float magitude)
    {
        //StartCoroutine(camerShake.Shake(duration, magitude));
    }

    IEnumerator DeathSoundTest()
    {
        acidDeath.Play();
        yield return new WaitForSeconds(2f);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Invoke(nameof(Reload), 0f);
    }
}
