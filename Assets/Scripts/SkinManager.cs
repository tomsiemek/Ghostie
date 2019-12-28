using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SKIN { BASIC, ALIEN, ANGRY };
public class SkinManager : MonoBehaviour
{
    private static SKIN skin = SKIN.BASIC;
    [SerializeField] private Sprite BasicSprite;
    [SerializeField] private Sprite AlienSprite;
    [SerializeField] private Sprite AngrySprite;
    // Start is called before the first frame update
    void Start()
    {
        Sprite sprite = BasicSprite;
        if(skin == SKIN.ALIEN)
        {
            sprite = AlienSprite;
        }
        else if(skin == SKIN.ANGRY)
        {
            sprite = AngrySprite;
        }

        GameObject ghostie = GameObject.Find("Ghostie");
        if(ghostie)
        {
            ghostie.GetComponent<Image>().sprite = sprite;

        }
        else
        {
            GameObject.Find("PlayerSprite").GetComponent<SpriteRenderer>().sprite = sprite;
        }

    }

    public void SwitchToAlien()
    {
        skin = SKIN.ALIEN;
        GameObject.Find("Ghostie").GetComponent<Image>().sprite = AlienSprite;
    }

    public void SwitchToBasic()
    {
        skin = SKIN.BASIC;
        GameObject.Find("Ghostie").GetComponent<Image>().sprite = BasicSprite;
    }

    public void SwitchToAngry()
    {
        skin = SKIN.ANGRY;
        GameObject.Find("Ghostie").GetComponent<Image>().sprite = AngrySprite;
    }


}
