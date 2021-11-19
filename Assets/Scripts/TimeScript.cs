using UnityEngine;

public class TimeScript : MonoBehaviour
{
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
        Invoke(nameof(AddToSecond), time: 1);
    }
}
