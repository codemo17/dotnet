using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ruslan.prototype.test.app.viewmodels;
using ruslan.prototype.test.domain.models;
using ruslan.prototype.test.infrastructure.repositories;
using unit.infrastructure;

namespace unit.viewmodels
{
    public class viewmodel:ioc<module>,IDisposable
    {

        #region setup
        /// <summary>
        /// 
        /// </summary>
        public viewmodel()
        {
            _repository = resolve<icontactrepository>();
            _sut = resolve<contactviewmodel>();
        }

        #endregion

        #region testing
        
        [Fact]
        public void can_add_new_contact()
        {
            //arrange
            var contact = new contact
                              {
                                  name = "stephen",
                                  lastname = "hawking",
                                  dateofbirth = "8/1/1942",
                                  
                              };
            _sut.model = contact;

            //act
            var savecommand = _sut.savecontactcommand;
            //assert
            savecommand.Execute(null);

            var found =_repository.single(contact.id.ToString());

            Assert.Equal(found.id,contact.id);
            Assert.Equal(found.name, contact.name);
            Assert.Equal(found.lastname, contact.lastname);


        }
        
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _sut = null;
        } 
        #endregion

        #region fields

        private  contactviewmodel _sut;
        private icontactrepository _repository;

        #endregion
    }
}
