using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventorySlot : MonoBehaviour
{
    [SerializeField] Image imgItemIcon;
    [SerializeField] TextMeshProUGUI txtItemNum;


    public void ShowItem(Sprite icon, int num)
    {
        imgItemIcon.sprite = icon;
        txtItemNum.text = num.ToString();
    }
}
