﻿using AutoMapper;
using Domain.Dtos.Weather;
using Domain.Interfaces.ExternalServices;
using Infrastructure.ExternalServices.WeatherAPI.Response.GetWeathertDataResponse;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Infrastructure.ExternalServices.WeatherAPI;

public class ExternalWeatherAPIService : IExternalWeatherService
{
    private readonly HttpClient _client;
    private readonly IMapper _mapper;
    private readonly WeatherAPIOptions _options;
    private const string latitudeAndLongitudeDelimiter = ",";
    public ExternalWeatherAPIService(HttpClient client, IMapper mapper, IOptions<WeatherAPIOptions> options)
    {
        _client = client;
        _mapper = mapper;
        _options = options.Value;
    }

    public async Task<GetWeatherDto> GetWeatherData(decimal latitude, decimal longitude)
    {
        _client.BaseAddress = new Uri(_options.BaseUrl);
        var latitudeAndLongitude = $"{latitude}{latitudeAndLongitudeDelimiter}{longitude}";
        var response = await _client.GetFromJsonAsync<GetWeathertDataResponse>($"/forecast.json?key={_options.ApiKey}&q={latitudeAndLongitude}&days=7&aqi=no&alerts=no");
        return _mapper.Map<GetWeatherDto>(response);
    }
}
