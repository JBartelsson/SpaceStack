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
    [SerializeField] public GameObject arrow;

    private RectTransform arrowTransform;
    
    Stack<GameObject> imageStack = new Stack<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        PlayerSingleton.Instance.OnAbilityStack += OnAbilityStackl;

        arrowTransform = arrow.GetComponent<RectTransform>();
    }

    private void OnAbilityStackl(PlayerSingleton.Ability obj)
    {
        Debug.Log("Woo Event: " + obj.ToString());
        if (obj == Ability.None)
        {
            
            
            // Pop
            Destroy(imageStack.Pop());
            Destroy(imageStack.Pop());
            
            arrowTransform.anchoredPosition = new Vector2(100, -25 + (1 + imageStack.Count / 2) * 75);

            if (imageStack.Count > 0)
            {
                arrow.SetActive(true);
            }
            else
            {
                arrow.SetActive(false);
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
            new_rectTransform.anchoredPosition = new Vector2(50, -25 + (1 + imageStack.Count / 2) * 75);

            // Circle
            GameObject circleObject = new GameObject();
            circleObject.transform.parent = transform;
            circleObject.AddComponent<CanvasRenderer>();
            RectTransform newRectTransform = circleObject.AddComponent<RectTransform>();
            UnityEngine.UI.Image symbolImage = circleObject.AddComponent<UnityEngine.UI.Image>();
            symbolImage.sprite = circle;
            newRectTransform.anchorMax = new Vector2(0, 0);
            newRectTransform.anchorMin = new Vector2(0, 0);
            newRectTransform.sizeDelta = new Vector2(60, 60);
            newRectTransform.anchoredPosition = new Vector2(50, -25 + (1 + imageStack.Count / 2) * 75);

            arrowTransform.anchoredPosition = new Vector2(100, -25 + (1 + imageStack.Count / 2) * 75);

            imageStack.Push(new_obj);
            imageStack.Push(circleObject);
            
            if (imageStack.Count > 0)
            {
                arrow.SetActive(true);
            }
            else
            {
                arrow.SetActive(false);
            }
        }
    }
}
