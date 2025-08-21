using StackExchange.Redis;

namespace RedisExampleApp.Cache;

public class RedisService
{
    private readonly ConnectionMultiplexer _connectionMultiplexer;

    public RedisService(string url)
    {
        _connectionMultiplexer = ConnectionMultiplexer.Connect(url);
    }

    public IDatabase GetDb(int dbIndex) 
    {
        var value = _connectionMultiplexer.GetDatabase(dbIndex);
        return value;
    }

}
