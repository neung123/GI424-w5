using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private Grass _grassPrefab;

    [SerializeField]
    private Goat _goatPrefab;

    [SerializeField]
    private int _grassRows = 3;

    [SerializeField]
    private int _grassCols = 5;

    [SerializeField]
    private float _grassSpacing = 2f;

    private List<Grass> _allGrass;

    private void Awake()
    {
        Instance = this;

        _allGrass = new List<Grass>();
    }

    private void Start()
    {
        for (int row = 0; row < _grassRows; row++)
        {
            for (int col = 0; col < _grassCols; col++)
            {
                Vector3 pos = new Vector3(col * _grassSpacing, 0, row * _grassSpacing);

                var grass = Instantiate(_grassPrefab, pos, Quaternion.identity);
                _allGrass.Add(grass);
            }
        }

        Instantiate(_goatPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public List<Grass> GetAllGrass()
    {
        return _allGrass;
    }
}