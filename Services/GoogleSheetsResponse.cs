using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using USCEvents.Models;
using Xamarin.Forms;

namespace USCEvents.Services
{
	public class GoogleSheetsResponse
	{
		public string range { get; set; }
		public string majorDimension { get; set; }
		public List<List<string>> values { get; set; }
	}
	
}
