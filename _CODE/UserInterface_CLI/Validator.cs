using System;
using System.Text.RegularExpressions;

namespace UserInterface_CLI {
	public class Validator {
		public bool text(string input) {
			return Regex.IsMatch(input, @"^[a-zA-Z]+$");
		}

		public bool number(string input) {
			return Regex.IsMatch(input, @"^[0-9]+$");
		}

		public bool alphanum(string input) {
			return Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");
		}

		public bool phone(string input) { // This might not be right...
			return Regex.IsMatch(input, @"(+||00)\d{10}");
		}

		public bool email(string input) {
			//return Regex.IsMatch(input, @"[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,64}");
			return true;
		}

		internal bool yesno(string input) {
			return true; //TODO
		}
	}
}
