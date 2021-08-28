using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class variableToTMP : MonoBehaviour
{
    TextMeshProUGUI text;
    [SerializeField]
    ScriptableObjectArchitecture.IntVariable CycleCount;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSetTrigger()
    {
        text.text = CycleCount.Value.ToString();
    }
}
