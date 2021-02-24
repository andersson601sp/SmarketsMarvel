using Smarkets.Marvel.Application.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Smarkets.Marvel.Application.Services
{
	public class MarvelClient: IMarvelClient
	{
		public string PublicKey { get; private set; }
		public string PrivateKey { get; private set; }
		public string Host { get; private set; }

		private readonly string timeStamp;

		public MarvelClient(string publicKey, string privateKey, string host)
		{
			PublicKey = publicKey;
			PrivateKey = privateKey;
			Host = host;

			timeStamp = DateTime.Now.Ticks.ToString();
		}

		public string GetHash()
		{
			byte[] bytes = Encoding.UTF8.GetBytes($"{this.timeStamp}{PrivateKey}{PublicKey}");
			byte[] bytesHash = MD5.Create().ComputeHash(bytes);

			return BitConverter.ToString(bytesHash).ToLower().Replace("-", String.Empty);
		}

		public string GetApiKey()
		{
			return this.PublicKey;
		}

		public string GetTimeStamp()
		{
			return this.timeStamp;
		}
	}
}