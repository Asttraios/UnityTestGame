using TMPro;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    // [SerializeField] private GameObject player;
    [SerializeField] private float slowMoLimitValue;
    [SerializeField] private TextMeshProUGUI slowMoLimitText;



    private void Start()
    {
        slowMoLimitText.text = "Slow-Mo: " + slowMoLimitValue.ToString("F2");
    }

    private void Update()
    {  
        SlowMo();
    }  


    public void SlowMo()
    {
                  
            if (Input.GetKey(KeyCode.Space) && slowMoLimitValue>0f)
            {
                slowMoLimitValue = Mathf.Clamp(slowMoLimitValue, 0f, int.MaxValue);
                slowMoLimitText.color = new Color(1f, 0f, 0f);
                Time.timeScale = 0.5f;
                slowMoLimitValue -= Time.unscaledDeltaTime;
                slowMoLimitText.text = "Slow-Mo: " + slowMoLimitValue.ToString("F2");
               
                //Debug.Log("asdad");
                
            }
            else
            {
                slowMoLimitText.color = new Color(1f, 1f, 1f);
                Time.timeScale = 1f;
            }
    }


}
