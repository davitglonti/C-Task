using System.Collections.Generic;

public class Pupil
{
    public int PupilID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Class { get; set; }

    public List<TeacherPupil> TeacherPupils { get; set; } = new List<TeacherPupil>();
}
