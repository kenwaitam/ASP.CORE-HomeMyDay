using HomeMyDay.Core.Models;
using HomeMyDay.Core.Repository;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace HomeMyDay.Infrastructure.Repository
{
	public class MDBAccommodationRepository : IAccommodationRepository
	{
		private readonly IConfiguration _configuration;

		private string uri;
		private readonly X509Certificate2 clietnCertificate;
		private readonly string serverCertificate;

		public MDBAccommodationRepository(IConfiguration config)
		{
			this._configuration = config;
			this.uri = _configuration.GetSection("ExternalAddresses").GetSection("NodeIp").Value + "/api/v1/accommodations";
			
			var certificateSettings = config.GetSection("Certificate");
			var servercertificateSettings = config.GetSection("Certificate");
			clietnCertificate = new X509Certificate2(certificateSettings.GetValue<string>("Location"));
			serverCertificate = servercertificateSettings.GetValue<string>("ServerCa");
		}

		public IEnumerable<Accommodation> Accommodations => this.GetAccommodations();

		public IEnumerable<Accommodation> GetAccommodations()
		{
			try
			{
				var accommodations = new List<Accommodation>();

				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

				request.ServerCertificateValidationCallback += (sender, certificate, chain, errors) =>
				{
					// return errors == SslPolicyErrors.None && hash.Contains(certificate.GetCertHashString());
					return errors == SslPolicyErrors.RemoteCertificateChainErrors && ValidateServerCert(certificate);
				};

				request.Method = WebRequestMethods.Http.Get;

				request.ClientCertificates.Add(clietnCertificate);

				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				Stream dataStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(dataStream);

				var json = reader.ReadToEnd();

				if (!string.IsNullOrWhiteSpace(json))
				{
					accommodations = JsonConvert.DeserializeObject<List<Accommodation>>(json);	  
				}

				return accommodations;								
			}
			catch(Exception ex)
			{
				throw new Exception("An error has occurred while retrieving accommodations: '{0}'", ex);
			}				
		}

		public Accommodation GetAccommodation(string id)
		{
			try
			{
				var accommodation = new Accommodation();

				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri + "/" + id);

				request.ServerCertificateValidationCallback += (sender, certificate, chain, errors) =>
				{
					// return errors == SslPolicyErrors.None && hash.Contains(certificate.GetCertHashString());
					return errors == SslPolicyErrors.RemoteCertificateChainErrors && ValidateServerCert(certificate);
				};

				request.Method = WebRequestMethods.Http.Get;

				request.ClientCertificates.Add(clietnCertificate);

				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				Stream dataStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(dataStream);

				var json = reader.ReadToEnd();

				if (!string.IsNullOrWhiteSpace(json))
				{
					accommodation = JsonConvert.DeserializeObject<Accommodation>(json);
				}

				return accommodation;
			}
			catch(Exception)
			{
				throw new Exception($"An error has occurred while retrieving accommodation with id: {id}");
			} 
		}

		public IEnumerable<Accommodation> GetRecommendedAccommodations()
		{
			try
			{
				var accommodations = new List<Accommodation>();

				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

				request.ServerCertificateValidationCallback += (sender, certificate, chain, errors) =>
				{
					// return errors == SslPolicyErrors.None && hash.Contains(certificate.GetCertHashString());
					return errors == SslPolicyErrors.RemoteCertificateChainErrors && ValidateServerCert(certificate);
				};

				request.Method = WebRequestMethods.Http.Get;

				request.ClientCertificates.Add(clietnCertificate);

				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				Stream dataStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(dataStream);

				var json = reader.ReadToEnd();
				if (!string.IsNullOrWhiteSpace(json))
				{
					accommodations = JsonConvert.DeserializeObject<List<Accommodation>>(json).Where(x => x.Recommended == true).ToList();
				}

				return accommodations;
			}
			catch (Exception)
			{
				throw new Exception("An error has occurred while retrieving recommended accommodations");
			}

			
		}

		public Task<PaginatedList<Accommodation>> List(int page = 1, int pageSize = 10)
		{
			throw new NotImplementedException();
		}

		public Task Save(Accommodation accommodation)
		{
			throw new NotImplementedException();
		}

		public Task Delete(string id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Accommodation> Search(string location, DateTime departure, DateTime returnDate, int amountOfGuests)
		{
			try
			{
				var accommodations = new List<Accommodation>();

				string dateFrom = departure.ToString("yyyy/MM/dd");
				string dateTo = departure.ToString("yyyy/MM/dd");

				var url = $"{uri}?search={location}&dateFrom={dateFrom}&dateTo={dateTo}&persons={amountOfGuests}"; 

				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

				request.ServerCertificateValidationCallback += (sender, certificate, chain, errors) =>
				{
					// return errors == SslPolicyErrors.None && hash.Contains(certificate.GetCertHashString());
					return errors == SslPolicyErrors.RemoteCertificateChainErrors && ValidateServerCert(certificate);
				};

				request.Method = WebRequestMethods.Http.Get;

				request.ClientCertificates.Add(clietnCertificate);

				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				Stream dataStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(dataStream);

				var json = reader.ReadToEnd();
				if(!string.IsNullOrWhiteSpace(json))
				{
					accommodations = JsonConvert.DeserializeObject<List<Accommodation>>(json);
				}

				return accommodations;
			}
			catch(Exception)
			{
				throw new Exception("An error has occurred while searching for accommodations");
			} 			
		}

		public bool ValidateServerCert(X509Certificate certificate)
		{
			var hash = X509Certificate.CreateFromCertFile(serverCertificate).GetCertHashString();
			return hash.Contains(certificate.GetCertHashString());
		}
	}
}
