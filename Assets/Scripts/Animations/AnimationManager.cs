using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    const string Speed = "speed";
    const string IsFiring = "isFiring";
    
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetSpeed(float value)
    {
        animator.SetFloat(Speed, value);
    }

    public void SetIsFiring(bool value)
    {
        animator.SetBool(IsFiring, value);
    }
}
