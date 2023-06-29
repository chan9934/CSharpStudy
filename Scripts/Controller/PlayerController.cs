using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState
    {
        Die,
        Moving,
        Idle
    }
    public PlayerState _state = PlayerState.Idle;
    [SerializeField]
    float speed = 10.0f;
   
    Vector3 _desPos;

    void UpdateDie()
    {
    }
    void UpdateMoving()
    {
        Vector3 dir = _desPos - transform.position;

        if (dir.magnitude < 0.0001f)
        {
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(speed * Time.deltaTime, 0, dir.magnitude);
            transform.position = transform.position + dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
        }

        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", speed);
    }
    void UpdateIdle()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", 0);
    }
    void Start()
    {
        Manager.Input.MouseAction -= OnMouseClicked;
        Manager.Input.MouseAction += OnMouseClicked;
        //Manager.Resource.Instantiate("UI/UI_Button");
       
            //Manager.UI.ShowScenepUI<UI_Inven>();

        //Manager.UI.ClosePopupUI();
    }   
    void Update()
    {
        switch (_state)
           {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
            default:
                break;
        }
    }

    void OnMouseClicked(Define.MouseEvent evt)
    {
        //if (evt != Define.MouseEvent.Click)
        //{
        //    return;
        //}
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        LayerMask mask = LayerMask.GetMask("Wall");
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, mask))
        {
            Debug.DrawRay(Camera.main.transform.position, ray.direction * (hit.point - Camera.main.transform.position).magnitude, Color.green, 1.0f);
          //  Debug.Log($"{hit.collider.gameObject.name}");

            _state = PlayerState.Moving;
            _desPos = hit.point;

        }


    }
}
