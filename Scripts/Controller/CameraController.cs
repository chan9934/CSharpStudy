using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f);

    [SerializeField]
    GameObject _player = null;

    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;
    void Start()
    {

    }

    void LateUpdate()
    {

        if (_mode == Define.CameraMode.QuarterView)
        {
            RaycastHit hit;
            if (Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {

                float dist = (hit.point - _player.transform.position ).magnitude * 0.8f;
                transform.position = _player.transform.position + _delta.normalized * dist;
                transform.LookAt(_player.transform);
            }
            else if (_player != null)
            {
                transform.position = _player.transform.position + _delta;
                transform.LookAt(_player.transform);
            }
        }

    }


    void SetQuarterView(Vector3 delta)
    {
        _delta = delta;
        _mode = Define.CameraMode.QuarterView;
    }
}
