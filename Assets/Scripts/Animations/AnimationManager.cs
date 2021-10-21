using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    const string Speed = "speed";
    
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetSpeed(float value)
    {
        animator.SetFloat(Speed, value);
    }
}
