using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsText : MonoBehaviour
{
    [SerializeField] private float Speed;
    RectTransform rectT;
    int height;
    float finalY;
    void Start()
    {
        rectT = GetComponent<RectTransform>();
        height = Screen.currentResolution.height;
        finalY = height / 2 + rectT.rect.height / 2;
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
    }

    void End()
    {
        SceneManager.LoadScene(0);
    }

}
