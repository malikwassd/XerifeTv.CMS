namespace XerifeTv.CMS.Models.Abstractions;

public enum EMessageViewType
{
  SUCCESS,
  ALERT,
  ERROR
}

public record MessageView(EMessageViewType Type, string Message);
