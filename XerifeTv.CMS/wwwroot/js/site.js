async function httpClient(url) {
  return await axios.get(url, {
    params: {
      api_key: env['tmdbApiKey'],
      language: 'pt-BR',
      page: 1
    }
  });
}