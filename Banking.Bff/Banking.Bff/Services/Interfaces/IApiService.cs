using Banking.Bff.Enums;

namespace Banking.Bff.Services.Interfaces
{
    public interface IApiService
    {
        Task<HttpResponseMessage> SendGetAsync(
            string url,
            NomeHttpClient nomeHttpClient,
            string sistema,
            string msgErro,
            double? timeoutSegundos = null,
            string? eTag = null);

        Task<HttpResponseMessage> SendPostAsync(
            string url,
            object entrada,
            NomeHttpClient nomeHttpClient,
            string sistema,
            string msgErro,
            double? timeoutSegundos = null,
            string? eTag = null);

        Task<HttpResponseMessage> SendPutAsync(
            string url,
            object entrada,
            NomeHttpClient nomeHttpClient,
            string sistema,
            string msgErro,
            double? timeoutSegundos = null,
            string? eTag = null);

        Task<HttpResponseMessage> SendPatchAsync(
            string url,
            object entrada,
            NomeHttpClient nomeHttpClient,
            string sistema,
            string msgErro,
            double? timeoutSegundos = null,
            string? eTag = null);

        Task<HttpResponseMessage> SendDeleteAsync(
            string url,
            object entrada,
            NomeHttpClient nomeHttpClient,
            string sistema,
            string msgErro,
            double? timeoutSegundos = null,
            string? eTag = null);
    }
}
