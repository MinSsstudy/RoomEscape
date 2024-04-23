using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIItemDescription : MonoBehaviour
{
    // �������� ����(�ؽ�Ʈ)�� ������

    [SerializeField] TextMeshProUGUI txtDescription;


    public void ShowDescription(string description)
    {
        txtDescription.text = description;
    }
}
