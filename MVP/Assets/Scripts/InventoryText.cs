using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryText : MonoBehaviour
{
    public string str;
    // Start is called before the first frame update
    public void SetText(string txt)
    {
      str += ("\n"+txt);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
