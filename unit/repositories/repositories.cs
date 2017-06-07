using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ruslan.prototype.test.infrastructure.repositories;
using unit.infrastructure;

namespace unit
{
    public class repositories:ioc<module>,IDisposable
    {
        #region setup
        public repositories()
        {

            _sut = resolve<icontactrepository>();
        }

        #endregion
        
        #region unit tests
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void can_get_allcontacts_correcty_populated()
        {


            var allcontacts = _sut.all();
            //contacts in file counted to 3
            Assert.Equal(allcontacts.Count(), 3);
        
            //first contact in file
            // id="{24ddf8a9-a4b7-4ced-a114-7ebcc011f35e}"
            // name="john"
            //lastname ="nash"
            //dateofbirth ="13-07-1928"
             Assert.Equal(allcontacts[0].id, "{24ddf8a9-a4b7-4ced-a114-7ebcc011f35e}");
             Assert.Equal(allcontacts[0].name, "john");
             Assert.Equal(allcontacts[0].lastname,"nash");
             Assert.Equal(allcontacts[0].dateofbirth, "13-07-1928");

        }

        #endregion
        
        #region teardown
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _sut = null;
        } 
        #endregion

        #region fields

        private  icontactrepository _sut;

        #endregion
    }
}
