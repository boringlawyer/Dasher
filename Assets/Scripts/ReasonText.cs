using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ReasonText : MonoBehaviour
{
    // Start is called before the first frame update
    public ReasonForDying reasonAsset;
    void Start()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        switch (reasonAsset.reason)
        {
            case ReasonForDying.Reason.Abyss:
                text.text = "You fell into the abyss";
                break;
            case ReasonForDying.Reason.FellOffScreen:
                text.text = "You traveled off-screen";
                break;
            case ReasonForDying.Reason.HitObstacle:
                text.text = "You hit an obstacle";
                break;
            case ReasonForDying.Reason.TooManyClicks:
                text.text = "You dashed too many times without landing on a platform";
                break;
        }
    }
}
