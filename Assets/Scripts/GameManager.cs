using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGenerateGrass;

    [SerializeField]
    private List<Grass> _generateGrass;

    [SerializeField]
    private Transform _grassHolder;

    [SerializeField]
    private List<Grass> _grassPrefabs;

    [SerializeField]
    private Goat _goatPrefab;

    [SerializeField]
    private int _grassRows = 3;

    [SerializeField]
    private int _grassCols = 5;

    [SerializeField]
    private float _grassSpacing = 2f;

    public static GameManager Instance;

    private List<Grass> _allGrass;

    private void Awake()
    {
        Instance = this;

        _allGrass = new List<Grass>();
    }

    private void Start()
    {
        if (_isGenerateGrass)
        {
            foreach (var g in _generateGrass)
            {
                g.gameObject.SetActive(false);
            }

            for (int r = 0; r < _grassRows; r++)
            {
                for (int c = 0; c < _grassCols; c++)
                {
                    // pick a random grass prefab from the list
                    Grass prefab = _grassPrefabs[Random.Range(0, _grassPrefabs.Count)];

                    Vector3 pos = new Vector3(c * _grassSpacing, 0, r * _grassSpacing);
                    Grass grass = Instantiate(prefab, pos, Quaternion.identity);
                    grass.transform.parent = _grassHolder;
                    _allGrass.Add(grass);
                }
            }
        }
        else
        {
            _allGrass.AddRange(_generateGrass);
        }

        Instantiate(_goatPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public List<Grass> GetAllGrass()
    {
        return _allGrass;
    }
}