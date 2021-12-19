namespace billing.Infrastructure.Common.HttpContext
{
    public interface IRequestContext
    {
        string GetUserId();

        string GetUserRole();
    }
}