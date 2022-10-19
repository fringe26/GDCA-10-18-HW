using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using static UnityEditor.Progress;

public class PlayerController : MonoBehaviour
{
    [Header("Joystick")]
    [SerializeField] FloatingJoystick joystick;
    float Horizontal;
    float Vertical;
    [Header("Movement")]
    [SerializeField] float Speed = 10;
    Vector3 direction;
    float CurrentTurnAngle;
    [Header("Player Turn Speed")]
    [SerializeField] float SmoothTurnTime = 0.1f;
    Rigidbody rb;


    ///Detect & Collect
    [Header("Detect & Collect")]
    Collider[] colliders;
    [SerializeField] Transform detectTransform;
    [SerializeField] float DetectionRange = 1;
    [SerializeField] LayerMask layer;
    [SerializeField] Transform holdTransform;
    [SerializeField] int itemCount = 0;
    [SerializeField] float ItemDistanceBetween = 0.5f;
    [SerializeField] private Transform _bank;
    private List<Collider> _collectedCubes;
    private float _lastBankPosition=0;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _collectedCubes = new List<Collider>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(detectTransform.position, DetectionRange);
    }
    void Update()
    {
        colliders = Physics.OverlapSphere(detectTransform.position, DetectionRange, layer);
        foreach (var hit in colliders)
        {
            if (hit.CompareTag("Collectable"))
            {
                _collectedCubes.Add(hit);
                Debug.Log(hit.name);
                hit.tag = "Collected";
                hit.transform.parent = holdTransform;


                // hit.transform.DOLocalJump(new Vector3(0, itemCount * ItemDistanceBetween, 0), 2, 1, 0.2f).OnComplete(() =>
                // {
                //     hit.transform.localRotation = Quaternion.Euler(0, 0, 0);
                // });

                // var seq = DOTween.Sequence();

                // seq.Append(hit.transform.DOLocalJump(new Vector3(0, itemCount * ItemDistanceBetween), 2, 1, 0.2f))
                //     .Join(hit.transform.DOScale(0.3f, 0.2f));
                // seq.AppendCallback(() =>
                // {
                //     hit.transform.localRotation = Quaternion.Euler(0, 0, 0);
                // });


                Sequence seq = DOTween.Sequence();

                seq.Append(hit.transform.DOLocalJump(new Vector3(0, itemCount * ItemDistanceBetween), 2, 1, 0.3f))
                   .Join( hit.transform.DOScale(1.25f, 0.1f))
                   .Insert(0.1f, hit.transform.DOScale(0.5f, 0.2f));
                seq.AppendCallback(() =>
                {
                    hit.transform.localRotation = Quaternion.Euler(0, 0, 0);
                });

                itemCount++;

            }
        }
    }
    private void FixedUpdate()
    {
        Horizontal = joystick.Horizontal;
        Vertical = joystick.Vertical;

        direction = new Vector3(Horizontal, 0, Vertical);

        if (direction.magnitude > 0.01f)
        {
            float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref CurrentTurnAngle, SmoothTurnTime);
            transform.rotation = Quaternion.Euler(0, Angle, 0);

            rb.MovePosition(transform.position + (direction * Speed * Time.deltaTime));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       


        
        if (collision.transform.CompareTag("Bank"))
        {
            Debug.Log("Colide with Bank");
            Sequence animationSequence = DOTween.Sequence();


            foreach (Collider item in _collectedCubes)
            {
                item.tag = "Builded";
                item.gameObject.layer = LayerMask.NameToLayer("Default");
                item.transform.parent = _bank;

                animationSequence.Append(item.transform.DOLocalJump(new Vector3(0, _lastBankPosition * 0.75f), 2, 1, 0.3f))
                    .Join(item.transform.DOScale(2f, 0.1f))
                    .Insert(0.1f, item.transform.DOScale(0.75f, 0.1f));
                animationSequence.AppendCallback(() =>
                    {
                        item.transform.localRotation = Quaternion.identity;
                    });
                _lastBankPosition++;
            }
            _collectedCubes.Clear();


            //if (_collectedCubes.Count < 5)
            //{
            //    for (int i = 0; i < _collectedCubes.Count; i++)
            //    {
            //        _collectedCubes[i].tag = "Builded";
            //        _collectedCubes[i].gameObject.layer = LayerMask.NameToLayer("Default");
            //        _collectedCubes[i].transform.parent = _bank;

            //        animationSequence.Append(_collectedCubes[i].transform.DOLocalJump(new Vector3(-_bank.transform.GetChild(0).transform.localScale.x/2.0f, 0,_lastBankPosition*1f), 2, 1, 0.3f))
            //            .Join(_collectedCubes[i].transform.DOScale(1f, 0.1f))
            //            .Insert(0.1f, _collectedCubes[i].transform.DOScale(1f, 0.1f));
            //        animationSequence.AppendCallback(() =>
            //            {
            //                _collectedCubes[i].transform.localRotation = Quaternion.identity;
            //            });
            //        _lastBankPosition++;
            //    }
            //    _collectedCubes.Clear();
            //}



        }
    }
}
