using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIItemDescription : MonoBehaviour
{
    // 아이템의 설명(텍스트)를 보여줌

    [SerializeField] TextMeshProUGUI txtDescription;


    public void ShowDescription(string description)
    {
        txtDescription.text = description;
    }
}
