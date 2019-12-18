using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField]private float OpeningSize;
    private float Delta;
    // Start is called before the first frame update
    void Start()
    {
        Delta = OpeningSize / 2;
    }

    public void Open()
    {
        transform.Find("TopGate").Translate(0, Delta, 0); 
        transform.Find("BotGate").Translate(0, -Delta, 0);
    }

    public void Close()
    {
        transform.Find("TopGate").Translate(0, -Delta, 0);
        transform.Find("BotGate").Translate(0, +Delta, 0);
    }
}
