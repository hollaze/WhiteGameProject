using UnityEngine;
using DG.Tweening;

public class TestAnimSword : MonoBehaviour
{
    [SerializeField] Animator _animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetBool("Slash1_B", true);
        }
    }

    public void AnimSlash1End()
    {
        _animator.SetBool("Slash1_B", false);
    }
}
