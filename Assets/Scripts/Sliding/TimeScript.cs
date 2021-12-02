using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    [SerializeField] private Text timeText;
    public int seconds, minutes;
    public GameObject[] stars;
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

        if ( seconds >= 0 && seconds <= 15)
        {
            stars[0].SetActive(true);
        }
        else if ( seconds > 15 && seconds <= 30)
        {
            stars[0].SetActive(false);
            stars[1].SetActive(true);
        }
        else if ( seconds > 30)
        {
            stars[0].SetActive(false);
            stars[1].SetActive(false);
            stars[2].SetActive(true);
        }
    }

    public void StopTimer()
    {
        CancelInvoke(nameof(AddToSecond));
        timeText.gameObject.SetActive(false);
    }
}
