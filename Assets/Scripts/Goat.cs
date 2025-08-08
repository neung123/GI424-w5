using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class Goat : MonoBehaviour
{
    [SerializeField]
    private float _eatDuration = 1f;

    private List<Grass> _allGrass;

    private void Start()
    {
        _allGrass = GameManager.Instance.GetAllGrass();
        StartCoroutine(EatingRoutine());
    }

    private IEnumerator EatingRoutine()
    {
        while (true)
        {
            var availableGrass = _allGrass.Where(grass => grass.IsAvailable).ToList();

            if (availableGrass.Count > 0)
            {
                Grass target = availableGrass[Random.Range(0, availableGrass.Count)];

                transform.position = target.transform.position;

                yield return new WaitForSeconds(_eatDuration);

                target.GetEaten();
            }

            yield return null;
        }
    }
}