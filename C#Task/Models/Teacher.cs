using System.Collections.Generic;

public class Teacher
{
    public int TeacherID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Subject { get; set; }

    public List<TeacherPupil> TeacherPupils { get; set; } = new List<TeacherPupil>();
}
