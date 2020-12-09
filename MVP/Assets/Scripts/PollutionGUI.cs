using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutionGUI : MonoBehaviour
{
    public Button yourButton;
    public bool showPollutionGUI;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        showPollutionGUI = false;
    }
    void TaskOnClick()
    {
        Debug.Log("You have clicked the pollution button!");
        //set our bool to true
        showPollutionGUI = !showPollutionGUI;
    }
    private void OnGUI()
    {
      if(showPollutionGUI)
      {
        print("You have picked up clean water");
      }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
