using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 获得动画组件工厂
/// </summary>
public class AnimationFactory {

	private IPlayAnimation _ani;
    private AnimationFactory() { }
    private static AnimationFactory factory;
    private static object oo = new object();
    public static AnimationFactory getAniFactory() {
        if (factory == null)
        {
            lock (oo)
            {
                factory = new AnimationFactory();

            }
        }
        return factory;
    }
    /// <summary>
    /// 得到模型动画的组件
    /// </summary>
    /// <param name="modeType"></param>
    /// <returns></returns>
    public IPlayAnimation GetPlayerAniComponent(PlayerAniModeType  modeType) {

        switch (modeType) {
            case PlayerAniModeType.YuKa:
                _ani = PlayerYuKAnimation._instance;
                break;

        }



        return _ani;
    }

}
