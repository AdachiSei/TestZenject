using Template.Extension;
using UnityEngine;

namespace Template.Manager
{
    /// <summary>
    /// シーンローダーの関数を呼ぶためのクラス
    /// </summary>
    [RequireComponent(typeof(FadeViewBase))]
    public class SceneLoaderCaller : MonoBehaviour
    {
        #region Properties

        public SceneLoader SceneLoader { get; private set; } = new();

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (TryGetComponent(out IFadable fadable))
            {
                fadable.FadeInMethod();
                SceneLoader.RegisterFadeIn(fadable.FadeInMethod);
                SceneLoader.RegisterFadeOut(fadable.FadeOutMethod);
            }
        }

        #endregion

        #region Public Methods

        public void LoadScene(string name)
        {
            SceneLoader.LoadScene(name);
        }

        #endregion
    }
}