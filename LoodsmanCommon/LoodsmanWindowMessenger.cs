using Ascon.Plm.Loodsman.PluginSDK;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LoodsmanCommon
{
  internal class LoodsmanWindowMessenger : ILoodsmanWindowMessenger
  {
    private static IntPtr _clientHandle;
    private static IntPtr _mainHandle;
    private static bool _initialized;

    /// <summary>Дескриптор активного MDI окна</summary>
    private static IntPtr ClientHandle =>
        _initialized
            ? _clientHandle
            : throw new InvalidOperationException("WindowMessenger не инициализирован. Вызовите Initialize.");

    /// <summary>Дескриптор главного окна</summary>
    private static IntPtr MainHandle =>
        _initialized
            ? _mainHandle
            : throw new InvalidOperationException("WindowMessenger не инициализирован. Вызовите Initialize.");

    /// <summary>Инициализирует или переинициализирует дескрипторы окна.</summary>
    /// <remarks>
    /// Метод можно вызывать повторно — предыдущие значения будут перезаписаны.
    ///<br/> Используется при смене активного окна или контекста плагина.
    /// </remarks>
    public void Initialize(INetPluginCall call)
    {
      _clientHandle = (IntPtr)call.PluginCall.ClientHandle;
      _mainHandle = (IntPtr)call.PluginCall.MainHandle;
      _initialized = true;
    }

    public void GoToChild(int id) => Post(ClientHandle, WindowMessage.WM_GOTOCHILD, (IntPtr)id, IntPtr.Zero);

    public void GoToNode(int id) => Post(ClientHandle, WindowMessage.WM_GOTONODE, (IntPtr)id, IntPtr.Zero);

    public void GoToObject(int id) => Post(ClientHandle, WindowMessage.WM_GOTOOBJECT, (IntPtr)id, IntPtr.Zero);

    public void GoToObject2011(int id) => Post(ClientHandle, WindowMessage.WM_GOTOOBJECT2011, (IntPtr)id, IntPtr.Zero);

    public void OpenObjectInNewWindow(int id)
    {
      var msg = new TMSGPARAMS
      {
        Reserved = IntPtr.Zero,
        CheckOutName = IntPtr.Zero,
        ObjectId = (uint)id,
        ObjectIds = IntPtr.Zero
      };
      SendMessageStruct(MainHandle, WindowMessage.WM_OPENOBJECTSINNEWWINDOW, msg);
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
        SendMessageStruct(MainHandle, WindowMessage.WM_OPENOBJECTSINNEWWINDOW, msg);
      }
      finally
      {
        Marshal.FreeHGlobal(strPtr);
      }
    }

    public void RefreshCheckoutList() => Post(MainHandle, WindowMessage.WM_REFRESHCHECKOUTLIST, IntPtr.Zero, IntPtr.Zero);

    public void RefreshParent(int id) => Post(ClientHandle, WindowMessage.WM_REFRESHPARENT, (IntPtr)id, IntPtr.Zero);

    public void RefreshProjectList() => Post(ClientHandle, WindowMessage.WM_REFRESHPROJECTLIST, IntPtr.Zero, IntPtr.Zero);

    public void RefreshFrameByType(LType type) => Post(ClientHandle, WindowMessage.WM_REFRESHFRAMEBYTYPE, (IntPtr)type, IntPtr.Zero);

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
