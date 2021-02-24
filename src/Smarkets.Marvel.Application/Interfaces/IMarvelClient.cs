namespace Smarkets.Marvel.Application.Interfaces
{
	public interface IMarvelClient
    {
        string Host { get; }

        string PublicKey { get; }
        string PrivateKey { get; }

        string GetHash();
        string GetApiKey();
        string GetTimeStamp();
    }
}
