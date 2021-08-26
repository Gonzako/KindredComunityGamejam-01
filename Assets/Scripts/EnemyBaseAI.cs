using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBaseAI : MonoBehaviour
{

    public bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RollInAnimation(Vector2 Position)
    {
        var zManager = GetComponent<ZLevelManager>();
        zManager.enabled = false;

        transform.position.Scale(Vector2.one);
        transform.position += Vector3.forward * 3;

        var sequence = DOTween.Sequence();

        sequence.Append(transform.DOMove(new Vector3(Position.x, Position.y, 3), 0.6f).SetEase(Ease.OutBounce));
        sequence.AppendInterval(0.2f);
        sequence.Append(transform.DOMove(Position, 0.7f).SetEase(Ease.OutQuint));

        DOTween.Play(sequence.id);

        yield return new WaitUntil(() => !sequence.IsPlaying());

        zManager.enabled = true;
    }
}
