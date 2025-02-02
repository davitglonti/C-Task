public class TeacherPupil
{
    public int TeacherID { get; set; }
    public Teacher Teacher { get; set; }

    public int PupilID { get; set; }
    public Pupil Pupil { get; set; }
}