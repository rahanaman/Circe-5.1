using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CreatureView : MonoBehaviour
{
    [SerializeField] protected Image _hpImage;
    [SerializeField] protected Text _hpText;
    [SerializeField] protected RectTransform _subCon;

    protected CreatureSubScripter[] _subs;

    public void SetHpView(int current, int max)
    {
        float portion = current / max;
        _hpImage.fillAmount = portion;
        _hpText.text = current + "/" + max;
    }

    public void SetSub(List<EffectID> effects)
    {
        ClearSub();
        foreach (EffectID effect in effects)
        {

        }
    }

    private void ClearSub()
    {
        foreach(var sub in _subs)
        {
            Destroy(sub);
        }
    }

}


