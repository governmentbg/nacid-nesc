namespace SSL.API.Models
{
    public class SearchResult
    {
        public string Uan { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string OtherNames { get; set; }

        public string FirstNameAlt { get; set; }
        public string MiddleNameAlt { get; set; }
        public string LastNameAlt { get; set; }
        public string OtherNamesAlt { get; set; }

        public string Uin { get; set; }
        public string ForeignerNumber { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public List<SearchResultSpecialities> Specialities = new List<SearchResultSpecialities>();
        public List<SearchResultDoctoral> Doctorals = new List<SearchResultDoctoral>();
    }
}
