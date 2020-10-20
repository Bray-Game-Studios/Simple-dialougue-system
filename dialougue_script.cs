using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dialougue_script : MonoBehaviour
{
    public string dialougue;
    
    public string[] response_options_str;
    public string name;
    public Text nameTxt;
    public Text dialougueTxt;
    public Text optionTxt;
    public int order = 1;
    public bool isactive = false;
    public dialougue_script[] response_options_obj;
    public int current_dialougue_option_index = 0;
    public void dialouguefn() {
        isactive = true;
        Debug.Log("isactive:" + isactive);
        nameTxt.text = name;
        dialougueTxt.text = dialougue;
        optionTxt.text = response_options_str[0];
    }
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isactive == true) {
            
            if (Input.GetKeyDown(KeyCode.DownArrow)) 
            {
                if (current_dialougue_option_index < response_options_str.Length - 1) {
                    current_dialougue_option_index++;
                    optionTxt.text = response_options_str[current_dialougue_option_index];

                }
                Debug.Log(current_dialougue_option_index);
            } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
                if (current_dialougue_option_index > 0) {
                    current_dialougue_option_index--;
                    optionTxt.text = response_options_str[current_dialougue_option_index];
                }
                Debug.Log(current_dialougue_option_index);
            } else if (Input.GetKeyDown(KeyCode.Return)) {
                
                isactive = false;
                
                 StartCoroutine(next_option());
            } else if (Input.GetKeyDown(KeyCode.Escape)) {
                    isactive = false;
            }
        
        }
    }
    IEnumerator next_option() {
        yield return new WaitForSeconds(0.100f);
        response_options_obj[current_dialougue_option_index].dialouguefn();
    }
    public void OnMouseOver() {
        if (Input.GetMouseButtonDown(0) && order == 1) {
            
            Debug.Log("click");
            dialouguefn();
        }
        
    }
}
