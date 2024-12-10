using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public TextMeshProUGUI winningText;

    // Start is called before the first frame update
    void Start()
    {
        winningText.text = GameManager.instance.winningMessage;
    }
}
