using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsText : MonoBehaviour
{
    [SerializeField] private float Speed;
    RectTransform rectT;
    int height;
    [SerializeField] private bool SetY = false;
    [SerializeField]private float finalY;
    void Start()
    {
        rectT = GetComponent<RectTransform>();
        height = Screen.currentResolution.height;
        if(!SetY)
        {
            finalY = height + rectT.rect.height;
        } 
        Debug.Log(finalY);
    }
    void FixedUpdate()
    {
        if(Input.GetButton("Fire1") || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            End();
        }
        if(PosY() > finalY)
        {
            End();
        }
    }
    float PosY()
    {
        return rectT.position.y - height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
        Debug.Log(PosY());
    }

    void End()
    {
        SceneManager.LoadScene(0);
    }

}
