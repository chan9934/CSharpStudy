using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    PlayerStat _stat;

    Vector3 _destPos;


    [SerializeField]
    PlayerState _state = PlayerState.Idle;
 
    int _mask = (1 << (int)Define.Layer.Monster) | (1 << (int)Define.Layer.Ground);
    GameObject _lockTarget;
  public enum PlayerState
    {
        Die,
        Moving,
        Idle,
        Skill
    }
  
    public PlayerState State
    {
        get
        {
            return _state;
        }
        set
        {
            _state = value;

            Animator anim = GetComponent<Animator>();
            switch(_state)
            {
                case PlayerState.Die:
                    break;
                case PlayerState.Idle:
                    anim.CrossFade("WAIT", 0.1f);
                    break;
                case PlayerState.Moving:
                    anim.CrossFade("RUN", 0.1f);
                    break;
                case PlayerState.Skill:
                    anim.CrossFade("ATTACK", 0.1f);
                    break;
                    
            }
        }
    }   
    void Start()
    {
        _stat = gameObject.GetComponent<PlayerStat>();
        Managers.Input.MouseAction -= OnMouseEvent;
        Managers.Input.MouseAction += OnMouseEvent;
    }
  void UpdateDie()
    {
        // 아무것도 못함

    }
    void UpdateMoving()
    {
        if(_lockTarget != null)
        {
            float distance = (_destPos - transform.position).magnitude;
            if(distance <=  2.0f)
            {
                State = PlayerState.Skill;
                return;
            }
        }
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.1f)
        {
            State = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(_stat.MoveSpeed * Time.deltaTime, 0, dir.magnitude);
            NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();

            nma.Move(dir.normalized * moveDist);
            Debug.DrawRay(transform.position, dir.normalized, Color.green);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
            if (Physics.Raycast(transform.position + Vector3.up * 0.5f, dir, 1.0f, LayerMask.GetMask("Block")))
            {
                if(!Input.GetMouseButtonDown(0))
                {

                    State = PlayerState.Idle;
                }
                return;
            }
            //transform.position += dir.normalized * moveDist;
        }

    }

    void UpdateIdle()
    {
    }

    void Update()
    {
        switch (State)
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
            case PlayerState.Skill:
                UpdateSkill();
                break;
        }
    }
    void UpdateSkill()
    {
        if(_lockTarget != null)
        {
            Vector3 dir = _lockTarget.transform.position - transform.position;
            Quaternion quat = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);
        }
    }
    void OnHitEvent()
    {
        if(_stopSkill)
        {
            State = PlayerState.Idle;
        }
        else
        {
            State = PlayerState.Skill;
        }
    }
    bool _stopSkill = false;
    void OnMouseEvent(Define.MouseEvent evt)
    {
        switch(State)
        {
            case PlayerState.Idle:
                OnMouseEvent_IdleRun(evt);
                break;
            case PlayerState.Moving:
                OnMouseEvent_IdleRun(evt);
                break;
            case PlayerState.Skill:
                {
                    if(evt == Define.MouseEvent.PointUp)
                    {
                        _stopSkill = true;
                    }
                }
                break;
        }

    }

    void OnMouseEvent_IdleRun(Define.MouseEvent evt)
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool raycastHit = Physics.Raycast(ray, out hit, 100.0f, _mask);

        switch (evt)
        {
            case Define.MouseEvent.PointDown:
                {
                    if (raycastHit)
                    {

                        _destPos = hit.point;
                        State = PlayerState.Moving;

                        _stopSkill = false;
                        if (hit.collider.gameObject.layer == (int)Define.Layer.Monster)
                        {
                            _lockTarget = hit.collider.gameObject;
                        }
                        else
                        {
                            _lockTarget = null;
                        }
                    }
                }
                break;
            case Define.MouseEvent.Press:
                {
                    if (_lockTarget == null && raycastHit)
                    {
                        _destPos = hit.point;
                    }
                }
                break;  
            case Define.MouseEvent.PointUp:
                {
                    _stopSkill = true;

                }
                break;

        }
    }
}
