using Banking.Bff.Config;
using Banking.Bff.DTO.Erros;
using Banking.Bff.Enums;
using Banking.Bff.Exceptions;
using Banking.Bff.Services.Interfaces;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Banking.Bff.Services
{
    public class ApiService : IApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ApiService> _logger;

        public ApiService(
            IHttpClientFactory httpClientFactory,
            ILogger<ApiService> logger,
            IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<HttpResponseMessage> SendGetAsync(
            string url,
            NomeHttpClient nomeHttpClient,
            string sistema,
            string msgErro,
            double? timeoutSegundos = null,
            string? eTag = null)
        {
            HttpRequestMessage? request = null;
            var timeout = timeoutSegundos ?? AppSettings.ServicesConfig.TimeoutPadraoMilissegundos;

            try
            {
                var httpClient = _httpClientFactory.CreateClient(nomeHttpClient.ToString());
                httpClient.Timeout = TimeSpan.FromMilliseconds(timeout);

                _logger.LogInformation("[SEND_GET_ASYNC][INICIO] Acessando api");

                request = new HttpRequestMessage(HttpMethod.Get, url);

                return await httpClient.SendAsync(request);
            }
            catch (TaskCanceledException ex)
            {
                _logger.LogError(ex, "[SEND_GET_ASYNC][ERRO] Timeout ao acessar API");
                throw CriarErroTimeout(sistema, msgErro);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "[SEND_GET_ASYNC][ERRO] Erro HTTP ao acessar API");
                throw CriarErroHttp(sistema, msgErro);
            }
        }

        public async Task<HttpResponseMessage> SendPostAsync(
            string url,
            object entrada,
            NomeHttpClient nomeHttpClient,
            string sistema,
            string msgErro,
            double? timeoutSegundos = null,
            string? eTag = null)
        {
            HttpRequestMessage? request = null;
            var timeout = timeoutSegundos ?? AppSettings.ServicesConfig.TimeoutPadraoMilissegundos;

            try
            {
                var httpClient = _httpClientFactory.CreateClient(nomeHttpClient.ToString());
                httpClient.Timeout = TimeSpan.FromMilliseconds(timeout);

                _logger.LogInformation(
                    "[SEND_POST_ASYNC][INICIO] Acessando api");

                request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = JsonContent.Create(entrada);

                return await httpClient.SendAsync(request);
            }
            catch (TaskCanceledException ex)
            {
                _logger.LogError(ex, "[SEND_POST_ASYNC][ERRO] Timeout ao acessar API");
                throw CriarErroTimeout(sistema, msgErro);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "[SEND_POST_ASYNC][ERRO] Timeout ao acessar API");
                throw CriarErroHttp(sistema, msgErro);
            }
        }

        public async Task<HttpResponseMessage> SendPutAsync(
            string url,
            object entrada,
            NomeHttpClient nomeHttpClient,
            string sistema,
            string msgErro,
            double? timeoutSegundos = null,
            string? eTag = null)
        {
            HttpRequestMessage? request = null;
            var timeout = timeoutSegundos ?? AppSettings.ServicesConfig.TimeoutPadraoMilissegundos;

            try
            {
                var httpClient = _httpClientFactory.CreateClient(nomeHttpClient.ToString());
                httpClient.Timeout = TimeSpan.FromMilliseconds(timeout);

                _logger.LogInformation(
                    "[SEND_PUT_ASYNC][INICIO] Acessando api");

                request = new HttpRequestMessage(HttpMethod.Put, url);
                request.Content = JsonContent.Create(entrada);

                return await httpClient.SendAsync(request);
            }
            catch (TaskCanceledException ex)
            {
                _logger.LogError(ex, "[SEND_PUT_ASYNC][ERRO] Timeout ao acessar API");
                throw CriarErroTimeout(sistema, msgErro);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "[SEND_PUT_ASYNC][ERRO] Erro HTTP ao acessar API");
                throw CriarErroHttp(sistema, msgErro);
            }
        }

        public async Task<HttpResponseMessage> SendPatchAsync(
            string url,
            object entrada,
            NomeHttpClient nomeHttpClient,
            string sistema,
            string msgErro,
            double? timeoutSegundos = null,
            string? eTag = null)
        {
            HttpRequestMessage? request = null;
            var timeout = timeoutSegundos ?? AppSettings.ServicesConfig.TimeoutPadraoMilissegundos;

            try
            {
                var httpClient = _httpClientFactory.CreateClient(nomeHttpClient.ToString());
                httpClient.Timeout = TimeSpan.FromMilliseconds(timeout);

                _logger.LogInformation(
                    "[SEND_PATCH_ASYNC][INICIO] Acessando api");

                request = new HttpRequestMessage(HttpMethod.Patch, url);
                request.Content = JsonContent.Create(entrada);

                return await httpClient.SendAsync(request);
            }
            catch (TaskCanceledException ex)
            {
                _logger.LogError(ex, "[SEND_PATCH_ASYNC][ERRO] Timeout ao acessar API");
                throw CriarErroTimeout(sistema, msgErro);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "[SEND_PATCH_ASYNC][ERRO] Erro HTTP ao acessar API");
                throw CriarErroHttp(sistema, msgErro);
            }
        }

        public async Task<HttpResponseMessage> SendDeleteAsync(
            string url,
            object entrada,
            NomeHttpClient nomeHttpClient,
            string sistema,
            string msgErro,
            double? timeoutSegundos = null,
            string? eTag = null)
        {
            HttpRequestMessage? request = null;
            var timeout = timeoutSegundos ?? AppSettings.ServicesConfig.TimeoutPadraoMilissegundos;

            try
            {
                var httpClient = _httpClientFactory.CreateClient(nomeHttpClient.ToString());
                httpClient.Timeout = TimeSpan.FromMilliseconds(timeout);

                _logger.LogInformation(
                    "[SEND_DELETE_ASYNC][INICIO] Acessando api");

                request = new HttpRequestMessage(HttpMethod.Delete, url);
                request.Content = JsonContent.Create(entrada);

                return await httpClient.SendAsync(request);
            }
            catch (TaskCanceledException ex)
            {
                _logger.LogError(ex, "[SEND_DELETE_ASYNC][ERRO] Timeout ao acessar API");
                throw CriarErroTimeout(sistema, msgErro);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "[SEND_DELETE_ASYNC][ERRO] Erro HTTP ao acessar API");
                throw CriarErroHttp(sistema, msgErro);
            }
        }

        private static ApiServiceException CriarErroTimeout(string sistema, string msgErro)
        {
            var erro = new ErroDto(sistema, msgErro);

            return new ApiServiceException(
                JsonSerializer.Serialize(erro),
                HttpStatusCode.RequestTimeout);
        }

        private static ApiServiceException CriarErroHttp(string sistema, string msgErro)
        {
            var erro = new ErroDto(sistema, msgErro);

            return new ApiServiceException(
                JsonSerializer.Serialize(erro),
                HttpStatusCode.BadGateway);
        }
    }
}
