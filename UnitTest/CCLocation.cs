using System;
using System.Linq;
using ClaroTechCCLibrary.ExtensionMethods;
using ClaroTechCCLibrary.Utilities;
using Hl7.Fhir.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCLocation
{
    [TestClass]
    public class CCLocation
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
