using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static PlayerSingleton;

public class UiAbility : MonoBehaviour
{

    [SerializeField]
    public Sprite DashImage = null;
    public Sprite LaserImage = null;
    public Sprite MinimizeImage = null;
    public Sprite GranadeImage = null;

    Stack<GameObject> imageStack = new Stack<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        PlayerSingleton.Instance.OnAbilityStack += OnAbilityStackl;
    }

    private void OnAbilityStackl(PlayerSingleton.Ability obj)
    {
        Debug.Log("Woo Event: " + obj.ToString());
        if (obj == Ability.None)
        {
            //Pop
            GameObject objectToDelete = imageStack.Pop();
            Destroy(objectToDelete);
        }
        else
        {
            Sprite addSprite = null;
            //push
            switch (obj)
            {
                case Ability.Dash:
                    addSprite = DashImage;
                    break;
                case Ability.Shoot:
                    addSprite = LaserImage;
                    break;
                case Ability.Minimize:
                    addSprite = MinimizeImage;
                    break;
                case Ability.Grante:
                    addSprite = GranadeImage;
                    break;
                default:
                    addSprite = GranadeImage;
                    break;
            }
            GameObject new_obj = new GameObject();
            imageStack.Push(new_obj);
            new_obj.transform.parent = transform;
            new_obj.AddComponent<CanvasRenderer>();
            RectTransform new_rectTransform = new_obj.AddComponent<RectTransform>();
            UnityEngine.UI.Image mImage = new_obj.AddComponent<UnityEngine.UI.Image>();
            mImage.sprite = addSprite;
            new_rectTransform.anchoredPosition = new Vector2(-500, -275 + imageStack.Count * 75);
            new_rectTransform.sizeDelta = new Vector2(60, 60);


        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
