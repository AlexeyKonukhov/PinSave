using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PinSave.Models.AuxiliaryСlasses;

public class HttpManager : IDisposable
{
    private readonly HttpClient _client;

    private bool _disposed;


    public HttpManager()
    {
        var handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.None
        };
        _client = new HttpClient(handler);
        _client.DefaultRequestHeaders.UserAgent.ParseAdd(
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 YaBrowser/24.1.0.0 Safari/537.36");
        _client.DefaultRequestHeaders.Accept.ParseAdd(
            "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
        _client.DefaultRequestHeaders.AcceptLanguage.ParseAdd("ru-Ru;q=0.7,ru;q=0.3");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async Task<string> GetPageAsync(string url)
    {
        CheckDisposed();
        try
        {
            using var response = await _client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            return await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    private void CheckDisposed()
    {
        ObjectDisposedException.ThrowIf(_disposed, nameof(HttpManager));
    }

    protected virtual void Dispose(bool disposing)
    {
        CheckDisposed();
        if (disposing)
            _client.Dispose();
        _disposed = true;
    }

    ~HttpManager()
    {
        Dispose(false);
    }
}