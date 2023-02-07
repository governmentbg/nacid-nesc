using System;
using System.Xml.Serialization;

namespace StudentCard.Application.Users.Models
{
    [XmlRoot(ElementName= "PersonDataResponse", Namespace = "http://egov.bg/RegiX/GRAO/NBD/PersonDataResponse")]
    [Serializable]
    public class RegiXGRAOResponse
    {
        [XmlElement(ElementName = "PersonNames")]
        public Names PersonNames { get; set; }

        [XmlElement(ElementName = "LatinNames")]
        public Names LatinNames { get; set; }
    }

    [XmlRoot(ElementName = "PersonDataResponse", Namespace = "http://egov.bg/RegiX/GRAO/NBD")]
    [Serializable]
    public class Names
    {
        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "SurName")]
        public string SurName { get; set; }

        [XmlElement(ElementName = "FamilyName")]
        public string FamilyName { get; set; }
    }
}
