using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    
    [SerializeField] private int playerGold = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddGold(int goldAmount)
    {
        playerGold += goldAmount;
        goldText.text = playerGold.ToString() + " <sprite index=0>";
    }
}
