using UnityEngine;

public class Trophy : MonoBehaviour
{
    private StarDisplay starDisplay;

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    public void AddStars(int amount)
    {
        starDisplay.AddStar(amount);
    }
}
