using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameBlog.BLL.Managers;
using VideoGameBlog.Data.Responses;
using VideoGameBlog.Models;

namespace VideoGameBlog.Tests.ManagerTests
{
    [TestFixture]
    public class TagManagerTests
    {
        [TestCase("test test test test test", "", 0, false)]
        [TestCase("# # # # # # # # # ", "", 0, false)]
        [TestCase("#test test #test test #test test #test test", "testtest", 4, true)]
        [TestCase("#test #test #test #test #test #test", "test", 6, true)]
        public void CanConvertStringToTags(string input, string tagName, int count, bool expected)
        {
            TagManager mgr = new TagManager();

            GenericResponse<List<Tag>> response = mgr.ConvertTagStringToList(input);

            bool actual = response.Success;

            if (actual)
                foreach (var t in response.Payload)
                {
                    actual = t.TagName == tagName;
                    if (!actual)
                        break;
                }

            if (actual)
                actual = count == response.Payload.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
