using System;
using System.Linq;

public class TeacherService
{
    private readonly AppDbContext _context;

    public TeacherService(AppDbContext context)
    {
        _context = context;
    }

    public Teacher[] GetAllTeachersByStudent(string studentName)
    {
        return _context.Teachers
            .Where(t => t.TeacherPupils
                .Any(tp => tp.Pupil.FirstName == studentName))
            .ToArray();
    }
}
