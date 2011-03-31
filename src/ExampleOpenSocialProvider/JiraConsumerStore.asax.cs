using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using DevDefined.OAuth.Framework;
using DevDefined.OAuth.KeyInterop;
using DevDefined.OAuth.Storage;

namespace ExampleOpenSocialProvider
{
	public class JiraConsumerStore : IConsumerStore
	{
		readonly string _consumerKey;
		readonly string _publicKey;
		AsymmetricAlgorithm _publicKeyAlgorithm;

		public JiraConsumerStore()
		{
			_consumerKey = ConfigurationManager.AppSettings["consumerKey"];
			_publicKey = ConfigurationManager.AppSettings["publicKey"];
		}

		public bool IsConsumer(IConsumer consumer)
		{
			return (consumer.ConsumerKey == _consumerKey && string.IsNullOrEmpty(consumer.Realm));
		}

		public void SetConsumerSecret(IConsumer consumer, string consumerSecret)
		{
			throw new NotImplementedException();
		}

		public string GetConsumerSecret(IOAuthContext consumer)
		{
			return null;
		}

		public void SetConsumerCertificate(IConsumer consumer, X509Certificate2 certificate)
		{
			throw new NotImplementedException();
		}

		public AsymmetricAlgorithm GetConsumerPublicKey(IConsumer consumer)
		{
			if (_publicKeyAlgorithm == null)
			{
				var parser = new AsnKeyParser(Convert.FromBase64String(_publicKey));

				RSAParameters parameters = parser.ParseRSAPublicKey();

				var provider = new RSACryptoServiceProvider();

				provider.ImportParameters(parameters);

				_publicKeyAlgorithm = provider;
			}

			return _publicKeyAlgorithm;
		}
	}
}