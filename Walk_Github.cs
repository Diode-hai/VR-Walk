using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk_Github : MonoBehaviour
{

    public Transform vrCamera;

    public GameObject _Player;
    private Vector3 _Godown;
    public float _speed = 0.5f;
    public AudioClip _HitSFX;
    public Transform _parFX;
    private Transform _parPoint;
    float _Time = 0.0f;

    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        _Godown = transform.TransformDirection(new Vector3(0, 0, 6));
        Debug.DrawRay(transform.position, _Godown, Color.red);

        RaycastHit _hit;
        if (Physics.Raycast(transform.position, _Godown, out _hit, 6))
        {
          
            if (vrCamera.eulerAngles.x >= 7 && vrCamera.eulerAngles.x < 55.0f && _Player.transform.position.y > -2.8f)
            //if (_hit.collider.name == "Plane")
            {
                Vector3 _hitPoint = new Vector3(_hit.point.x, _hit.point.y, _hit.point.z);
                _Player.transform.position = Vector3.Lerp(_Player.transform.position, _hitPoint, _speed * Time.deltaTime);
            }

            else if (_hit.collider.name == "Cylinder") //Question_mark
            {
                _Time += Time.deltaTime;
                if (_Time >= 3)
                {
                    GetComponent<AudioSource>().PlayOneShot(_HitSFX, 0.3f);
                    _parPoint = (Transform)Instantiate(_parFX, transform.position, transform.rotation);
                    Destroy(_parPoint.gameObject, 3);
                    _Time = 0.0f;
                }
            }

            else { _Time = 0.0f; }
        }
    }
}
