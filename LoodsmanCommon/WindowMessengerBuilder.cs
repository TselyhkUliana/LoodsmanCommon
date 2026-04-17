using Ascon.Plm.Loodsman.PluginSDK;

namespace LoodsmanCommon
{
  internal class WindowMessengerBuilder
  {
    private static ILoodsmanWindowMessenger _loodsmanWindowMessenger;
    public static ILoodsmanWindowMessenger GetInstance()
    {
      return _loodsmanWindowMessenger ??= new LoodsmanWindowMessenger();
    }
  }
}
