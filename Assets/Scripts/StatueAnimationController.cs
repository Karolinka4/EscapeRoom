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
            Debug.LogError("Brak Animatora na pos¹gu!");
        }

        if (stairsAnimator == null)
        {
            Debug.LogError("Brak przypisanych schodów w Inspectorze!");
        }
        else
        {
            stairsAnimator.enabled = false;
        }
    }

    public void StartStatueSequence()
    {
        Debug.Log("Uruchamiam animacjê Sfinksa i schody bêd¹ póŸniej!");
        statueAnimator.Play("Low_SfinksPrawdziwy", 0, 0); // dok³adna nazwa stanu animacji!
        startStatueAnim = true;
    }

    void Update()
    {
        if (!startStatueAnim || animationStarted) return;

        AnimatorStateInfo stateInfo = statueAnimator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 1.0f && !stateInfo.loop)
        {
            Debug.Log("Animacja pos¹gu zakoñczona. Uruchamiam schody!");

            stairsAnimator.enabled = true;
            stairsAnimator.Play("ceglyIdle", 0, 0);
            animationStarted = true;
        }
    }
}
