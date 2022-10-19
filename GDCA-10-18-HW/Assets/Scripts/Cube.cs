using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour
{
    [SerializeField] float XPos;
    [SerializeField] float YPos;
    [SerializeField] float ZPos;
    [SerializeField] float AnimationDuration;
    [SerializeField] Vector3 Pos;

    [SerializeField] Vector3 EndPosition;

    [SerializeField] Ease ease;

    [SerializeField] AnimationCurve curve;
    void Start()
    {

        // transform.DOMoveX(XPos, AnimationDuration);
        //transform.DOLocalMoveX

        // transform.DOMoveY(YPos, AnimationDuration);
        //transform.DOLocalMoveY

        // transform.DOMoveZ(ZPos, AnimationDuration);
        //transform.DOLocalMove

        // transform.DOMove(Pos,AnimationDuration);

        //transform.DOLocalMove(Pos,AnimationDuration);

        //transform.DORotate(new Vector3(30,60,90),AnimationDuration);
        // transform.DOLocalRotate()

        //transform.DOScale(new Vector3(1, 2, 3), AnimationDuration);
        // transform.DOScale(3,AnimationDuration);

        //transform.DOScaleX
        //transform.DOScaleY
        //transform.DOScaleZ

        //
        // transform.DOJump(EndPosition,5,1,AnimationDuration);


        // transform.DOMoveX(XPos, AnimationDuration).SetLoops(2,LoopType.Yoyo);
        //transform.DOMoveX(XPos, AnimationDuration).SetLoops(2, LoopType.Restart);
        //transform.DOMoveX(XPos, AnimationDuration).SetLoops(2, LoopType.Incremental);


        //transform.DORotate(new Vector3(0,0,90),AnimationDuration).SetLoops(-1,LoopType.Incremental);

        //transform.DOMoveX(XPos, AnimationDuration).SetLoops(-1,LoopType.Yoyo);

        // transform.DOScale(2, AnimationDuration).SetLoops(3, LoopType.Incremental);
        //transform.DOScale(2, AnimationDuration).SetLoops(3, LoopType.Restart);
        //transform.DOScale(2, AnimationDuration).SetLoops(-1, LoopType.Yoyo);


        //transform.DOMoveX(XPos, AnimationDuration).SetLoops(2, LoopType.Restart).SetEase(ease);

        //transform.DOMoveX(XPos, AnimationDuration).SetLoops(2, LoopType.Restart).SetEase(curve);

        // transform.DOMoveX(XPos, AnimationDuration).OnComplete(() =>
        //    {
        //        transform.DOMoveY(YPos, AnimationDuration).OnComplete(() =>
        //        {
        //            transform.DOMoveX(-XPos, AnimationDuration).OnComplete(() =>
        //            {
        //                transform.DOMoveY(0, AnimationDuration);
        //            });
        //        });
        //    });



        //transform.DOShakeScale(2f, 1);

        // var seq = DOTween.Sequence();
        // seq.Append(transform.DOMoveX(5, 1));
        // seq.Append(transform.DOMoveY(5, 1));
        // seq.Append(transform.DOMoveX(-5, 1));
        // seq.Append(transform.DOMoveY(0, 1));
        // seq.SetLoops(-1, LoopType.Restart);



        // var seq = DOTween.Sequence();
        // seq.Append(transform.DOMoveX(5, 2)).Join(transform.DORotate(new Vector3(180, 0, 0), 2));
        // seq.SetLoops(-1, LoopType.Yoyo);



        // var seq = DOTween.Sequence();
        // seq.Append(transform.DOMoveX(5,5)).Insert(2,transform.DORotate(new Vector3(0,0,180),2));


        // var seq = DOTween.Sequence();
        // seq.Append(transform.DOMoveY(5, 3)).Insert(0.5f, transform.DOMoveX(5, 0.5f)).Insert(1.5f, transform.DOMoveX(-5, 0.5f)).Insert(2.5f, transform.DOMoveX(0, 0.5f));


        // var seq = DOTween.Sequence();
        // seq.Append(transform.DOMoveX(5, 1));
        // seq.AppendCallback(() =>
        // {
        //     Debug.Log(transform.position);
        // });
        // seq.Append(transform.DOMoveY(5, 1));
        // seq.AppendCallback(() =>
        // {
        //     Debug.Log(transform.position);
        // });
        // seq.Append(transform.DOMoveX(-5, 1));
        // seq.AppendCallback(() =>
        // {
        //     Debug.Log(transform.position);
        // });
        // seq.Append(transform.DOMoveY(0, 1));
        // seq.AppendCallback(() =>
        // {
        //     Debug.Log(transform.position);
        // });


        // var seq = DOTween.Sequence();
        // seq.Append(transform.DOMoveX(5, 5)).InsertCallback(2, () =>
        // {
        //     transform.DORotate(new Vector3(0, 0, 90), 0.5f).SetLoops(-1, LoopType.Incremental);
        //     Debug.Log(transform.position);
        // });


        // var seq = DOTween.Sequence();
        // seq.AppendCallback(() => { Debug.Log("Bekleme Başladı"); });
        // seq.AppendInterval(2).InsertCallback(1, () => { Debug.Log("1 Saniyesini bekledik"); });
        // seq.AppendCallback(() => { Debug.Log("Bekleme Bitti 2 saniye bekledik"); });
        // seq.Append(transform.DOMoveX(5, 2));
        // seq.AppendCallback(() => { Debug.Log(transform.position); });
        // seq.AppendCallback(() => { Debug.Log("Bekleme Başladı"); });
        // seq.AppendInterval(2).InsertCallback(1, () => { Debug.Log("1 Saniyesini bekledik"); }); ;
        // seq.AppendCallback(() => { Debug.Log("Bekleme Bitti 2 saniye bekledik"); });
        // seq.Append(transform.DOMoveY(5, 2));
        // seq.AppendCallback(() => { Debug.Log(transform.position); });
        // seq.AppendCallback(() => { Debug.Log("Bekleme Başladı"); });
        // seq.AppendInterval(2).InsertCallback(1, () => { Debug.Log("1 Saniyesini bekledik"); }); ;
        // seq.AppendCallback(() => { Debug.Log("Bekleme Bitti 2 saniye bekledik"); });
        // seq.Append(transform.DOMoveX(-5, 2));
        // seq.AppendCallback(() => { Debug.Log(transform.position); });
        // seq.AppendCallback(() => { Debug.Log("Bekleme Başladı"); });
        // seq.AppendInterval(2).InsertCallback(1, () => { Debug.Log("1 Saniyesini bekledik"); }); ;
        // seq.AppendCallback(() => { Debug.Log("Bekleme Bitti 2 saniye bekledik"); });
        // seq.Append(transform.DOMoveY(0, 2));
        // seq.AppendCallback(() => { Debug.Log(transform.position); });
        // seq.SetLoops(-1, LoopType.Restart);

    }

    // private void OnMouseDown()
    // {
    //     // transform.DOShakeScale(0.2f, 1);
    //     transform.DOShakePosition(0.5f, 1);
    // }
}
