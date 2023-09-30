using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    public enum Ability {Dash, Shoot, Grante, Minimize};
    private Stack<Ability> abilityStack = new Stack<Ability>();

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
    }

    // Add other class methods here...

    public void SomeMethod()
    {
        Debug.Log("It works.");
    }
}
