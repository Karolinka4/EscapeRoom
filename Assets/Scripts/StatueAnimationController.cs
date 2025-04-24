using UnityEngine;

public class StatueAnimationController : MonoBehaviour
{
    public Animator stairsAnimator;
    private Animator statueAnimator;

    private bool animationStarted = false;
    private bool startStatueAnim = false;

    void Start()
    {
        statueAnimator = GetComponent<Animator>();

        if (statueAnimator == null)
        {
            Debug.LogError("Brak Animatora na pos�gu!");
        }

        if (stairsAnimator == null)
        {
            Debug.LogError("Brak przypisanych schod�w w Inspectorze!");
        }
        else
        {
            stairsAnimator.enabled = false;
        }
    }

    public void StartStatueSequence()
    {
        Debug.Log("Uruchamiam animacj� Sfinksa i schody b�d� p�niej!");
        statueAnimator.Play("Low_SfinksPrawdziwy", 0, 0); // dok�adna nazwa stanu animacji!
        startStatueAnim = true;
    }

    void Update()
    {
        if (!startStatueAnim || animationStarted) return;

        AnimatorStateInfo stateInfo = statueAnimator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 1.0f && !stateInfo.loop)
        {
            Debug.Log("Animacja pos�gu zako�czona. Uruchamiam schody!");

            stairsAnimator.enabled = true;
            stairsAnimator.Play("ceglyIdle", 0, 0);
            animationStarted = true;
        }
    }
}
