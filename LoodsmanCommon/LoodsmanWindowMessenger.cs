using Ascon.Plm.Loodsman.PluginSDK;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LoodsmanCommon
{
  internal class LoodsmanWindowMessenger : ILoodsmanWindowMessenger
  {
    private readonly IntPtr _clientHandle;
    private readonly IntPtr _mainHandle;

    public LoodsmanWindowMessenger(INetPluginCall iNetPC)
    {
      _clientHandle = (IntPtr)iNetPC.PluginCall.ClientHandle;
      _mainHandle = (IntPtr)iNetPC.PluginCall.MainHandle;
    }

    public void GoToChild(int id) => Post(_clientHandle, WindowMessage.WM_GOTOCHILD, (IntPtr)id, IntPtr.Zero);

    public void GoToNode(int id) => Post(_clientHandle, WindowMessage.WM_GOTONODE, (IntPtr)id, IntPtr.Zero);

    public void GoToObject(int id) => Post(_clientHandle, WindowMessage.WM_GOTOOBJECT, (IntPtr)id, IntPtr.Zero);

    public void GoToObject2011(int id) => Post(_clientHandle, WindowMessage.WM_GOTOOBJECT2011, (IntPtr)id, IntPtr.Zero);

    public void OpenObjectInNewWindow(int id)
    {
      var msg = new TMSGPARAMS
      {
        Reserved = IntPtr.Zero,
        CheckOutName = IntPtr.Zero,
        ObjectId = (uint)id,
        ObjectIds = IntPtr.Zero
      };
      SendMessageStruct(_mainHandle, WindowMessage.WM_OPENOBJECTSINNEWWINDOW, msg);
    }

    public void OpenObjectsInNewWindow(IEnumerable<int> ids)
    {
      var strPtr = Marshal.StringToHGlobalAnsi(string.Join(",", ids));

      try
      {
        var msg = new TMSGPARAMS
        {
          Reserved = IntPtr.Zero,
          CheckOutName = IntPtr.Zero,
          ObjectId = 0,
          ObjectIds = strPtr
        };
        SendMessageStruct(_mainHandle, WindowMessage.WM_OPENOBJECTSINNEWWINDOW, msg);
      }
      finally
      {
        Marshal.FreeHGlobal(strPtr);
      }
    }

    public void RefreshCheckoutList() => Post(_mainHandle, WindowMessage.WM_REFRESHCHECKOUTLIST, IntPtr.Zero, IntPtr.Zero);

    public void RefreshParent(int id) => Post(_clientHandle, WindowMessage.WM_REFRESHPARENT, (IntPtr)id, IntPtr.Zero);

    public void RefreshProjectList() => Post(_clientHandle, WindowMessage.WM_REFRESHPROJECTLIST, IntPtr.Zero, IntPtr.Zero);

    public void RefreshFrameByType(LType type) => Post(_clientHandle, WindowMessage.WM_REFRESHFRAMEBYTYPE, (IntPtr)type, IntPtr.Zero);

    private void SendMessageStruct<T>(IntPtr hwnd, WindowMessage windowMessage, T data) where T : struct
    {
      var ptr = Marshal.AllocHGlobal(Marshal.SizeOf<T>());
      try
      {
        Marshal.StructureToPtr(data, ptr, false);
        Send(hwnd, windowMessage, ptr, IntPtr.Zero);
      }
      finally
      {
        Marshal.FreeHGlobal(ptr);
      }
    }

    private void Post(IntPtr hwnd, WindowMessage message, IntPtr wParam = default, IntPtr lParam = default) => NativeMethods.PostMessage(hwnd, (int)message, wParam, lParam);
    private void Send(IntPtr hwnd, WindowMessage message, IntPtr wParam = default, IntPtr lParam = default) => NativeMethods.SendMessage(hwnd, (int)message, wParam, lParam);
  }

  internal static class NativeMethods
  {
    [DllImport("user32.dll")]
    public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);
  }

  [StructLayout(LayoutKind.Sequential)]
  struct TMSGPARAMS
  {
    public IntPtr Reserved;
    public IntPtr CheckOutName;
    public uint ObjectId;
    public IntPtr ObjectIds;
  }
}
