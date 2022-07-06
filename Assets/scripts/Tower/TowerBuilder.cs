 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private Platform[] _platform;
    [SerializeField] private FinishPlatform _finishPlatform;
    
    private void Awake()
    {
        Build();   
    }

    private float _startFinishAdditionaryScale = 0.5f;
    private float BeamScaleY => _levelCount / 2f + _startFinishAdditionaryScale + _additionalScale/2f;

    

    private void Build()
    {
        GameObject towerBeam = Instantiate(_beam, transform);
        towerBeam.transform.localScale = new Vector3(1f, BeamScaleY, 1f);
        Vector3 spawnPosition = towerBeam.transform.position;   
        spawnPosition.y += towerBeam.transform.localScale.y - _additionalScale;


        Spawnplatform(_spawnPlatform, ref spawnPosition, towerBeam.transform);
        for (int i = 0; i < _levelCount; i++)
        {
            Spawnplatform(_platform[Random.Range(0, _platform.Length)], ref spawnPosition, towerBeam.transform);
        }
        Spawnplatform(_finishPlatform, ref spawnPosition, towerBeam.transform);
    }

    private void Spawnplatform(Platform platform, ref Vector3 spawnPosiotion, Transform parent )
    {
        Instantiate(platform, spawnPosiotion, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosiotion.y -= 1;
    }
}

