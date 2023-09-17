using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldObj : MonoBehaviour
{
    public GameObject _effectShiled;
    public GameObject _effectMissileDestroy;
    int _rate = 50;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Missile")) {
            int random = Random.Range(0, 100);

            if (random < _rate) {
                Instantiate(_effectMissileDestroy, transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other) {
        Instantiate(_effectShiled, other.transform.position, Quaternion.identity);
    }
}
