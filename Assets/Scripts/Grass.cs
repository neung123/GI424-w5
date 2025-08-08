using UnityEngine;

public class Grass : MonoBehaviour
{
    [SerializeField]
    private float _regrowDuration = 3f;

    public bool IsAvailable { get; private set; } = true;

    public void GetEaten()
    {
        if (!IsAvailable)
        {
            return;
        }

        IsAvailable = false;
        gameObject.SetActive(false);

        Invoke(nameof(Regrow), _regrowDuration);
    }

    private void Regrow()
    {
        IsAvailable = true;
        gameObject.SetActive(true);
    }
}
