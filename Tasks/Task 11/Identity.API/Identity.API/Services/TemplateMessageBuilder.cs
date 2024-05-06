using Identity.API.Constants;
using Identity.API.Interfaces;

namespace Identity.API.Services;

public class TemplateMessageBuilder : ITemplateMessageBuilder
{
    private static readonly Dictionary<MessageTemplateType, string> MessageTypesAndPaths = new()
    {
        {
            MessageTemplateType.ConfirmEmailMessage,
            Path.Combine(Directory.GetCurrentDirectory(), "Templates", "ConfirmEmailMessage.html")
        }
    };
    
    public async Task<string> BuildTemplate(MessageTemplateType messageType,
        CancellationToken cancellationToken,
        params string[] arguments)
    {
        var message = await File.ReadAllTextAsync(MessageTypesAndPaths[messageType], cancellationToken);

        var id = 0;
        foreach (var argument in arguments)
            message = message.Replace("{{param"+(id++)+"}}", argument);

        return message;
    }
}