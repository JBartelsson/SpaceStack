using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class AbilityStackEvent : UnityEvent<int>
{
}
public class PlayerSingleton : MonoBehaviour
{
    public enum Ability {None, Dash, Shoot, Grante, Minimize};

    private Stack<Ability> abilityStack = new Stack<Ability>();

    public Stack<Ability> getAbilityStack(){
        return abilityStack;
    }
    public void setAbilityStack(Stack<Ability> value){
       abilityStack = value;
    }

    public void pushAbilityStack(Ability value){
        abilityStack.Push(value);
        //AbilityStackEvent.Invoke(value);
    }

    public Ability popAbilityStack()
    {

         if (abilityStack.Count > 0)
        {
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

    // Add other class methods here...

    public void SomeMethod()
    {
        Debug.Log("It works.");
    }


//Nur für Test Zwecke Kann gelöscht werden!
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pushAbilityStack(Ability.Dash);
            Debug.Log("Pushidi Push");
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Ability tmp = popAbilityStack();
            Debug.Log("Popidi Pop: " + tmp.ToString());
        }
    }

}
