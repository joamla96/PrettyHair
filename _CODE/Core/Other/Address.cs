using System.IO;

namespace Core {
	public class Address {
		public int HouseNo { get; set; }
		public int FloorNo { get; set; }
		public string Entrance { get; set; } // Eg. Left / Right
		public string Streetname { get; set; }
		public string City { get; set; }
		public int ZipCode { get; set; }

		public Address(int housenr, int floornr, string enterance, string streetname, int zipcode, string city) {
			this.HouseNo = housenr;
			this.FloorNo = floornr;
			this.Entrance = enterance;
			this.Streetname = streetname;
			this.City = city;
			this.ZipCode = zipcode;
		}

		public Address(int housenr, string streetname, int postalcode, string city) {
			this.HouseNo = housenr;
			this.Streetname = streetname;
			this.City = city;
			this.ZipCode = postalcode;
		}

		public override string ToString() {
			StringWriter Output = new StringWriter();

			if (HouseNo != 0) Output.WriteLine("House No.: " + HouseNo);
			if (FloorNo != 0) Output.WriteLine("Floor No.: " + FloorNo);
			if (Entrance != null) Output.WriteLine("Entrance: " + Entrance);
			if (Streetname != null) Output.WriteLine("Streetname: " + Streetname);
			if (City != null) Output.WriteLine("City: " + City);
			if (ZipCode != 0) Output.WriteLine("Zip Code: " + ZipCode);

			return Output.ToString();
		}
	}
}
