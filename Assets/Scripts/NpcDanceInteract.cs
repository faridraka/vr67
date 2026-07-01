using System.Collections;
using UnityEngine;

public class NpcDanceInteract : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float danceDuration = 17.233f;

    private bool isDance = false;

    private void Awake()
    {
        if (animator == null)
            animator = GetComponentInChildren<Animator>();
    }

    public void Interact()
    {
        if (isDance) return;

        StartCoroutine(DanceOnce());
    }

    private IEnumerator DanceOnce()
    {
        isDance = true;

        animator.SetBool("isIdle", false);
        animator.SetBool("isDance", true);

        yield return new WaitForSeconds(danceDuration);

        animator.SetBool("isDance", false);
        animator.SetBool("isIdle", true);

        isDance = false;
    }
}
