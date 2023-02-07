using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Interfaces;
using StudentCard.Data.Rdpzsd.Students.Parts.PersonSecondary.Base;

namespace StudentCard.Data.Rdpzsd.Students.Parts.PersonSecondary
{
    public class PersonSecondary : BasePersonSecondary<PersonSecondaryInfo>,
        ISinglePart<PersonSecondary, PersonLot>
    {
        [Skip]
        public PersonLot Lot { get; set; }
        public bool FromRso { get; set; }

        //This is used for calling diploma images
        public double? RsoIntId { get; set; }
        public PersonSecondary() { }
    }
}
