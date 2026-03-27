namespace LoodsmanCommon
{
  public enum LType
  {
    /// <summary>объект</summary>
    LObject = 1,
    /// <summary>файл</summary>
    LFile = 3,
    /// <summary>атрибут</summary>
    LAttribute = 4,
    /// <summary>задание СУПР</summary>
    LTaskSUPR = 5,
    /// <summary>бизнес-процесс</summary>
    LBusinessProcess = 6,
    /// <summary>письмо</summary>
    LLetter = 7,
    /// <summary>задание WorkFlow</summary>
    LTaskWorkFlow = 9,
    /// <summary>заметка</summary>
    LNote = 10,
  }

  internal enum WindowMessage
  {
    WM_USER = 0x0400,
    WM_REFRESHVERSION = WM_USER + 1,
    WM_REFRESHPARENT = WM_USER + 4,
    WM_GOTOCHILD = WM_USER + 5,
    WM_REFRESHCHECKOUTLIST = WM_USER + 6,
    WM_REFRESHPROJECTLIST = WM_USER + 7,
    WM_GOTONODE = WM_USER + 8,
    WM_GOTOOBJECT = WM_USER + 9,
    WM_REFRESHFRAMEBYTYPE = WM_USER + 17,
    WM_GOTOOBJECT2011 = WM_USER + 18,
    WM_OPENOBJECTSINNEWWINDOW = WM_USER + 101
  }
}
