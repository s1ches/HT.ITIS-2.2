using Identity.API.Constants;

namespace Identity.API.Interfaces;

public interface ITemplateMessageBuilder
{
    public Task<string> BuildTemplate(MessageTemplateType messageType,
        CancellationToken cancellationToken,
        params string[] arguments);
}