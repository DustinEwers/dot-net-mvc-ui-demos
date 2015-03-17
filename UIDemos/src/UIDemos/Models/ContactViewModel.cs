using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UIDemos.Models
{
    public class ContactViewModel
    {
		public IEnumerable<SelectListItem> States {
			get {
				var _states = new List<string> {
					"Alabama", "Alaska","Arizona","Arkansas","California",
					"Colorado","Connecticut","Delaware","Florida","Georgia",
					"Hawaii","Idaho","Illinois","Indiana","Iowa",
					"Kansas","Kentucky","Louisiana","Maine","Maryland",
					"Massachusetts","Michigan","Minnesota","Mississippi","Missouri",
					"Montana","Nebraska","Nevada","New Hampshire","New Jersey",
					"New Mexico","New York","North Carolina","North Dakota","Ohio",
					"Oklahoma","Oregon","Pennsylvania", "Rhode Island","South Carolina",
					"South Dakota","Tennessee","Texas","Utah","Vermont",
					"Virginia","Washington","West Virginia","Wisconsin","Wyoming"
				};

				return _states.Select(st => new SelectListItem { Text = st, Value = st });
			}
		}
		
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Display(Name = "Address")]
		public string Address1 { get; set; }

		[Display(Name = "City")]
		public string City { get; set; }

		[Display(Name = "Zip Code")]
		public string ZipCode { get; set; }

		[Display(Name = "State")]
		public string State { get; set; }

		[Display(Name = "Email Address")]
		public string Email { get; set; }

		[Display(Name = "Birthday")]
		public DateTime? Birthday { get; set; }
	}
}