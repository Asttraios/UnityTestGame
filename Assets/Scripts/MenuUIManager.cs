using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private int unlockedLevelNumber;
    [SerializeField] private GameObject[] levels;

    private void Start()
    {
        
        for(int i=0; i<levels.Length; i++)

        {
            if (i >= PlayerPrefs.GetInt("map", 1))
            {
                levels[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
                levels[i].GetComponent<UnityEngine.UI.Button>().interactable = false;
                
            }
        }
        
      
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void LevelUnlock()
    {

    }


}
