namespace Sales.WEB.Repositories
{
    public interface IRepository
    {
        Task<HttpResponseWrapper<T>> Get<T>(string url);

        // Post que no devuelve nada
        Task<HttpResponseWrapper<object>> Post<T>(string url, T model);

        // Post que devuelve algo
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T model);
    }

}
