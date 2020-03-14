using System;
using System.Xml.Serialization;
using Cw2.TemplatesReviewsForDifferentObjects;
[Serializable]
public class Student
{
	private string ska,
				   fname,
					lname,
					birthdate,
					email,
					mothersName,
					fathersName;
	
	private Studies studies;
	

	public Student()
	{}
	



	public string Ska
	{
		get{ return ska; }

		set{
			this.ska = value;
		}
	}


	public string Fname
	{
		get { return fname; }

		set
		{
			this.fname = value;
		}
	}
	public string Lname
	{
		get { return lname; }
		
		set{
			this.lname = value;
		}
	}


	public string Birthdate
	{
		get{ return birthdate; }
	
		set {
			this.birthdate = value;
		}
	}


	public string Email
	{
		get{ return lname; }

		set{
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
			this.mothersName = value;
		}
}
	public string FathersName
		{	get{
			return fathersName;
		}
		set {
			fathersName  = value;
		}
	}
	public Studies Studies {
		get { return studies; }

		set{
			studies = value;
		} 
	}



	public override bool Equals(Object obj)
	{
		//Check for null and compare run-time types.
		if ((obj == null) || !this.GetType().Equals(obj.GetType()))
		{
			return false;
		}
		else
		{
			Student student = (Student)obj;
			return (ska == student.ska) &&
					(fname == student.fname) &&
					(lname == student.lname);
		}
	}
