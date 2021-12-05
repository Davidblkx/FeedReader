using read_feed.core.Infra;

namespace read_feed.core.Exeptions
{
    public class ForbiddenException : BaseApiException
    {
        public ForbiddenException() : base(ApiErrors.Forbidden) { }
    }
}
