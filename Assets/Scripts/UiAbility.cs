using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using static PlayerSingleton;


public class UiAbility : MonoBehaviour
{

    [SerializeField] public Sprite dashImage;
    [SerializeField] public Sprite laserImage;
    [SerializeField] public Sprite minimizeImage;
    [SerializeField] public Sprite grenadeImage;
    [SerializeField] public Sprite circle;



    [SerializeField] public Color circleColor = new Color(1, 1, 1);
    [SerializeField] public Color defaultCircleColor = new Color(1, 1, 1);
    [SerializeField] Vector3 imageScale = new Vector3(.8f, .8f, .8f);

    Stack<GameObject> imageStack = new Stack<GameObject>();
    Stack<GameObject> circleimageStack = new Stack<GameObject>();

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
            
            // Pop
            Destroy(imageStack.Pop());
            Destroy(circleimageStack.Pop());
            

            if (imageStack.Count > 0)
            {
                circleimageStack.Peek().SetActive(true);
                circleimageStack.Peek().GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                imageStack.Peek().GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);

            }
        }
        else
        {
            Sprite addSprite;

            // Push
            switch (obj)
            {
                case Ability.Dash:
                    addSprite = dashImage;
                    break;
                case Ability.Shoot:
                    addSprite = laserImage;
                    break;
                case Ability.Minimize:
                    addSprite = minimizeImage;
                    break;
                case Ability.Grante:
                    addSprite = grenadeImage;
                    break;
                default:
                    addSprite = grenadeImage;
                    break;
            }

            //Set First elemtens Color to default color
            if (imageStack.Count > 0)
            {
                circleimageStack.Peek().SetActive(false);
                circleimageStack.Peek().GetComponent<RectTransform>().localScale = imageScale;
                imageStack.Peek().GetComponent<RectTransform>().localScale = imageScale;


            }

            // Symbol
            GameObject new_obj = new GameObject();
            new_obj.transform.parent = transform;
            new_obj.AddComponent<CanvasRenderer>();
            RectTransform new_rectTransform = new_obj.AddComponent<RectTransform>();
            UnityEngine.UI.Image mImage = new_obj.AddComponent<UnityEngine.UI.Image>();
            mImage.sprite = addSprite;
            new_rectTransform.anchorMax = new Vector2(0, 0);
            new_rectTransform.anchorMin = new Vector2(0, 0);
            new_rectTransform.sizeDelta = new Vector2(40, 40);
            new_rectTransform.anchoredPosition = new Vector2(50, 40 + ( imageStack.Count) * 75);

            // Circle
            GameObject circleObject = new GameObject();
            circleObject.transform.parent = transform;
            circleObject.AddComponent<CanvasRenderer>();
            RectTransform newRectTransform = circleObject.AddComponent<RectTransform>();
            UnityEngine.UI.Image symbolImage = circleObject.AddComponent<UnityEngine.UI.Image>();
            symbolImage.sprite = circle;
            symbolImage.color = circleColor;
            newRectTransform.anchorMax = new Vector2(0, 0);
            newRectTransform.anchorMin = new Vector2(0, 0);
            newRectTransform.sizeDelta = new Vector2(60, 60);
            newRectTransform.anchoredPosition = new Vector2(50, 40 + (circleimageStack.Count) * 75);


            imageStack.Push(new_obj);
            circleimageStack.Push(circleObject);
           
        }
    }
}
