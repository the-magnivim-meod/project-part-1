using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using BE;

namespace Dal_XML_imp
{
    class GuestRequestXML
    {
        XElement guestRequestRoot;
        string guestRequestPath = @"data/GuestRequestXML.xml";

        public void SaveGuestRequestList(List<GuestRequest> requests)
        {
            guestRequestRoot = new XElement("guestRequests", from stud in requests
                                                             select new XElement("guestRequest", 
                                                             new XElement("id", stud.GuestRequestKey),
                                                             new XElement("name", new XElement("firstName",stud.PrivateName),new XElement("familyName",stud.FamilyName)),
                                                             new XElement("extras", new XElement("pool",stud.Pool), new XElement("garden", stud.Garden), new XElement("groceryStore", stud.CloseByGroceryStore), new XElement("attractions", stud.ChildrensAttractions)),
                                                             new XElement("status",stud.Status),
                                                             new XElement("area",stud.Area),
                                                             new XElement("dates", new XElement("registrationDate", stud.RegistrationDate), new XElement("entryDate", stud.EntryDate), new XElement("releaseDate", stud.ReleaseDate))
                                                             )
                                                             );
            guestRequestRoot.Save(guestRequestPath);
        }

        public void LoadData()
        {
            try
            {
                guestRequestRoot = XElement.Load(guestRequestPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }

        public List<GuestRequest> GetStudentList()
        {
            LoadData();
            List<GuestRequest> guestRequests;
            try
            {
                guestRequests = (from req in guestRequestRoot.Elements()
                                 select new GuestRequest()
                                 {
                                     GuestRequestKey = int.Parse(req.Element("id").Value),
                                     PrivateName = req.Element("name").Element("firstName").Value,
                                     FamilyName = req.Element("name").Element("familyName").Value,
                                     RegistrationDate = ToDateTime(req.Element("dates").Element("registrationDate").Value),
                                     EntryDate = req.Element("dates").Element("entryDate").Value,
                                     ReleaseDate = req.Element("dates").Element("releaseDate").Value,

                                 }).ToList();
            }
            catch
            {
                guestRequests = null;
            }
            return guestRequests;
        }
    }
}
