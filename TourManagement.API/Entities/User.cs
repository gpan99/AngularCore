using System.Collections.Generic;

namespace TourManagement.API.Entities {
  public class User
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
  }
}