using System;
using System.Xml.Serialization;
using Cw2.TemplatesReviewsForDifferentObjects;
[Serializable]
//[XmlSerializable]
// [XmlRoot(ElementName = "student")]
public class Student
{
	//[XML ...]
	
	private string ska,
				   fname,
					lname,
					birthdate,
					email,
					mothersName,
					fathersName;
	// [XmlAttribute(ska = "indexNumber")]
	//studies 
	private Studies studies;
	

	// [XmlElement(Imie = "")]
	public Student() // -- string ska, string fname ) //--_ , string lname, string birthdate, string email, string mothersName, string fathersName, Studies studies)
	{
		// if(paramm == null OR "" ) throw new MyException();
		// -- this.ska = ska;
		// -- this.fname = fname;
		/*
		this.lname = lname;
		this.birthdate = birthdate;
		this.email = email;
		this.mothersName = mothersName;
		this.fathersName = fathersName; //
										// StudentException (Недостаточно парраметров или неверные параметры)
		this.studies = studies;
	--_ */
	}
	



	public string Ska
	{
		get{ return ska; }

		set{
			if (value == null || value == "")
				Console.WriteLine("Excp");
			this.ska = value;
		}
	}


	public string Fname
	{
		get { return fname; }

		set
		{
			if (value == null || value == "")
				Console.WriteLine("Excp");

			this.fname = value;
		}
	}
	public string Lname
	{
		get { return lname; }
		
		set{
			if (value == null || value == "")
				Console.WriteLine("Excp");

			this.lname = value;
		}
	}


	public string Birthdate
	{
		get{ return birthdate; }
	
		set {
			if (value == null || value == "")
				Console.WriteLine("Excp");
			this.birthdate = value;
		}
	}


	public string Email
	{
		get{ return lname; }

		set{
			if (value == null || value == "")
				Console.WriteLine("Excp");

			this.email = value;
		}
	}
	public string MothersName
	{
		get
		{
			return mothersName;
		}
	
		set
		{
			if (value == null || value == "")
				Console.WriteLine("Excp");
			this.mothersName = value;
		}
}
	public string FathersName
		{	get{
			return fathersName;
		}
		set {
			if (value == null || value == "")
				Console.WriteLine("Excp");
			fathersName  = value;
		}
	}
	public Studies Studies {
		get { return studies; }

		set{
			studies = value;
		} 
	}
	


	/*
	public string Fname(){ 
		get{ return fname; }
		set{ this.fname = fname; }
	}
	*/
	// public string Lname(){ get; set;	}

}
