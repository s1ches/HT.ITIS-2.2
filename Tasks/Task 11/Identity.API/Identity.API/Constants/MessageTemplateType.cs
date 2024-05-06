using System.ComponentModel;

namespace Identity.API.Constants;

public enum MessageTemplateType
{
    [Description("Сообщение для подтверждения почты")]
    ConfirmEmailMessage = 0
}