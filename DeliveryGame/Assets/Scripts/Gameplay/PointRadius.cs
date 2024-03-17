using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointRadius : MonoBehaviour
{
    [SerializeField]
    float _pointValue;

    [SerializeField]
    float _perfectRadius;
    float _actualScore;


    Package _package;
    Rigidbody2D _packageRB;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.GetComponent<Package>())
        {
            if (_package == null)
            {
                _package = other.GetComponent<Package>();
                _packageRB = _package.GetComponent<Rigidbody2D>();
            }
            Debug.Log(Vector2.Distance(transform.position, _package.transform.position) * 5);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Package>())
        {
            
            if ((Vector2.Distance(transform.position, _package.transform.position) * 5) <= _perfectRadius)
            {
                _actualScore = _pointValue;
                Debug.LogFormat("Package recieved, perfect delivery! Customer was very happy with the accuracy of the package. You got {0} points!", (int)_actualScore);
            }
            else
            {
                _actualScore = _pointValue - (Vector2.Distance(transform.position, _package.transform.position) * 5);
                Debug.LogFormat("Package recieved. You got {0} points!", (int)_actualScore);
            }
            

            

            _package = null;
        }
    }
}
