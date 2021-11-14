using UnityEngine;

namespace HackedDesign.UI
{
    public class BottomPresenter : AbstractPresenter
    {
        [SerializeField] UnityEngine.UI.Slider willSlider;
        public override void Repaint()
        {
            willSlider.value = Game.Instance.Data.Will;
        }
    }
}