using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI text;
    public Animator animator;

    public void Highlight()
    {
        animator.SetTrigger("highlight");
    }

    public void SetScore(int value)
    {
        text.text = value.ToString();
    }
}