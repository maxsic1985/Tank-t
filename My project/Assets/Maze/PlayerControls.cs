using UniRx;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControls : MonoBehaviour, IPlayer
{
    public float Speed = 1;
    private Rigidbody2D componentRigidbody;

    [Inject]
    private void Init()
    {
        componentRigidbody = GetComponent<Rigidbody2D>();
        var resetVelocity= Observable.EveryFixedUpdate().Subscribe(_ => { componentRigidbody.velocity = Vector2.zero; });
        var inpusKeyKodeStream = Observable.EveryFixedUpdate().Where(_ => Input.anyKey);
        var leftClick = inpusKeyKodeStream.Where(_ => Input.GetKey(KeyCode.LeftArrow)).Subscribe(_ => { componentRigidbody.velocity += Vector2.left * Speed; });
        var rightClick = inpusKeyKodeStream.Where(_ => Input.GetKey(KeyCode.RightArrow)).Subscribe(_ => { componentRigidbody.velocity += Vector2.right * Speed; });
        var downClick = inpusKeyKodeStream.Where(_ => Input.GetKey(KeyCode.DownArrow)).Subscribe(_ => { componentRigidbody.velocity += Vector2.down * Speed; });
        var upClick = inpusKeyKodeStream.Where(_ => Input.GetKey(KeyCode.UpArrow)).Subscribe(_ => { componentRigidbody.velocity += Vector2.up * Speed; });
    }

}
