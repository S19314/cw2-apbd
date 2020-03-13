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
	[XmlAttribute(ska = "indexNumber")]
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
	
	public string GetSka()
	{
		return ska;
	}

	public void SetSka(string ska) {
		this.ska = ska;
	}

	public string getFname(){
		return fname;
	}
	public void setFname(string fname){
		this.fname = fname;
	}
	
	public string getLname()
	{
		return lname;
	}
	public void setLname(string lname)
	{
		this.lname = lname;
	}

	public string getBirthdate()
	{
		return birthdate;
	}
	public void setBirthdate(string birthdate)
	{
		this.birthdate = birthdate;
	}


	public string getEmail()
	{
		return lname;
	}
	public void setEmail(string email)
	{
		this.email = email;
	}
	public string getMothersName()
	{
		return mothersName;
	}
	public void setMothersName(string mothersName)
	{
		this.mothersName = mothersName;
	}

	public string getFathersName()
	{
		return fathersName;
	}
	public void setFathersName(string fathersName)
	{
		this.fathersName  = fathersName;
	}

	public Studies GetStudies() {
		return studies;
	}

	public void SetStudies(Studies studies) {
		this.studies = studies; 
	}
	


	/*
	public string Fname(){ 
		get{ return fname; }
		set{ this.fname = fname; }
	}
	*/
	// public string Lname(){ get; set;	}

}
