using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StudentCard.Infrastructure.Captcha.Models
{
	public class CaptchaResponse
	{
		public bool Success { get; set; }

		[JsonProperty(PropertyName = "challenge_ts")]
		public DateTime? ChallengeTs { get; set; }

		public string Hostname { get; set; }

		public decimal Score { get; set; }

		[JsonProperty(PropertyName = "error_codes")]
		public List<string> ErrorCodes { get; set; }
	}
}
