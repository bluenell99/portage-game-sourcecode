using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Animator animator;

    public virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

}
