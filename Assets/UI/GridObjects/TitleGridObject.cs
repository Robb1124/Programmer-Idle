using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleGridObject : GridObject
{
    [SerializeField] private TextMeshProUGUI titleText;
    public override void LoadObjectData(GridObjectData gridObjectData)
    {
        TitleGridObjectData titleGridObjectData = (TitleGridObjectData)gridObjectData;
        titleText.text = $"-----{titleGridObjectData.Title}-----";
    }
}
