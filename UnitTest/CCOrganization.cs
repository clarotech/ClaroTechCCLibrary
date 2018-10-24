using System;
using System.Linq;
using ClaroTechCCLibrary.ExtensionMethods;
using ClaroTechCCLibrary.Utilities;
using Hl7.Fhir.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCOrganization
{
    [TestClass]
    public class CCOrganization
    {
        [TestMethod]
        public void Initialisation()
        {
            Organization tt = new Organization();
            tt.CCInit();

             Assert.AreNotEqual(tt.Meta, null);
            Assert.AreEqual(tt.Meta.Profile.First(), Constants.ProfileCCOrganization);

        }

        [TestMethod]
        public void OrganisationPeriod()
        {
            var tt = new Organization();
            tt.CCInit();

            var p = new Period();
            p.Start = new FhirDateTime(DateTime.Now).ToString();

            tt.CCSetPeriod(p);

            Assert.AreEqual(tt.Extension.Exists(e => e.Url == Constants.ProfileHl7OrganizationPeriod), true);
        }

        [TestMethod]
        public void OrganisationMainLocation()
        {
            var tt = new Organization();
            tt.CCInit();

            var rr = new ResourceReference("http://test.com", "test");

            tt.CCSetMainLocation(rr);

            Assert.AreEqual(tt.Extension.Exists(e => e.Url == Constants.ExtensionCCMainLocation), true);
        }

        [TestMethod]
        public void ODSOrg()
        {
            var tt = new Organization();
            tt.CCInit();

            tt.CCAddOdsOrganisationCode("ABC123");

            Assert.AreEqual(tt.Identifier.Exists(e => e.System == Constants.SystemNHSOdsOrganisationCode), true);
            Assert.AreEqual(tt.Identifier.Exists(e => e.Value == "ABC123"), true);
        }

        [TestMethod]
        public void ODSSite()
        {
            var tt = new Organization();
            tt.CCInit();

            tt.CCAddOdsSiteCode("ABC123");

            Assert.AreEqual(tt.Identifier.Exists(e => e.System ==Constants.SystemNHSOdsSiteCode), true);
            Assert.AreEqual(tt.Identifier.Exists(e => e.Value == "ABC123"), true);
        }
    }
}
