﻿using Shared.Models;
using System.Text.Json;

namespace RazorFrontend.Services;

public class WeatherClient
{
    private readonly JsonSerializerOptions options = new JsonSerializerOptions()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    private readonly HttpClient client;

    public WeatherClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<WeatherForecast[]> GetWeatherAsync()
    {
        var responseMessage = await this.client.GetAsync("/weatherforecast");
        var stream = await responseMessage.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<WeatherForecast[]>(stream, options);
    }
}
