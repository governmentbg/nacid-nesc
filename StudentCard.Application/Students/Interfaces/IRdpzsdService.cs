using StudentCard.Application.Users.Models;
using System.Threading.Tasks;

namespace StudentCard.Application.Students.Interfaces
{
	public interface IRdpzsdService
	{
		Task UpdateStudentName(string uan, RegiXGRAOResponse dto);

		Task UpdateEmail(string uan, string newEmail);
	}
}
