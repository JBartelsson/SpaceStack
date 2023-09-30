using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    public enum Ability {Dash, Shoot, Grante, Minimize};
    private Stack<Ability> abilityStack = new Stack<Ability>();

    bool isDashing = false;
    [SerializeField] vThirdPersonController controller;
    [SerializeField] private KeyCode dash;
    private Rigidbody rb;

    public Stack<Ability> getAbilityStack(){
        return abilityStack;
    }
    public void setAbilityStack(Stack<Ability> value){
       abilityStack = value;
    }

    public void pushAbilityStack(Ability value){
        abilityStack.Push(value);
    }

    public Ability popAbilityStack()
    {
        return abilityStack.Pop();
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
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(dash))
        {
            controller.Dash();
            Debug.Log("pressed");
            //Vector3 forwardMotion = new Vector3(0, .1f, -100);
            //rb.AddForce(forwardMotion, ForceMode.Impulse);
        }
    }

    // Add other class methods here...

    public void SomeMethod()
    {
        Debug.Log("It works.");
    }
}
