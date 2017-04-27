using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using USCEvents.Services;
using USCEvents.Models;
using USCEvents.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(GoogleService))]
namespace USCEvents.iOS
{
	public class GoogleService : IGoogleService
	{
		public string[] Scopes { get; set; }
		public string ApplicationName { get; set; }

		private readonly string[] _scopes = { SheetsService.Scope.SpreadsheetsReadonly };
		private readonly string _applicationName = "Google Sheets API .NET Quickstart";

		private SheetsService _service;
		public SheetsService Service
		{
			get
			{
				return _service ?? Task.Run(() => GetSheetsService()).Result;
			}
		}

		private async Task<SheetsService> GetSheetsService()
		{
			Scopes = _scopes;
			ApplicationName = _applicationName;
			UserCredential credential;
			using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
			{
				string credPath = System.Environment.GetFolderPath(
					System.Environment.SpecialFolder.Personal);
				credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");
				var secrets = GoogleClientSecrets.Load(stream).Secrets;
				var folder = new FileDataStore(credPath, true);

				credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
					secrets,
					Scopes,
					"user",
					CancellationToken.None,
					folder);
			}
			return new SheetsService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = ApplicationName,
			});
		}


		public async Task<List<Event>> GetEventsAsync()
		{
			var service = await GetSheetsService();

			string spreadsheetId = Configuration.EventsSpreadsheetId;
			string rangeQuery = Configuration.EventsRangeQuery;
			SpreadsheetsResource.ValuesResource.GetRequest request =
					service.Spreadsheets.Values.Get(spreadsheetId, rangeQuery);

			ValueRange response = request.Execute();
			var values = response?.Values;
			var events = new List<Event>();
			if (values != null && values.Count > 0)
			{
				foreach (var row in values)
				{
					foreach (var e in row)
					{
						Console.WriteLine(e.ToString());
					}
				}
			}
			return null;
		}

		//// current method that's creating the credential but doesn't finish executing after initilializing the credential
		//public async void GetEvents()
		//{
		//	UserCredential credential;
		//	var Scopes = _scopes;
		//	using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
		//	{
		//		string credPath = System.Environment.GetFolderPath(
		//			System.Environment.SpecialFolder.Personal);
		//		credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");
		//		var secrets = GoogleClientSecrets.Load(stream).Secrets;
		//		var folder = new FileDataStore(credPath, true);

		//		credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
		//			secrets,
		//			Scopes,
		//			"user",
		//			CancellationToken.None,
		//			folder);
		//		Console.WriteLine("Credential file saved to: " + credPath);
		//	}

		//	// Create Google Sheets API service.
		//	var service = new SheetsService(new BaseClientService.Initializer()
		//	{
		//		HttpClientInitializer = credential,
		//		ApplicationName = ApplicationName,
		//	});

		//	// Define request parameters.
		//	String spreadsheetId = Configuration.EventsSpreadsheetId;
		//	String range = Configuration.EventsRangeQuery;
		//	SpreadsheetsResource.ValuesResource.GetRequest request =
		//			service.Spreadsheets.Values.Get(spreadsheetId, range);

		//	// Prints the names and majors of students in a sample spreadsheet:
		//	// https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit
		//	ValueRange response = request.Execute();
		//	IList<IList<Object>> values = response.Values;
		//	if (values != null && values.Count > 0)
		//	{
		//		Console.WriteLine("Name, Major");
		//		foreach (var row in values)
		//		{
		//			// Print columns A and E, which correspond to indices 0 and 4.
		//			Console.WriteLine("{0}, {1}", row[0], row[4]);
		//		}
		//	}
		//	else
		//	{
		//		Console.WriteLine("No data found.");
		//	}
		//	Console.Read();

		//}
	}
}
