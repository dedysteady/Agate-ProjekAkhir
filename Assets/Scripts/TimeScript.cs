using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    [SerializeField] private Text timeText;
    public int seconds, minutes;
    // Start is called before the first frame update
    void Start()
    {
        AddToSecond();
    }

    private void AddToSecond()
    {
        seconds++;
        if (seconds > 59)
        {
            minutes++;
            seconds = 0;
        }
        timeText.text = (minutes < 10?"0":"") + minutes + ":" + (seconds < 10?"0":"") + seconds;
        Invoke(nameof(AddToSecond), time: 1);
    }

    public void StopTimer()
    {
        CancelInvoke(nameof(AddToSecond));
        timeText.gameObject.SetActive(false);
    }
}
