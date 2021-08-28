using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public abstract class EnemyBaseAI : MonoBehaviour
{

    [SerializeField]
    protected List<BulletSpawner> MoonShots;
    [SerializeField]
    protected List<BulletSpawner> SunShots;

    [SerializeField]
    protected UnityEvent OnFinishedMoving;

    protected bool UseSun;
    public Bounds allowedBounds;

    // Start is called before the first frame update
    void Start()
    {
        UseSun = Random.value > 0.5f;
    }

    private void OnEnable()
    {
        StartCoroutine(RollInAnimation((Vector2)UtilityScripts.RandomPointInBounds(allowedBounds)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected IEnumerator RollInAnimation(Vector2 Position)
    {
        var zManager = GetComponent<ZLevelManager>();
        zManager.enabled = false;

        transform.position.Scale(Vector2.one);
        transform.position += Vector3.forward * 3;

        var sequence = DOTween.Sequence();

        sequence.Append(transform.DOMove(new Vector3(Position.x, Position.y, 3), 1.6f).SetEase(Ease.OutBack));
        sequence.AppendInterval(0.1f);
        sequence.Append(transform.DOMove(Position, 0.7f).SetEase(Ease.OutQuint));

        DOTween.Play(sequence.id);

        yield return new WaitUntil(() => !sequence.IsPlaying());
        OnFinishedMoving.Invoke();

        zManager.enabled = true;
        StartCoroutine(BehaviourRoutine());
    }

    protected abstract IEnumerator BehaviourRoutine();
    
    protected virtual void HandleShots()
    {
        if (UseSun)
        {
            for (int i = 0; i < MoonShots.Count; i++)
            {
                MoonShots[i].CreateShot();
            }
        }
        else
        {
            for (int i = 0; i < SunShots.Count; i++)
            {
                SunShots[i].CreateShot();
            }
        }
    }
}
